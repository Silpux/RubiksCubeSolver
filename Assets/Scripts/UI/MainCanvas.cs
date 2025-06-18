using UnityEngine;

public class MainCanvas : MonoBehaviour{

    [SerializeField] private RubiksCubeVisual rubiksCubeVisual;


    public void ScrambleCube(){

        string scramble = Algorithms.GenerateScramble(25);

        rubiksCubeVisual.PerformScramble(scramble);

    }
}
