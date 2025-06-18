using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CFOPSolver;
using KociembaSolver;
using UnityEngine;
using UnityEngine.UI;

public class MainCanvas : MonoBehaviour{

    [SerializeField] private RubiksCubeVisual rubiksCubeVisual;

    [SerializeField] private Toggle kociembaRadioButton;
    [SerializeField] private Toggle cfopRadioButton;

    private void Start(){

    }

    private void Awake(){
        RuntimeHelpers.RunClassConstructor(typeof(Kociemba).TypeHandle); // because persistentDataPath has to be accessed from main thread
    }
    public void ScrambleCube(){
        string scramble = Algorithms.GenerateScramble(25);
        rubiksCubeVisual.PerformScramble(scramble);
    }

    public async void SolveCube(){

        string solution = "";

        if(kociembaRadioButton.isOn){
            solution = await Task.Run(() => Kociemba.Solution(rubiksCubeVisual.State));
        }
        else{
            solution = await Task.Run(() => CFOP.Solution(rubiksCubeVisual.State));
        }

        rubiksCubeVisual.PerformScramble(solution);

    }
}
