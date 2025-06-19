using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CFOPSolver;
using KociembaSolver;
using UnityEngine;
using UnityEngine.UI;
using SFB;
using System.IO;
using TMPro;
using System.Text.RegularExpressions;
using System.Text;
using System;

public class MainCanvas : MonoBehaviour{

    [SerializeField] private RubiksCubeVisual rubiksCubeVisual;
    [SerializeField] private CameraInputHandler cameraInputHandler;

    [SerializeField] private TextMeshProUGUI currentAlgorithmText;
    private string currentAlgorithm;

    private bool scrambleMode = false;

    [SerializeField] private GameObject solveCubeButtons;
    [SerializeField] private GameObject paintCubeButtons;

    [SerializeField] private Toggle kociembaRadioButton;
    [SerializeField] private Toggle cfopRadioButton;

    [SerializeField] private Toggle redPaintToggle;
    [SerializeField] private Toggle orangePaintToggle;
    [SerializeField] private Toggle bluePaintToggle;
    [SerializeField] private Toggle greenPaintToggle;
    [SerializeField] private Toggle whitePaintToggle;
    [SerializeField] private Toggle yellowPaintToggle;

    [SerializeField] private Sprite selectedSprite;
    [SerializeField] private Sprite notSelectedSprite;

    private CubeFace currentPaintColor = CubeFace.Right;

    private bool isPaintMode;

    private void Start(){
        redPaintToggle.onValueChanged.AddListener(ColorToggle);
        orangePaintToggle.onValueChanged.AddListener(ColorToggle);
        greenPaintToggle.onValueChanged.AddListener(ColorToggle);
        bluePaintToggle.onValueChanged.AddListener(ColorToggle);
        whitePaintToggle.onValueChanged.AddListener(ColorToggle);
        yellowPaintToggle.onValueChanged.AddListener(ColorToggle);

        kociembaRadioButton.onValueChanged.AddListener(SolveModeToggle);
    }

    private void Awake(){
        RuntimeHelpers.RunClassConstructor(typeof(Kociemba).TypeHandle); // because persistentDataPath has to be accessed from main thread
        rubiksCubeVisual.OnMoveFinished += ColorAlgorithmText;
    }

    private void ColorAlgorithmText(int completedMoves){

        StringBuilder sb = new StringBuilder();

        string[] moves = currentAlgorithm.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        if(scrambleMode){
            sb.Append("Scramble:\n");
        }
        else{
            sb.Append("Solution:\n");
        }

        sb.Append("<color=green>");
        for(int i = 0;i<completedMoves;i++){
            sb.Append(moves[i] + " ");
        }
        sb.Append("</color>");
        for(int i = completedMoves;i<moves.Length;i++){
            sb.Append(moves[i] + " ");
        }

        currentAlgorithmText.text = sb.ToString();
    }

    public void SetAnimationSpeed(float speed){
        rubiksCubeVisual.RotationSpeed = speed;
    }

    public void SetPaintMode(){
        isPaintMode = !isPaintMode;

        paintCubeButtons.SetActive(isPaintMode);
        solveCubeButtons.SetActive(!isPaintMode);

        cameraInputHandler.SetPaintMode(isPaintMode);
    }

    public void SolveModeToggle(bool toggle){

        kociembaRadioButton.GetComponent<ToggleItem>().SetSprite(notSelectedSprite);
        cfopRadioButton.GetComponent<ToggleItem>().SetSprite(notSelectedSprite);

        if(kociembaRadioButton.isOn){
            kociembaRadioButton.GetComponent<ToggleItem>().SetSprite(selectedSprite);
        }
        else{
            cfopRadioButton.GetComponent<ToggleItem>().SetSprite(selectedSprite);
        }

    }

    public void ColorToggle(bool toggle){

        redPaintToggle.GetComponent<ToggleItem>().SetSprite(notSelectedSprite);
        orangePaintToggle.GetComponent<ToggleItem>().SetSprite(notSelectedSprite);
        greenPaintToggle.GetComponent<ToggleItem>().SetSprite(notSelectedSprite);
        bluePaintToggle.GetComponent<ToggleItem>().SetSprite(notSelectedSprite);
        whitePaintToggle.GetComponent<ToggleItem>().SetSprite(notSelectedSprite);
        yellowPaintToggle.GetComponent<ToggleItem>().SetSprite(notSelectedSprite);

        if(redPaintToggle.isOn){
            currentPaintColor = CubeFace.Right;
            redPaintToggle.GetComponent<ToggleItem>().SetSprite(selectedSprite);
        }
        else if(orangePaintToggle.isOn){
            currentPaintColor = CubeFace.Left;
            orangePaintToggle.GetComponent<ToggleItem>().SetSprite(selectedSprite);
        }
        else if(greenPaintToggle.isOn){
            currentPaintColor = CubeFace.Front;
            greenPaintToggle.GetComponent<ToggleItem>().SetSprite(selectedSprite);
        }
        else if(bluePaintToggle.isOn){
            currentPaintColor = CubeFace.Back;
            bluePaintToggle.GetComponent<ToggleItem>().SetSprite(selectedSprite);
        }
        else if(whitePaintToggle.isOn){
            currentPaintColor = CubeFace.Up;
            whitePaintToggle.GetComponent<ToggleItem>().SetSprite(selectedSprite);
        }
        else{
            currentPaintColor = CubeFace.Down;
            yellowPaintToggle.GetComponent<ToggleItem>().SetSprite(selectedSprite);
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

        if(!rubiksCubeVisual.IsScrambling && !rubiksCubeVisual.IsRotating){
            scrambleMode = true;
            string scramble = Algorithms.GenerateScramble(25);
            currentAlgorithm = scramble;

            currentAlgorithmText.text = $"Scramble:\n{scramble}";

            rubiksCubeVisual.PerformScramble(scramble);
        }
    }

    public async void SolveCube(){

        if(!rubiksCubeVisual.IsScrambling && !rubiksCubeVisual.IsRotating){
            scrambleMode = false;
            string solution = "";

            if(!rubiksCubeVisual.VerifyCube(out string error)){
                currentAlgorithmText.text = error;
                return;
            }

            if(kociembaRadioButton.isOn){
                solution = await Task.Run(() => Kociemba.Solution(rubiksCubeVisual.State));
            }
            else{
                solution = await Task.Run(() => CFOP.Solution(rubiksCubeVisual.State));
            }

            if(solution.Length == 0){
                currentAlgorithmText.text = "Already solved!";
                return;
            }

            currentAlgorithm = solution;
            currentAlgorithmText.text = $"Solution:\n{solution}";
            rubiksCubeVisual.PerformScramble(solution);
        }

    }
}
