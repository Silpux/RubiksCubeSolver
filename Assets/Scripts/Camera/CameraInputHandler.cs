using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraInputHandler : MonoBehaviour{

    private CubeInputActions inputActions;
    private int cubeLayerMask;

    private bool isDragging;
    private bool isHoldingCube;

    [SerializeField] private float radiusToMove;

    private Vector2 startMoveClickCoords;

    private Vector3 planeNormal;
    private Vector3 initialClickPosition;

    private ColorElement currentColorElement;

    public event Action<Vector2> OnCameraMove;
    public event Action<int> OnZoom;

    private void Awake(){
        inputActions = InputManager.InputActions;
        cubeLayerMask = 1 << LayerMask.NameToLayer("Cube");
    }

    private void OnEnable(){

        inputActions.Cube.Click.started += MouseClickStarted;
        inputActions.Cube.Click.canceled += MouseClickCanceled;
        inputActions.Cube.Look.performed += Move;
        inputActions.Cube.Zoom.performed += MouseWheel;

        inputActions.Cube.Enable();

    }

    private void OnDisable(){

        inputActions.Cube.Click.started -= MouseClickStarted;
        inputActions.Cube.Click.canceled -= MouseClickCanceled;
        inputActions.Cube.Look.performed -= Move;
        inputActions.Cube.Zoom.performed -= MouseWheel;

        inputActions.Cube.Disable();

    }

    private void MouseClickStarted(InputAction.CallbackContext ctx){

        Vector2 screenPosition = Pointer.current.position.ReadValue();
        startMoveClickCoords = screenPosition;

        Ray ray = Camera.main.ScreenPointToRay(screenPosition);

        if(Physics.Raycast(ray, out RaycastHit hitInfo, 50f, cubeLayerMask)){

            isHoldingCube = true;

            planeNormal = hitInfo.normal;
            initialClickPosition = hitInfo.point;

            if(hitInfo.collider.gameObject.TryGetComponent<ColorElement>(out ColorElement colorElement)){
                currentColorElement = colorElement;
            }
            else{
                currentColorElement = null;
            }

        }
        else{
            isDragging = true;
        }

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

            if(Vector2.Distance(startMoveClickCoords, screenPosition) > radiusToMove){

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
                    currentColorElement.DoMove(resultDirection);
                }

            }

        }

    }

    private void MouseClickCanceled(InputAction.CallbackContext ctx){
        isDragging = false;
        isHoldingCube = false;
    }
}
