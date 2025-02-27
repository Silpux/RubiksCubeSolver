using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotator : MonoBehaviour{

    [SerializeField] private float rotationSpeed = 20f;
    [SerializeField] private float dampingFactor = 15f;

    [SerializeField] private float minDistanceFromCenter = 5f;
    [SerializeField] private float maxDistanceFromCenter = 15f;

    private float verticalAngle;
    private float distanceFromCenter = 10f;



    private Vector3 currentRotation;
    private Vector2 rotationVelocity = Vector2.zero;

    private CubeInputActions inputActions;
    private bool isDragging;

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

    private void Update(){
        rotationVelocity = Vector2.Lerp(rotationVelocity, Vector2.zero, Time.deltaTime * dampingFactor);

        if(rotationVelocity.sqrMagnitude > 0.0001f){
            ApplyRotation(rotationVelocity);
        }
    }

    private void OnZoom(InputAction.CallbackContext ctx){

        int zoom = (int)ctx.ReadValue<float>() >> -1 | 1;
        distanceFromCenter -= zoom / 2f;

        distanceFromCenter = Mathf.Clamp(distanceFromCenter, minDistanceFromCenter, maxDistanceFromCenter);
        transform.position = transform.rotation * new Vector3(0, 0, -distanceFromCenter);

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
        rotationVelocity = mouseDelta * rotationSpeed;

    }


    private void ApplyRotation(Vector2 delta){
        Quaternion rotationY = Quaternion.AngleAxis(delta.x, Vector3.up);

        float newVerticalAngle = verticalAngle - delta.y;
        newVerticalAngle = Mathf.Clamp(newVerticalAngle, -90f, 90f);

        float deltaAngle = newVerticalAngle - verticalAngle;
        Quaternion rotationX = Quaternion.AngleAxis(deltaAngle, transform.right);
        verticalAngle = newVerticalAngle;

        transform.rotation = rotationY * rotationX * transform.rotation;
        transform.position = transform.rotation * new Vector3(0, 0, -distanceFromCenter);
    }

}
