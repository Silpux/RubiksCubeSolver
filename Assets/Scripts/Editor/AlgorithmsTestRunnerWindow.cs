using System;
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

        DrawTestButton("Run All Tests", AlgorithmsTests.PerformTests);
        DrawTestButton("Run Optimization Tests", AlgorithmsTests.PerformOptimizationTests);
        DrawTestButton("Run Random Optimization Tests", () => AlgorithmsTests.PerformRandomOptimizationTests(1000, 1000));
        DrawTestButton("Run Random Normalization Tests", () => AlgorithmsTests.PerformRandomNormalizationTests(1000, 1000));
        DrawTestButton("Run Random Scramble Generation Tests", () => AlgorithmsTests.PerformScrambleGenerationTests(1000, 1000));
        DrawTestButton("Run Random Inverse Tests", () => AlgorithmsTests.PerformRandomInverseTests(1000, 1000));
        DrawTestButton("Run Validation Tests", AlgorithmsTests.PerformValidationTests);

        GUI.enabled = true;

        if(isRunning){
            GUILayout.Label("Running tests...");
        }

    }
    private void DrawTestButton(string label, Action testAction){
        EditorGUILayout.Separator();

        if(GUILayout.Button(label)){
            isRunning = true;
            taskCompleted = false;

            Thread thread = new Thread(() =>{
                testAction.Invoke();
                taskCompleted = true;
            });
            thread.Start();

            EditorApplication.update += CheckTaskCompletion;
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