using UnityEngine;
using UnityEngine.InputSystem;

public class CubeRotator : MonoBehaviour{

    public float rotationSpeed = 5f;
    private bool isDragging = false;
    private Vector2 lastMousePosition;

    private CubeInputActions inputActions;

    private void Awake(){
        inputActions = InputManager.InputActions;
    }

    private void OnEnable(){
        inputActions.Cube.Click.started += MouseClickStarted;
        inputActions.Cube.Click.canceled += MouseClickCanceled;
        inputActions.Cube.Look.performed += OnMove;
        inputActions.Cube.Enable();
    }

    private void OnDisable(){
        inputActions.Cube.Click.started -= MouseClickStarted;
        inputActions.Cube.Click.canceled -= MouseClickCanceled;
        inputActions.Cube.Look.performed -= OnMove;
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

    private void MouseClickCanceled(InputAction.CallbackContext ctx){

        isDragging = false;

    }

    public void OnMove(InputAction.CallbackContext context){

        if(!isDragging) return;

        Vector2 mouseDelta = context.ReadValue<Vector2>();

        transform.Rotate(Vector3.up, -mouseDelta.x * rotationSpeed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.right, mouseDelta.y * rotationSpeed * Time.deltaTime, Space.World);

    }

}
