using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CameraInputHandler : MonoBehaviour{

    private CubeInputActions inputActions;

    [SerializeField] GraphicRaycaster graphicRaycaster;
    [SerializeField] EventSystem eventSystem;
    private int cubeLayerMask;

    public CubeFace PaintColor{get; set;}

    private bool isPaintMode = false;

    private bool isDragging;
    private bool isHoldingCube;

    private bool paintPiece = false;

    private bool doubleTurnMode = false;

    [SerializeField] private float mouseRadiusToPerformMove;

    private Vector2 startMoveClickCoords;

    private Vector3 planeNormal;
    private Vector3 initialClickPosition;

    public bool IsSideView{get; set;} = true;

    private ColorElement currentColorElement;

    public event Action<Vector2> OnCameraMove;
    public event Action<int> OnZoom;

    private void Awake(){
        inputActions = InputManager.InputActions;
        cubeLayerMask = 1 << LayerMask.NameToLayer("Cube");
    }

    private void OnEnable(){
        EnableCubeActions();
    }

    private void OnDisable(){
        DisableCubeActions();
    }

    private void EnableCubeActions(){
        
        inputActions.Cube.Click.started += MouseClickStarted;
        inputActions.Cube.Click.canceled += MouseClickCanceled;
        inputActions.Cube.Look.performed += Move;
        inputActions.Cube.Zoom.performed += MouseWheel;
        inputActions.Cube.DoubleTurn.performed += SetDoubleTurn;
        inputActions.Cube.DoubleTurn.canceled += SetDoubleTurn;

        inputActions.Cube.Enable();
    }

    private void DisableCubeActions(){

        inputActions.Cube.Click.started -= MouseClickStarted;
        inputActions.Cube.Click.canceled -= MouseClickCanceled;
        inputActions.Cube.Look.performed -= Move;
        inputActions.Cube.Zoom.performed -= MouseWheel;
        inputActions.Cube.DoubleTurn.performed -= SetDoubleTurn;
        inputActions.Cube.DoubleTurn.canceled -= SetDoubleTurn;

        inputActions.Cube.Disable();

    }

    public void SetPaintMode(bool mode){
        isPaintMode = mode;
    }

    private void MouseClickPaintMode(){

        Vector2 screenPosition = Pointer.current.position.ReadValue();
        startMoveClickCoords = screenPosition;

        Ray ray = Camera.main.ScreenPointToRay(screenPosition);

        if(Physics.Raycast(ray, out RaycastHit hitInfo, 50f, cubeLayerMask)){

            isHoldingCube = true;

            planeNormal = hitInfo.normal;
            initialClickPosition = hitInfo.point;

            if(hitInfo.collider.gameObject.TryGetComponent<ColorElement>(out ColorElement colorElement)){
                colorElement.SetColor(PaintColor);
            }

        }
        else{
            isDragging = true;
        }

    }

    private void MouseClickStarted(InputAction.CallbackContext ctx){

        PointerEventData pointerData = new PointerEventData(eventSystem){
            position = Pointer.current.position.ReadValue()
        };

        List<RaycastResult> results = new List<RaycastResult>();
        graphicRaycaster.Raycast(pointerData, results);

        if(results.Count > 0){
            return;
        }

        Vector2 screenPosition = Pointer.current.position.ReadValue();
        startMoveClickCoords = screenPosition;

        Ray ray = Camera.main.ScreenPointToRay(screenPosition);

        if(Physics.Raycast(ray, out RaycastHit hitInfo, 50f, cubeLayerMask)){

            isHoldingCube = true;

            planeNormal = hitInfo.normal;
            initialClickPosition = hitInfo.point;
            paintPiece = false;

            if(hitInfo.collider.gameObject.TryGetComponent<ColorElement>(out ColorElement colorElement)){
                currentColorElement = colorElement;
                currentColorElement.Highlight();
                paintPiece = true;
            }
            else{
                currentColorElement.Lowlight();
                currentColorElement = null;
            }
        }
        else{
            isDragging = true;
        }

    }

    private void SetDoubleTurn(InputAction.CallbackContext ctx){

        doubleTurnMode = ctx.ReadValue<float>() > 0f;

    }

    private void MouseWheel(InputAction.CallbackContext ctx){

        int zoom = (int)ctx.ReadValue<float>() >> -1 | 1;
        OnZoom?.Invoke(zoom);

    }
    
    public void Move(InputAction.CallbackContext context){

        if(isDragging){
            OnCameraMove?.Invoke(context.ReadValue<Vector2>());
            return;
        }

        if(isHoldingCube){

            Vector2 screenPosition = Pointer.current.position.ReadValue();

            if(Vector2.Distance(startMoveClickCoords, screenPosition) > mouseRadiusToPerformMove){

                Ray ray = Camera.main.ScreenPointToRay(screenPosition);

                float denominator = Vector3.Dot(planeNormal, ray.direction);
                if(Mathf.Abs(denominator) < 1e-6f){
                    return;
                }

                float t = Vector3.Dot(planeNormal, initialClickPosition - ray.origin) / denominator;

                if(t<0){
                    return;
                }

                Vector3 intersectPoint = ray.origin + t * ray.direction - initialClickPosition;

                Vector3 resultDirection = new Vector3(Mathf.Sign(intersectPoint.x),0,0);

                if(Mathf.Abs(intersectPoint.y) > Mathf.Abs(intersectPoint.x)){
                    resultDirection = new Vector3(0,Mathf.Sign(intersectPoint.y),0);
                }

                if(Mathf.Abs(intersectPoint.z) > Mathf.Abs(intersectPoint.y) && Mathf.Abs(intersectPoint.z) > Mathf.Abs(intersectPoint.x)){
                    resultDirection = new Vector3(0,0,Mathf.Sign(intersectPoint.z));
                }

                if(currentColorElement != null){
                    paintPiece = false;
                    currentColorElement.Lowlight();
                    if(!isPaintMode){
                        currentColorElement.DoMove(resultDirection, doubleTurnMode);
                    }
                }

                isHoldingCube = false;

            }

        }
        else{
            paintPiece = false;
        }

    }

    private void MouseClickCanceled(InputAction.CallbackContext ctx){
        isDragging = false;
        isHoldingCube = false;
        if(currentColorElement != null){
            currentColorElement.Lowlight();
            if(isPaintMode && paintPiece){
                currentColorElement.SetColor(PaintColor);
            }
        }
    }
}
