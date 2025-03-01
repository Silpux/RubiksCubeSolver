using System;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
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

    private List<GameObject> upElements;
    private List<GameObject> downElements;
    private List<GameObject> frontElements;
    private List<GameObject> backElements;
    private List<GameObject> leftElements;
    private List<GameObject> rightElements;

    private Dictionary<GameObject, (Vector3 position, Quaternion rotation)> defaultPositionRotation;

    private List<GameObject> currentRotatingElements;

    private Dictionary<List<GameObject>, Vector3> groupAxis;
    private RubiksCube cube;

    private MeshRenderer[,,] colorElements;

    private void Awake(){

        cube = new RubiksCube();
        colorElements = new MeshRenderer[6,3,3];

        defaultPositionRotation = new();

        upElements = new();
        downElements = new();
        frontElements = new();
        backElements = new();
        leftElements = new();
        rightElements = new();

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

        List<GameObject> cubes = new List<GameObject>();

        for(int i = -1;i<=1;i++){
            for(int j = -1;j<=1;j++){
                for(int k = -1;k<=1;k++){

                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.position = new Vector3(i * elementScale,j * elementScale,k * elementScale);
                    cube.transform.localScale = new Vector3(elementScale, elementScale, elementScale);

                    cubes.Add(cube);

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

                    if(i == -1){
                        leftElements.Add(cube);
                        sb.Append(" Left");
                    }
                    else if(i == 1){
                        rightElements.Add(cube);
                        sb.Append(" Right");
                    }

                    if(j == -1){
                        downElements.Add(cube);
                        sb.Append(" Down");
                    }
                    else if(j == 1){
                        upElements.Add(cube);
                        sb.Append(" Up");
                    }

                    if(k == -1){
                        frontElements.Add(cube);
                        sb.Append(" Front");
                    }
                    else if(k == 1){
                        backElements.Add(cube);
                        sb.Append(" Back");
                    }

                    cube.transform.name = sb.ToString();

                }
            }
        }

        void AddColorElement(GameObject cube, (CubeFace cubeFace, int row, int col) cubePlace, Vector3 position, Vector3 scale){
            GameObject colorElement = GameObject.CreatePrimitive(PrimitiveType.Cube);
            colorElement.transform.position = position;
            colorElement.transform.localScale = scale;
            MeshRenderer meshRenderer = colorElement.GetComponent<MeshRenderer>();
            meshRenderer.material = GetFaceMaterial(cubePlace.cubeFace);
            colorElement.transform.SetParent(cube.transform);
            colorElement.transform.name = cubePlace.cubeFace.ToString();
            colorElements[(int)cubePlace.cubeFace, cubePlace.row, cubePlace.col] = meshRenderer;
        }

        int currentBlockIndex = 6;

        for(int j = 1;j>=-1;j--){
            for(int i = -1;i<=1;i++){

                AddColorElement(cubes[currentBlockIndex], (CubeFace.Front, 2-(j+1), i+1), new Vector3(i * elementScale, j * elementScale, -1.5f * elementScale), new Vector3(colorElementSide, colorElementSide, colorElementThickness));
                currentBlockIndex += 9;

            }
            currentBlockIndex -= 30;
        }

        currentBlockIndex = 8;
        for(int i = 1;i>=-1;i--){
            for(int j = 1;j>=-1;j--){

                AddColorElement(cubes[currentBlockIndex], (CubeFace.Left, 2-(i+1), j+1), new Vector3(-1.5f * elementScale, i * elementScale, j * elementScale), new Vector3(colorElementThickness, colorElementSide, colorElementSide));
                currentBlockIndex -= 1;

            }
        }

        currentBlockIndex = 24;
        for(int i = 1;i>=-1;i--){
            for(int j = -1;j<=1;j++){

                AddColorElement(cubes[currentBlockIndex], (CubeFace.Right, 2-(i+1), j+1), new Vector3(1.5f * elementScale, i * elementScale, j * elementScale), new Vector3(colorElementThickness, colorElementSide, colorElementSide));
                currentBlockIndex += 1;

            }
            currentBlockIndex -= 6;
        }

        currentBlockIndex = 8;
        for(int j = 1;j>=-1;j--){
            for(int i = -1;i<=1;i++){

                AddColorElement(cubes[currentBlockIndex], (CubeFace.Up, 2-(j+1), i+1), new Vector3(i * elementScale, 1.5f * elementScale, j * elementScale), new Vector3(colorElementSide, colorElementThickness, colorElementSide));
                currentBlockIndex += 9;

            }
            currentBlockIndex -= 28;
        }


        currentBlockIndex = 26;

        for(int j = 1;j>=-1;j--){
            for(int i = 1;i>=-1;i--){

                AddColorElement(cubes[currentBlockIndex], (CubeFace.Back, 2-(j+1), i+1), new Vector3(i * elementScale, j * elementScale, 1.5f * elementScale), new Vector3(colorElementSide, colorElementSide, colorElementThickness));
                currentBlockIndex -= 9;

            }
            currentBlockIndex += 24;
        }


        currentBlockIndex = 0;
        for(int j = -1;j<=1;j++){
            for(int i = -1;i<=1;i++){

                AddColorElement(cubes[currentBlockIndex], (CubeFace.Down, j+1, i+1), new Vector3(i * elementScale, -1.5f * elementScale, j * elementScale), new Vector3(colorElementSide, colorElementThickness, colorElementSide));
                currentBlockIndex += 9;

            }
            currentBlockIndex -= 26;
        }

            UpdateVisual();

    }

    private Material GetFaceMaterial(CubeFace cubeFace){
        return cubeFace switch{
            CubeFace.Left => leftMaterial,
            CubeFace.Front => frontMaterial,
            CubeFace.Right => rightMaterial,
            CubeFace.Back => backMaterial,
            CubeFace.Up => upMaterial,
            CubeFace.Down => downMaterial,
            _ => throw new ArgumentException("Wrong cube face paramter", nameof(cubeFace))
        };
    }

    private Material GetColorMaterial(CubeColor cubeColor){
        return cubeColor switch{
            CubeColor.Orange => leftMaterial,
            CubeColor.Green => frontMaterial,
            CubeColor.Red => rightMaterial,
            CubeColor.Blue => backMaterial,
            CubeColor.White => upMaterial,
            CubeColor.Yellow => downMaterial,
            _ => throw new ArgumentException("Wrong cube color paramter", nameof(cubeColor))
        };
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
        EnableRotation(upElements);
        cube.DoRotation(CubeFace.Up, 1);

    }

    [ContextMenu("Rotate Right")]
    private void RotateRight(){

        targetRotationAngle = 90f;
        EnableRotation(rightElements);
        cube.DoRotation(CubeFace.Right, 1);

    }

    private void EnableRotation(List<GameObject> elements){
        currentRotatingElements = elements;
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

    private void UpdateVisual(){
        for(int i = 0;i<6;i++){
            for(int j = 0;j<3;j++){
                for(int k = 0;k<3;k++){
                    colorElements[i,j,k].material = GetColorMaterial(cube[(CubeFace)i,j,k]);
                }
            }
        }
    }

    private void Update(){
        if(isRotating){
            currentRotationTime += Time.deltaTime;
            float currentRotationProgress = rotateAnimationCurve.Evaluate(currentRotationTime / rotationDuration);

            if(currentRotationProgress >= 1){
                isRotating = false;
                SetDefaultPosition(currentRotatingElements);
                UpdateVisual();
            }
            else{
                float angle = Mathf.Lerp(0f, targetRotationAngle, currentRotationProgress) - currentRotation;
                currentRotation += angle;
                RotateSide(currentRotatingElements, angle);
            }

        }
    }

}
