using System;
using KociembaSolver;
using UnityEngine;

public static class SolverTests{




    public static void PerformTests(){

        PerformKociembaTests(100);

    }


    public static void PerformKociembaTests(int testsCount){

        Debug.Log("Kociemba solver testing");

        RubiksCube rc = new RubiksCube();

        System.Random rand = new();

        int failedTests = 0;

        for(int i = 0;i<testsCount;i++){

            string scramble = Algorithms.GenerateScramble(rand.Next() % 25 + 1);

            rc.ApplyAlgorithm(scramble);

            string solution = Kociemba.Solution(rc.State);

            rc.ApplyAlgorithm(solution);

            if(!rc.IsSolved){
                Debug.Log($"Wrong solution!\n{scramble} => {solution}");
                failedTests++;
            }

        }

        if(failedTests > 0){
            Debug.Log($"<color=#FF0000>Passed {testsCount - failedTests} / {testsCount} tests</color>");
        }
        else{
            Debug.Log($"<color=#00FF00>Passed {testsCount - failedTests} / {testsCount} tests</color>");
        }

    }




}