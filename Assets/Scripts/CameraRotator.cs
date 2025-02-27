using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotator : MonoBehaviour{

    public float rotationSpeed = 20f;
    private bool isDragging = false;
    


    private float verticalAngle;
    private float distanceFromCenter = 10f;

    private Vector3 currentRotation;


    private CubeInputActions inputActions;

    private void Awake(){
        inputActions = InputManager.InputActions;
        verticalAngle = transform.rotation.eulerAngles.x;
    }

    private void OnEnable(){

        inputActions.Cube.Click.started += MouseClickStarted;
        inputActions.Cube.Click.canceled += MouseClickCanceled;
        inputActions.Cube.Look.performed += OnMove;
        inputActions.Cube.Zoom.performed += OnZoom;

        inputActions.Cube.Enable();

    }

    private void OnDisable(){

        inputActions.Cube.Click.started -= MouseClickStarted;
        inputActions.Cube.Click.canceled -= MouseClickCanceled;
        inputActions.Cube.Look.performed -= OnMove;
        inputActions.Cube.Zoom.performed -= OnZoom;

        inputActions.Cube.Disable();

    }

    private void OnZoom(InputAction.CallbackContext ctx){

        int zoom = (int)ctx.ReadValue<float>() >> -1 | 1;
        distanceFromCenter += zoom;

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

        Quaternion rotationY = Quaternion.AngleAxis(mouseDelta.x * rotationSpeed * Mathf.PI / 180f, Vector3.up);

        float newVerticalAngle = verticalAngle - mouseDelta.y * rotationSpeed * Mathf.PI / 180f;
        newVerticalAngle = Mathf.Clamp(newVerticalAngle, -90f, 90f);

        float deltaAngle = newVerticalAngle - verticalAngle;
        
        Quaternion rotationX = Quaternion.AngleAxis(deltaAngle, transform.right);
        verticalAngle = newVerticalAngle;

        transform.rotation = rotationY * rotationX * transform.rotation;

        transform.position = transform.rotation * new Vector3(0, 0, -distanceFromCenter);

    }

}
