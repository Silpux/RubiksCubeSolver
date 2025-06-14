using System.Threading;
using UnityEditor;
using UnityEngine;

public class AlgorithmsTestRunnerWindow : EditorWindow{

    private static bool isRunning = false;
    private static bool taskCompleted = false;

    [MenuItem("Tools/Algorithms tests")]
    private static void ShowWindow(){
        GetWindow<AlgorithmsTestRunnerWindow>("Algorithms tests");
    }

    private void OnGUI(){

        GUI.enabled = !isRunning;

        if(GUILayout.Button("Run Tests")){

            isRunning = true;
            taskCompleted = false;

            Thread thread = new Thread(() => {

                AlgorithmsTests.PerformTests();

                taskCompleted = true;
            });
            thread.Start();

            EditorApplication.update += CheckTaskCompletion;
        }

        GUI.enabled = true;

        if(isRunning){
            GUILayout.Label("Running tests...");
        }

    }

    private void CheckTaskCompletion(){
        if(taskCompleted){
            isRunning = false;
            EditorApplication.update -= CheckTaskCompletion;
            Repaint();
        }
    }
}