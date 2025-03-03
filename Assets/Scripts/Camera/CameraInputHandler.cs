using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraInputHandler : MonoBehaviour{

    private CubeInputActions inputActions;
    private int cubeLayerMask;

    private bool isDragging;

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
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);

        if(Physics.Raycast(ray, out RaycastHit hitInfo, 50f, cubeLayerMask)){

            Debug.DrawLine(hitInfo.point, hitInfo.point + hitInfo.normal, Color.red, 2f);

            Matrix4x4 camMatrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
            Matrix4x4 camToWorld = camMatrix.inverse;

            Vector3 directionCamSpace = camToWorld.MultiplyVector(hitInfo.normal);

            Vector2 projectedDirection = new Vector2(directionCamSpace.x, directionCamSpace.y);

            float angle = Mathf.Atan2(projectedDirection.y, projectedDirection.x) * Mathf.Rad2Deg;

            Debug.Log(angle);

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

        if(!isDragging) return;
        OnCameraMove?.Invoke(context.ReadValue<Vector2>());

    }

    private void MouseClickCanceled(InputAction.CallbackContext ctx){
        isDragging = false;
    }
}
