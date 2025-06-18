using System;
using System.Collections.Generic;
using System.Linq;
using KociembaSolver;
using UnityEngine;

public class ColorElement : MonoBehaviour{

    public RubiksCubeVisual Visual{private get; set;}

    [SerializeField] private float highlightDarkFactor;

    private Material defaultMaterial;

    private MeshRenderer meshRenderer;

    private bool isHighlight;

    public event Action<CubeFace> OnColorChange = delegate{ };

    public List<(Vector3 direction, CubeFace cubeFace, bool clockwise)> RotateDirections{
        get;
        private set;
    }

    public void AddMoveElement(Vector3 direction, CubeFace cubeFace, bool clockwise){
        RotateDirections.Add((direction, cubeFace, clockwise));
        RotateDirections.Add((direction * -1, cubeFace, !clockwise));
    }

    private void Awake(){
        RotateDirections = new List<(Vector3 direction, CubeFace cubeFace, bool clockwise)>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void DoMove(Vector3 direction, bool doubleTurn){
        var item = RotateDirections.FirstOrDefault(x => x.direction == direction);
        if(item.direction != Vector3.zero){
            Visual.DoRotation(item.cubeFace, item.clockwise, doubleTurn);
        }
    }

    public void SetColor(CubeFace newColor){
        OnColorChange?.Invoke(newColor);
    }

    public void Highlight(){
        if(!isHighlight && !Visual.IsRotating){
            defaultMaterial = new Material(meshRenderer.material);
            Material newMaterial = new Material(meshRenderer.material);
            newMaterial.color *= highlightDarkFactor;
            meshRenderer.material = newMaterial;
            isHighlight = true;
        }
    }

    public void Lowlight(){
        if(isHighlight && !Visual.IsRotating){
            meshRenderer.material = defaultMaterial;
            isHighlight = false;
        }
    }

    private void Start(){
        
    }

    private void Update(){
        
    }

}
