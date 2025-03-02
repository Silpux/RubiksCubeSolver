using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotator : MonoBehaviour{

    [SerializeField] private float rotationSpeed = 20f;
    [SerializeField] private float dampingFactor = 15f;

    [SerializeField] private float minDistanceFromCenter = 5f;
    [SerializeField] private float maxDistanceFromCenter = 15f;

    private float verticalAngle;
    private float distanceFromCenter;

    private CameraInputHandler cameraInputHandler;

    private Vector2 rotationVelocity = Vector2.zero;

    private void Awake(){
        cameraInputHandler = GetComponent<CameraInputHandler>();
        verticalAngle = transform.rotation.eulerAngles.x;
        distanceFromCenter = Vector3.Distance(transform.position, Vector3.zero);
    }

    private void OnEnable(){
        cameraInputHandler.OnCameraMove += Move;
        cameraInputHandler.OnZoom += Zoom;
    }

    private void OnDisable(){
        cameraInputHandler.OnCameraMove -= Move;
        cameraInputHandler.OnZoom -= Zoom;
    }

    private void Update(){
        rotationVelocity = Vector2.Lerp(Vector2.zero, rotationVelocity, Time.deltaTime * dampingFactor);

        if(rotationVelocity.sqrMagnitude > 0.0001f){
            ApplyRotation(rotationVelocity);
        }
    }

    private void Zoom(int zoom){

        distanceFromCenter -= zoom / 2f;
        distanceFromCenter = Mathf.Clamp(distanceFromCenter, minDistanceFromCenter, maxDistanceFromCenter);
        transform.position = transform.rotation * new Vector3(0, 0, -distanceFromCenter);

    }

    public void Move(Vector2 value){

        rotationVelocity = value * rotationSpeed;

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
