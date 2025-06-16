using System;
using CFOPSolver;
using KociembaSolver;
using UnityEngine;

public static class SolverTests{




    public static void PerformTests(){

        PerformKociembaTests(100);
        PerformCFOPTests(3000);

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

    public static void PerformCFOPTests(int testsCount){

        Debug.Log("CFOP solver testing");

        RubiksCube rc = new RubiksCube();

        System.Random rand = new();

        int failedTests = 0;

        for(int i = 0;i<testsCount;i++){

            string scramble = Algorithms.GenerateScramble(rand.Next() % 25 + 1);

            rc.ApplyAlgorithm(scramble);

            string solution = CFOP.Solution(rc.State);

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