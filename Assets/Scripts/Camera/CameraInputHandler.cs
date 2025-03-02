using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraInputHandler : MonoBehaviour{

    private CubeInputActions inputActions;

    private bool isDragging;

    public event Action<Vector2> OnCameraMove;
    public event Action<int> OnZoom;

    private void Awake(){
        inputActions = InputManager.InputActions;
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

        if(Physics.Raycast(ray, out RaycastHit hitInfo, 50f)){
            isDragging = false;
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
