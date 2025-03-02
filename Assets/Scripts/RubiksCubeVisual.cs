using System;
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

    private List<GameObject> upElements;
    private List<GameObject> downElements;
    private List<GameObject> frontElements;
    private List<GameObject> backElements;
    private List<GameObject> leftElements;
    private List<GameObject> rightElements;

    private Dictionary<GameObject, (Vector3 position, Quaternion rotation)> defaultPositionRotation;

    private List<GameObject> currentRotatingElements;
    private CubeFace currentRotatingFace;

    private Dictionary<List<GameObject>, Vector3> groupAxis;
    private RubiksCube cube;

    private MeshRenderer[,,] colorElements;

    private List<(CubeFace cubeFace, int row, int col)>[] updateColorElements;

    private void Awake(){

        cube = new RubiksCube();
        colorElements = new MeshRenderer[6,3,3];
        updateColorElements = new List<(CubeFace cubeFace, int row, int col)>[6]{new(21),new(21),new(21),new(21),new(21),new(21)};

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

                    BoxCollider collider = cube.GetComponent<BoxCollider>();

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
                        default:
                            sb.Append("Center");
                            cube.transform.SetParent(transform);
                            break;
                    }

                    if(i == -1){
                        leftElements.Add(cube);
                        collider.size = new Vector3(collider.size.x + colorElementThickness / 2, collider.size.y, collider.size.z);
                        collider.center = new Vector3(collider.center.x - colorElementThickness / 4, collider.center.y, collider.center.z);
                        sb.Append(" Left");
                    }
                    else if(i == 1){
                        rightElements.Add(cube);
                        collider.size = new Vector3(collider.size.x + colorElementThickness / 2, collider.size.y, collider.size.z);
                        collider.center = new Vector3(collider.center.x + colorElementThickness / 4, collider.center.y, collider.center.z);
                        sb.Append(" Right");
                    }

                    if(j == -1){
                        downElements.Add(cube);
                        collider.size = new Vector3(collider.size.x, collider.size.y + colorElementThickness / 2, collider.size.z);
                        collider.center = new Vector3(collider.center.x, collider.center.y - colorElementThickness / 4, collider.center.z);
                        sb.Append(" Down");
                    }
                    else if(j == 1){
                        upElements.Add(cube);
                        collider.size = new Vector3(collider.size.x, collider.size.y + colorElementThickness / 2, collider.size.z);
                        collider.center = new Vector3(collider.center.x, collider.center.y + colorElementThickness / 4, collider.center.z);
                        sb.Append(" Up");
                    }

                    if(k == -1){
                        frontElements.Add(cube);
                        collider.size = new Vector3(collider.size.x, collider.size.y, collider.size.z + colorElementThickness / 2);
                        collider.center = new Vector3(collider.center.x, collider.center.y, collider.center.z - colorElementThickness / 4);
                        sb.Append(" Front");
                    }
                    else if(k == 1){
                        backElements.Add(cube);
                        collider.size = new Vector3(collider.size.x, collider.size.y, collider.size.z + colorElementThickness / 2);
                        collider.center = new Vector3(collider.center.x, collider.center.y, collider.center.z + colorElementThickness / 4);
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

            updateColorElements[(int)cubePlace.cubeFace].Add(cubePlace);

            switch(cubePlace.cubeFace){
                case CubeFace.Left:
                    if(cubePlace.row == 0) updateColorElements[(int)CubeFace.Up].Add(cubePlace);
                    else if(cubePlace.row == 2) updateColorElements[(int)CubeFace.Down].Add(cubePlace);
                    if(cubePlace.col == 0) updateColorElements[(int)CubeFace.Back].Add(cubePlace);
                    else if(cubePlace.col == 2) updateColorElements[(int)CubeFace.Front].Add(cubePlace);
                    break;
                case CubeFace.Front:
                    if(cubePlace.row == 0) updateColorElements[(int)CubeFace.Up].Add(cubePlace);
                    else if(cubePlace.row == 2) updateColorElements[(int)CubeFace.Down].Add(cubePlace);
                    if(cubePlace.col == 0) updateColorElements[(int)CubeFace.Left].Add(cubePlace);
                    else if(cubePlace.col == 2) updateColorElements[(int)CubeFace.Right].Add(cubePlace);
                    break;
                case CubeFace.Right:
                    if(cubePlace.row == 0) updateColorElements[(int)CubeFace.Up].Add(cubePlace);
                    else if(cubePlace.row == 2) updateColorElements[(int)CubeFace.Down].Add(cubePlace);
                    if(cubePlace.col == 0) updateColorElements[(int)CubeFace.Front].Add(cubePlace);
                    else if(cubePlace.col == 2) updateColorElements[(int)CubeFace.Back].Add(cubePlace);
                    break;
                case CubeFace.Back:
                    if(cubePlace.row == 0) updateColorElements[(int)CubeFace.Up].Add(cubePlace);
                    else if(cubePlace.row == 2) updateColorElements[(int)CubeFace.Down].Add(cubePlace);
                    if(cubePlace.col == 0) updateColorElements[(int)CubeFace.Right].Add(cubePlace);
                    else if(cubePlace.col == 2) updateColorElements[(int)CubeFace.Left].Add(cubePlace);
                    break;
                case CubeFace.Up:
                    if(cubePlace.row == 0) updateColorElements[(int)CubeFace.Back].Add(cubePlace);
                    else if(cubePlace.row == 2) updateColorElements[(int)CubeFace.Front].Add(cubePlace);
                    if(cubePlace.col == 0) updateColorElements[(int)CubeFace.Left].Add(cubePlace);
                    else if(cubePlace.col == 2) updateColorElements[(int)CubeFace.Right].Add(cubePlace);
                    break;
                case CubeFace.Down:
                    if(cubePlace.row == 0) updateColorElements[(int)CubeFace.Front].Add(cubePlace);
                    else if(cubePlace.row == 2) updateColorElements[(int)CubeFace.Up].Add(cubePlace);
                    if(cubePlace.col == 0) updateColorElements[(int)CubeFace.Left].Add(cubePlace);
                    else if(cubePlace.col == 2) updateColorElements[(int)CubeFace.Right].Add(cubePlace);
                    break;
                default:
                    throw new ArgumentException("Cube face parameter is wrong", nameof(cubePlace.cubeFace));
            }
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
                AddColorElement(cubes[currentBlockIndex], (CubeFace.Left, 2-(i+1), 2-(j+1)), new Vector3(-1.5f * elementScale, i * elementScale, j * elementScale), new Vector3(colorElementThickness, colorElementSide, colorElementSide));
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
                AddColorElement(cubes[currentBlockIndex], (CubeFace.Back, 2-(j+1), 2-(i+1)), new Vector3(i * elementScale, j * elementScale, 1.5f * elementScale), new Vector3(colorElementSide, colorElementSide, colorElementThickness));
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
        currentRotatingFace = CubeFace.Up;

    }

    [ContextMenu("Rotate Right")]
    private void RotateRight(){

        targetRotationAngle = 90f;
        EnableRotation(rightElements);
        cube.DoRotation(CubeFace.Right, 1);
        currentRotatingFace = CubeFace.Right;

    }

    [ContextMenu("Rotate Front")]
    private void RotateFront(){
        
        targetRotationAngle = 90f;
        EnableRotation(frontElements);
        cube.DoRotation(CubeFace.Front, 1);
        currentRotatingFace = CubeFace.Front;

    }
    [ContextMenu("Rotate Left")]
    private void RotateLeft(){

        targetRotationAngle = 90f;
        EnableRotation(leftElements);
        cube.DoRotation(CubeFace.Left, 1);
        currentRotatingFace = CubeFace.Left;

    }
    [ContextMenu("Rotate Down")]
    private void RotateDown(){

        targetRotationAngle = 90f;
        EnableRotation(downElements);
        cube.DoRotation(CubeFace.Down, 1);
        currentRotatingFace = CubeFace.Down;

    }

    [ContextMenu("Rotate Back")]
    private void RotateBack(){

        targetRotationAngle = 90f;
        EnableRotation(backElements);
        cube.DoRotation(CubeFace.Back, 1);
        currentRotatingFace = CubeFace.Back;

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
    private void UpdateVisual(CubeFace rotatedCubeFace){
        for(int i = 0;i<updateColorElements[(int)rotatedCubeFace].Count;i++){
            int cubeFace = (int)updateColorElements[(int)rotatedCubeFace][i].cubeFace;
            int row = (int)updateColorElements[(int)rotatedCubeFace][i].row;
            int col = (int)updateColorElements[(int)rotatedCubeFace][i].col;
            colorElements[cubeFace, row, col].material = GetColorMaterial(cube[(CubeFace)cubeFace, row, col]);
        }
    }

    private void Update(){
        if(isRotating){
            currentRotationTime += Time.deltaTime;
            float currentRotationProgress = rotateAnimationCurve.Evaluate(currentRotationTime / rotationDuration);

            if(currentRotationProgress >= 1){
                isRotating = false;
                SetDefaultPosition(currentRotatingElements);
                UpdateVisual(currentRotatingFace);
            }
            else{
                float angle = Mathf.Lerp(0f, targetRotationAngle, currentRotationProgress) - currentRotation;
                currentRotation += angle;
                RotateSide(currentRotatingElements, angle);
            }

        }
    }

}
