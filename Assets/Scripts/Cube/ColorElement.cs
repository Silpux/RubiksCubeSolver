using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ColorElement : MonoBehaviour{

    public RubiksCubeVisual Visual{private get; set;}


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
    }

    public void DoMove(Vector3 direction){
        var item = RotateDirections.FirstOrDefault(x => x.direction == direction);
        if(item.direction != Vector3.zero){
            Visual.DoRotation(item.cubeFace, item.clockwise);
        }
    }

    private void Start(){
        
    }

    private void Update(){
        
    }

}
