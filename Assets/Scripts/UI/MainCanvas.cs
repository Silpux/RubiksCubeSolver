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
    [SerializeField] private CameraInputHandler cameraInputHandler;

    [SerializeField] private Toggle kociembaRadioButton;
    [SerializeField] private Toggle cfopRadioButton;

    [SerializeField] private Toggle redPaintToggle;
    [SerializeField] private Toggle orangePaintToggle;
    [SerializeField] private Toggle bluePaintToggle;
    [SerializeField] private Toggle greenPaintToggle;
    [SerializeField] private Toggle whitePaintToggle;
    [SerializeField] private Toggle yellowPaintToggle;

    private CubeFace currentPaintColor = CubeFace.Right;

    private bool isPaintMode;

    private void Start(){
        redPaintToggle.onValueChanged.AddListener(ColorToggle);
        orangePaintToggle.onValueChanged.AddListener(ColorToggle);
        greenPaintToggle.onValueChanged.AddListener(ColorToggle);
        bluePaintToggle.onValueChanged.AddListener(ColorToggle);
        whitePaintToggle.onValueChanged.AddListener(ColorToggle);
        yellowPaintToggle.onValueChanged.AddListener(ColorToggle);
    }

    private void Awake(){
        RuntimeHelpers.RunClassConstructor(typeof(Kociemba).TypeHandle); // because persistentDataPath has to be accessed from main thread
    }

    public void SetAnimationSpeed(float speed){
        rubiksCubeVisual.RotationSpeed = speed;
    }

    public void SetPaintMode(){
        isPaintMode = !isPaintMode;
        cameraInputHandler.SetPaintMode(isPaintMode);
    }

    public void ColorToggle(bool toggle){

        if(redPaintToggle.isOn){
            currentPaintColor = CubeFace.Right;
        }
        else if(orangePaintToggle.isOn){
            currentPaintColor = CubeFace.Left;
        }
        else if(greenPaintToggle.isOn){
            currentPaintColor = CubeFace.Front;
        }
        else if(bluePaintToggle.isOn){
            currentPaintColor = CubeFace.Back;
        }
        else if(whitePaintToggle.isOn){
            currentPaintColor = CubeFace.Up;
        }
        else{
            currentPaintColor = CubeFace.Down;
        }

        cameraInputHandler.PaintColor = currentPaintColor;

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

    public void ResetCubeState(){

        if(!rubiksCubeVisual.IsRotating && !rubiksCubeVisual.IsScrambling){

            rubiksCubeVisual.Reset();

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
