using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class RubiksCubeVisual : MonoBehaviour{

    [SerializeField] private Material cubeMaterial;
    [SerializeField] private Material upMaterial;
    [SerializeField] private Material downMaterial;
    [SerializeField] private Material frontMaterial;
    [SerializeField] private Material backMaterial;
    [SerializeField] private Material leftMaterial;
    [SerializeField] private Material rightMaterial;

    [SerializeField] private float elementScale;
    [SerializeField] private float colorElementSide;
    [SerializeField] private float colorElementThickness;

    [SerializeField] private float rotationDuration;
    [SerializeField] private AnimationCurve rotateAnimationCurve;

    private float currentRotationTime;
    private float currentRotation;

    private float targetRotationAngle;
    private bool isRotating;

    private List<GameObject> upElements = new();
    private List<GameObject> downElements = new();
    private List<GameObject> frontElements = new();
    private List<GameObject> backElements = new();
    private List<GameObject> leftElements = new();
    private List<GameObject> rightElements = new();

    private Dictionary<GameObject, (Vector3 position, Quaternion rotation)> defaultPositionRotation = new();

    private List<GameObject> currentRotatingElements;

    private Dictionary<List<GameObject>, Vector3> groupAxis;

    private void Awake(){

        groupAxis = new Dictionary<List<GameObject>, Vector3>(){
            [upElements] = Vector3.up,
            [downElements] = Vector3.down,
            [leftElements] = Vector3.left,
            [rightElements] = Vector3.right,
            [backElements] = Vector3.forward,
            [frontElements] = Vector3.back,
        };

        GameObject cornersParent = new GameObject("Corners");
        cornersParent.transform.SetParent(transform);
        GameObject edgesParent = new GameObject("Edges");
        edgesParent.transform.SetParent(transform);
        GameObject centersParent = new GameObject("Centers");
        centersParent.transform.SetParent(transform);

        for(int i = -1;i<=1;i++){
            for(int j = -1;j<=1;j++){
                for(int k = -1;k<=1;k++){

                    if(i == j && j == k && k == 0) continue;

                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.position = new Vector3(i * elementScale,j * elementScale,k * elementScale);
                    cube.transform.localScale = new Vector3(elementScale, elementScale, elementScale);

                    defaultPositionRotation[cube] = (cube.transform.position, cube.transform.rotation);

                    cube.GetComponent<MeshRenderer>().material = cubeMaterial;

                    StringBuilder sb = new(15);

                    switch((i&1) + (j&1) + (k&1)){
                        case 1:
                            sb.Append("Center");
                            cube.transform.SetParent(centersParent.transform);
                            break;
                        case 2:
                            sb.Append("Edge");
                            cube.transform.SetParent(edgesParent.transform);
                            break;
                        case 3:
                            sb.Append("Corner");
                            cube.transform.SetParent(cornersParent.transform);
                            break;
                    }

                    void AddColorElement(List<GameObject> elementList, Material material, Vector3 position, Vector3 scale, string name){
                        elementList.Add(cube);
                        GameObject colorElement = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        colorElement.transform.position = position;
                        colorElement.transform.localScale = scale;
                        colorElement.GetComponent<MeshRenderer>().material = material;
                        colorElement.transform.SetParent(cube.transform);
                        colorElement.transform.name = name;
                    }

                    if(i == -1){
                        AddColorElement(leftElements, leftMaterial, new Vector3(i * 1.5f * elementScale, j * elementScale, k * elementScale), new Vector3(colorElementThickness, colorElementSide, colorElementSide), "Left");
                        sb.Append(" Left");
                    }
                    else if(i == 1){
                        AddColorElement(rightElements, rightMaterial, new Vector3(i * 1.5f * elementScale, j * elementScale, k * elementScale), new Vector3(colorElementThickness, colorElementSide, colorElementSide), "Right");
                        sb.Append(" Right");
                    }

                    if(j == -1){
                        AddColorElement(downElements, downMaterial, new Vector3(i * elementScale, j * 1.5f * elementScale, k * elementScale), new Vector3(colorElementSide, colorElementThickness, colorElementSide), "Down");
                        sb.Append(" Down");
                    }
                    else if(j == 1){
                        AddColorElement(upElements, upMaterial, new Vector3(i * elementScale, j * 1.5f * elementScale, k * elementScale), new Vector3(colorElementSide, colorElementThickness, colorElementSide), "Up");
                        sb.Append(" Up");
                    }

                    if(k == -1){
                        AddColorElement(frontElements, frontMaterial, new Vector3(i * elementScale, j * elementScale, k * 1.5f * elementScale), new Vector3(colorElementSide, colorElementSide, colorElementThickness), "Front");
                        sb.Append(" Front");
                    }
                    else if(k == 1){
                        AddColorElement(backElements, backMaterial, new Vector3(i * elementScale, j * elementScale, k * 1.5f * elementScale), new Vector3(colorElementSide, colorElementSide, colorElementThickness), "Back");
                        sb.Append(" Back");
                    }

                    cube.transform.name = sb.ToString();

                }
            }
        }

    }

    private void RotateSide(List<GameObject> objects, float angle){
        Quaternion rotation = Quaternion.AngleAxis(angle, groupAxis[objects]);

        foreach(GameObject obj in objects){
            Vector3 direction = obj.transform.position;
            obj.transform.position = rotation * direction;
            obj.transform.rotation = rotation * obj.transform.rotation;
        }
    }

    [ContextMenu("Rotate Up")]
    private void RotateUp(){
        
        targetRotationAngle = 90f;
        currentRotatingElements = upElements;
        currentRotationTime = 0;
        currentRotation = 0;
        isRotating = true;

    }

    [ContextMenu("Rotate Right")]
    private void RotateRight(){

        targetRotationAngle = 90f;
        currentRotatingElements = rightElements;
        currentRotationTime = 0;
        currentRotation = 0;
        isRotating = true;

    }

    private void SetDefaultPosition(List<GameObject> elements){

        foreach(var obj in elements){
            obj.transform.position = defaultPositionRotation[obj].position;
            obj.transform.rotation = defaultPositionRotation[obj].rotation;
        }

    }

    private void Update(){
        if(isRotating){
            currentRotationTime += Time.deltaTime;
            float currentRotationProgress = rotateAnimationCurve.Evaluate(currentRotationTime / rotationDuration);

            if(currentRotationProgress >= 1){
                isRotating = false;
                SetDefaultPosition(currentRotatingElements);
            }
            else{
                float angle = Mathf.Lerp(0f, targetRotationAngle, currentRotationProgress) - currentRotation;
                currentRotation += angle;
                RotateSide(currentRotatingElements, angle);
            }

        }
    }

}
