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

        if(GUILayout.Button("Run All Tests")){
            isRunning = true;
            taskCompleted = false;
            Thread thread = new Thread(() => {
                AlgorithmsTests.PerformTests();
                taskCompleted = true;
            });
            thread.Start();

            EditorApplication.update += CheckTaskCompletion;
        }

        EditorGUILayout.Separator();

        if(GUILayout.Button("Run Optimization Tests")){
            isRunning = true;
            taskCompleted = false;
            Thread thread = new Thread(() => {
                AlgorithmsTests.PerformOptimizationTests();
                taskCompleted = true;
            });
            thread.Start();

            EditorApplication.update += CheckTaskCompletion;
        }

        EditorGUILayout.Separator();

        if(GUILayout.Button("Run Random Optimization Tests")){
            isRunning = true;
            taskCompleted = false;
            Thread thread = new Thread(() => {
                AlgorithmsTests.PerformRandomOptimizationTests(1000, 1000);
                taskCompleted = true;
            });
            thread.Start();

            EditorApplication.update += CheckTaskCompletion;
        }
        EditorGUILayout.Separator();

        if(GUILayout.Button("Run Random Normalization Tests")){
            isRunning = true;
            taskCompleted = false;
            Thread thread = new Thread(() => {
                AlgorithmsTests.PerformRandomNormalizationTests(1000, 1000);
                taskCompleted = true;
            });
            thread.Start();

            EditorApplication.update += CheckTaskCompletion;
        }
        EditorGUILayout.Separator();

        if(GUILayout.Button("Run Random Scramble Generation Tests")){
            isRunning = true;
            taskCompleted = false;
            Thread thread = new Thread(() => {
                AlgorithmsTests.PerformScrambleGenerationTests(1000, 1000);
                taskCompleted = true;
            });
            thread.Start();
            EditorApplication.update += CheckTaskCompletion;
        }

        EditorGUILayout.Separator();

        if(GUILayout.Button("Run Random Inverse Tests")){
            isRunning = true;
            taskCompleted = false;
            Thread thread = new Thread(() => {
                AlgorithmsTests.PerformRandomInverseTests(1000, 1000);
                taskCompleted = true;
            });
            thread.Start();
            EditorApplication.update += CheckTaskCompletion;
        }

        EditorGUILayout.Separator();

        if(GUILayout.Button("Run Validation Tests")){
            isRunning = true;
            taskCompleted = false;
            Thread thread = new Thread(() => {
                AlgorithmsTests.PerformValidationTests();
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