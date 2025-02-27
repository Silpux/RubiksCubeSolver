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

    private List<GameObject> upElements = new();
    private List<GameObject> downElements = new();
    private List<GameObject> frontElements = new();
    private List<GameObject> backElements = new();
    private List<GameObject> leftElements = new();
    private List<GameObject> rightElements = new();

    private void Awake(){

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

                    if(i == -1) sb.Append(" Left");
                    else if(i == 1) sb.Append(" Right");

                    if(j == -1) sb.Append(" Down");
                    else if(j == 1) sb.Append(" Up");

                    if(k == -1) sb.Append(" Front");
                    else if(k == 1) sb.Append(" Back");
                    cube.transform.name = sb.ToString();

                    void AddColorElement(Material material, Vector3 position, Vector3 scale, string name){
                        GameObject colorElement = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        colorElement.transform.position = position;
                        colorElement.transform.localScale = scale;
                        colorElement.GetComponent<MeshRenderer>().material = material;
                        colorElement.transform.SetParent(cube.transform);
                        colorElement.transform.name = name;
                    }

                    if(i == -1){
                        leftElements.Add(cube);
                        AddColorElement(leftMaterial, new Vector3(i * 1.5f * elementScale, j * elementScale, k * elementScale), new Vector3(colorElementThickness, colorElementSide, colorElementSide), "Left");
                    }
                    else if(i == 1){
                        rightElements.Add(cube);
                        AddColorElement(rightMaterial, new Vector3(i * 1.5f * elementScale, j * elementScale, k * elementScale), new Vector3(colorElementThickness, colorElementSide, colorElementSide), "Right");
                    }

                    if(j == -1){
                        downElements.Add(cube);
                        AddColorElement(downMaterial, new Vector3(i * elementScale, j * 1.5f * elementScale, k * elementScale), new Vector3(colorElementSide, colorElementThickness, colorElementSide), "Down");
                    }
                    else if(j == 1){
                        upElements.Add(cube);
                        AddColorElement(upMaterial, new Vector3(i * elementScale, j * 1.5f * elementScale, k * elementScale), new Vector3(colorElementSide, colorElementThickness, colorElementSide), "Up");
                    }

                    if(k == -1){
                        frontElements.Add(cube);
                        AddColorElement(frontMaterial, new Vector3(i * elementScale, j * elementScale, k * 1.5f * elementScale), new Vector3(colorElementSide, colorElementSide, colorElementThickness), "Front");
                    }
                    else if(k == 1){
                        backElements.Add(cube);
                        AddColorElement(backMaterial, new Vector3(i * elementScale, j * elementScale, k * 1.5f * elementScale), new Vector3(colorElementSide, colorElementSide, colorElementThickness), "Back");
                    }

                }
            }
        }

    }

    private void Update(){
        
    }

}
