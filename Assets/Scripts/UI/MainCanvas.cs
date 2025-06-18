using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CFOPSolver;
using KociembaSolver;
using UnityEngine;
using UnityEngine.UI;
using SFB;
using System.IO;

public class MainCanvas : MonoBehaviour{

    [SerializeField] private RubiksCubeVisual rubiksCubeVisual;

    [SerializeField] private Toggle kociembaRadioButton;
    [SerializeField] private Toggle cfopRadioButton;

    private void Start(){

    }

    private void Awake(){
        RuntimeHelpers.RunClassConstructor(typeof(Kociemba).TypeHandle); // because persistentDataPath has to be accessed from main thread
    }


    public void SaveCubeState(){

        if(!rubiksCubeVisual.IsRotating && !rubiksCubeVisual.IsScrambling){
            var path = StandaloneFileBrowser.SaveFilePanel("Save state", "", "cube", "txt");
            if(!string.IsNullOrEmpty(path)){
                File.WriteAllText(path, rubiksCubeVisual.State);
            }
        }

    }

    public void LoadCubeState(){

        if(!rubiksCubeVisual.IsRotating && !rubiksCubeVisual.IsScrambling){
            var paths = StandaloneFileBrowser.OpenFilePanel("Open cube state", "", "txt", false);
            if(paths.Length > 0 && File.Exists(paths[0])){
                string content = File.ReadAllText(paths[0]);
                rubiksCubeVisual.LoadCubeState(content);
            }
        }

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
