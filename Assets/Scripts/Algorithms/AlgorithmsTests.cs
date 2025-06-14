using System;
using System.Collections.Generic;
using UnityEngine;

public static class AlgorithmsTests{

    public static void PerformTests(){

        PerformOptimizationTests();
        PerformRandomNormalizationTests(1000, 1000);
        PerformRandomOptimizationTests(1000, 1000);
        ScrambleGenerationTests(1000, 1000);
        PerformValidationTests();

    }

    public static void ScrambleGenerationTests(int testsCount, int algorithmLength){

        Debug.Log("Scramble generation testing");

        RubiksCube rc1 = new RubiksCube();
        RubiksCube rc2 = new RubiksCube();

        int failedTests = 0;

        for(int i = 0;i<testsCount;i++){

            string original = Algorithms.GenerateScramble(algorithmLength);

            rc1.ApplyRotationSequence(original);

            string optimized = Algorithms.Optimize(original);

            rc2.ApplyRotationSequence(optimized);

            if(rc1.State != rc2.State){
                Debug.LogError($"Algorithms are not same!\n{original} => {optimized}");
                failedTests++;
            }

            if(original.Length != optimized.Length){
                Debug.LogError(original);
                Debug.LogError(optimized);
                Debug.LogError("Length of original and optimized algorithms are not same. Difference: " + (original.Length - optimized.Length));
                failedTests++;
            }

            rc1.Reset();
            rc2.Reset();

        }

        if(failedTests > 0){
            Debug.Log($"<color=#FF0000>Passed {testsCount - failedTests} / {testsCount} tests</color>");
        }
        else{
            Debug.Log($"<color=#00FF00>Passed {testsCount - failedTests} / {testsCount} tests</color>");
        }
    }

    public static void PerformRandomOptimizationTests(int testsCount, int algorithmLength){

        Debug.Log($"Random optimization testing");

        RubiksCube rc1 = new RubiksCube();
        RubiksCube rc2 = new RubiksCube();

        int failedTests = 0;

        for(int i = 1;i<=testsCount;i++){

            string original = Algorithms.GenerateRandomSequence(algorithmLength);

            string optimized = Algorithms.Optimize(original);

            rc1.ApplyRotationSequence(original);
            rc2.ApplyRotationSequence(optimized);

            if(rc1.State != rc2.State){
                Debug.Log($"Algorithms are not equal!\n{original} => {optimized}");
                failedTests++;
            }

            rc1.Reset();
            rc2.Reset();

        }
        
        if(failedTests > 0){
            Debug.Log($"<color=#FF0000>Passed {testsCount - failedTests} / {testsCount} tests</color>");
        }
        else{
            Debug.Log($"<color=#00FF00>Passed {testsCount - failedTests} / {testsCount} tests</color>");
        }

    }
    public static void PerformValidationTests(){

        Debug.Log("Validation testing");

        var validationTests = new Dictionary<string, bool>{
            { "U U'", true },
            { "UUUU", true },
            { "DDDD", true },
            { "RRRR", true },
            { "LLLL", true },

            { "", true },
            { "    ", true },
            { "\t\t\t\n", true },
            { "\n\n\n", true },
            { "\u3000", true },

            { "U\u3000'D   2R   '", true },

            { "U2R2U2", true },
            { "U'R'U'", true },

            { "'", false },
            { "2", false },
            { " '", false },
            { " 2", false },
            { " ' ", false },
            { " 2 ", false },
            { "' ", false },
            { "2 ", false },

            { "U2'", false },
            { "U2  U'D\t\tUU'R2L   2  R2\tRR  '   LLBU     F   ' FF U\tF'LL     2R", true },
            { "U2  U'D\t\tUU'R2L   2  R2\tRR  '   2LLBU     F   ' FF U\tF'LL     2R", false },

            { "URUL'B2", true },
            { "U    R    U'    R'", true },
            { "U 2   R    'U'    L2R'", true },
            { "U 2\t\t\t   \t\tR   \n\n\n 'U'    L\n\n\n2R'\n\n\n", true },
            { "\t", true },

            { " R L U\t\t '\n\n  R D\r\r  D \t\t'  R\n ' \tU   R L ", true },
            { "RLU '   R   D U 2  D2   \tU \t2\t  D\n2 D\t' R'\n UR L", true },
            { "\nR2LD     'BU'R L ' RL2 R2  L' UB ' D R' L 2\n", true },

            { "UU'U2U2RR'R2R2LL'L2L2DD'D2D2BB'B2B2FF'F2F2", true },
            { "\r\rU\r\rU\r\r'\r\rU\r\r2\r\rU\r\r2\r\rR\r\rR\r\r'\r\rR\r\r2\r\rR\r\r2\r\rL\r\rL\r\r'\r\rL\r\r2\r\rL\r\r2\r\r", true },
            { "U\r\rU\r\r'\r\rU\r\r2\r\rU\r\r2\r\rR\r\rR\r\r'\r\rR\r\r2\r\rR\r\r2\r\rL\r\rL\r\r'\r\rL\r\r2\r\rL\r\r2", true },
            { "\nU\nU\n'\nU\n2\nU\n2\nR\nR'\nR\n2\nR\n2\nL\nL\n'\nL\n2\nL\n2\nD\nD\n'\nD\n2\nD\n2\nB\nB\n'\nB\n2\nB\n2\nF\nF\n'\nF\n2\nF\n2\n", true },
            { "UU ' U 2 U 2RR 'R 2 R 2 LL ' L  2  L 2    D D ' D 2 D2 B B' B 2 B 2 F F 'F 2 F2", true },

            { " R\n  L '  U  \nB 2  F 2   U '\r\r F \t R'\t", true },
            { "U\t\t F\t\t2\t\t R U\n\n2 D'\n\n B B\n\n' D U\n\n 2 \n\nR' B' L U R2\t\n\n\tR2 U\n\n' L  \n\n  ' B F F U", true },

            { "R'R'R'2LDLUBFDFDFDFDFD", false },
            { "R'R'R'LDLUBFDFD'FDFDFD''", false },
            { "R'R'R'LDLUBFDFD'FDFDFD'' ", false },
            { "R'R'R'LDLUBFDFD'FDFDFD'2", false },
            { "R'R'R'LDLUBFDFD'FDFDFD' 2 ", false },
            { "R'R'R'LDLUBFDFD'FDFDFD'2 ", false },
            { "R2'R'R'LDLUBFDFD'FDFDFD'2 ", false },
            { "2R2'R'R'LDLUBFDFD'FDFDFD2 ", false },
            { "R2'R'R'LDLUBFDFD'FDFDFD2'", false },
        };

        int failedTests = 0;
        int testsCount = validationTests.Count;
        foreach(var kvp in validationTests){
            string input = kvp.Key;
            bool expected = kvp.Value;
            bool result = Algorithms.IsValidSequence(input);

            if(result != expected){
                failedTests++;
                Debug.LogError($"Input: \"{input}\" → Expected: \"{expected}\" but was \"{result}\"");
            }
        }

        if(failedTests > 0){
            Debug.Log($"<color=#FF0000>Passed {testsCount - failedTests} / {testsCount} tests</color>");
        }
        else{
            Debug.Log($"<color=#00FF00>Passed {testsCount - failedTests} / {testsCount} tests</color>");
        }

    }

    public static void PerformRandomNormalizationTests(int testsCount, int algorithmLength){
        
        Debug.Log($"Normalization testing");

        RubiksCube rc1 = new RubiksCube();
        RubiksCube rc2 = new RubiksCube();

        int failedTests = 0;

        for(int i = 1;i<=testsCount;i++){

            string original = Algorithms.GenerateRandomSequence(algorithmLength);

            string modified = Algorithms.RemoveWhiteSpaces(original);
            string seqNorm = Algorithms.NormalizeAlgorithm(modified);

            rc1.ApplyRotationSequence(original);
            rc2.ApplyRotationSequence(seqNorm);

            if(rc1.State != rc2.State){
                Debug.Log($"Algorithms are not equal!\n{original} => {seqNorm}");
                failedTests++;
            }

        }

        rc1.Reset();
        rc2.Reset();

        for(int i = 1;i<=testsCount;i++){

            string original = Algorithms.GenerateRandomSequence(algorithmLength);

            string modified = original.Replace(" ", "   ");
            string seqNorm = Algorithms.NormalizeAlgorithm(modified);

            rc1.ApplyRotationSequence(original);
            rc2.ApplyRotationSequence(seqNorm);

            if(rc1.State != rc2.State){
                Debug.LogError($"Algorithms are not equal!\n{original} => {seqNorm}");
                failedTests++;
            }

        }

        if(failedTests > 0){
            Debug.Log($"<color=#00FF00>Passed {testsCount * 2 - failedTests} / {testsCount * 2} tests</color>");
        }
        else{
            Debug.Log($"<color=#00FF00>Passed {testsCount * 2 - failedTests} / {testsCount * 2} tests</color>");
        }

    }
    public static void PerformOptimizationTests(){
        
        Debug.Log($"Optimization testing");

        var optimizeTestCases = new Dictionary<string, string>{

            // Basic cancellations
            { "U U'", "" },
            { "D D'", "" },
            { "R R'", "" },
            { "L L'", "" },
            { "F F'", "" },
            { "B B'", "" },

            { "U' U", "" },
            { "D' D", "" },
            { "R' R", "" },
            { "L' L", "" },
            { "F' F", "" },
            { "B' B", "" },

            { "U U U U", "" },
            { "D D D D", "" },
            { "R R R R", "" },
            { "L L L L", "" },
            { "F F F F", "" },
            { "B B B B", "" },

            { "U' U' U' U'", "" },
            { "D' D' D' D'", "" },
            { "R' R' R' R'", "" },
            { "L' L' L' L'", "" },
            { "F' F' F' F'", "" },
            { "B' B' B' B'", "" },

            { "U' U U' U", "" },
            { "D' D D' D", "" },
            { "R' R R' R", "" },
            { "L' L L' L", "" },
            { "F' F F' F", "" },
            { "B' B B' B", "" },

            // Triple moves
            { "U U U", "U'" },
            { "D D D", "D'" },
            { "R R R", "R'" },
            { "L L L", "L'" },
            { "B B B", "B'" },
            { "F F F", "F'" },

            { "U' U' U'", "U" },
            { "D' D' D'", "D" },
            { "R' R' R'", "R" },
            { "L' L' L'", "L" },
            { "B' B' B'", "B" },
            { "F' F' F'", "F" },

            // Double + single
            { "R2 R", "R'" },
            { "R2 R'", "R" },
            { "R R2", "R'" },
            { "R' R2", "R" },
            { "R2 R R2", "R" },
            { "R2 R' R2", "R'" },
            { "R2 R2 R2", "R2" },
            { "R2 R2", "" },
            
            { "L2 L", "L'" },
            { "L2 L'", "L" },
            { "L L2", "L'" },
            { "L' L2", "L" },
            { "L2 L L2", "L" },
            { "L2 L' L2", "L'" },
            { "L2 L2 L2", "L2" },
            { "L2 L2", "" },
            
            { "U2 U", "U'" },
            { "U2 U'", "U" },
            { "U U2", "U'" },
            { "U' U2", "U" },
            { "U2 U U2", "U" },
            { "U2 U' U2", "U'" },
            { "U2 U2 U2", "U2" },
            { "U2 U2", "" },
            
            { "D2 D", "D'" },
            { "D2 D'", "D" },
            { "D D2", "D'" },
            { "D' D2", "D" },
            { "D2 D D2", "D" },
            { "D2 D' D2", "D'" },
            { "D2 D2 D2", "D2" },
            { "D2 D2", "" },

            { "F2 F", "F'" },
            { "F2 F'", "F" },
            { "F F2", "F'" },
            { "F' F2", "F" },
            { "F2 F F2", "F" },
            { "F2 F' F2", "F'" },
            { "F2 F2 F2", "F2" },
            { "F2 F2", "" },

            { "B2 B", "B'" },
            { "B2 B'", "B" },
            { "B B2", "B'" },
            { "B' B2", "B" },
            { "B2 B B2", "B" },
            { "B2 B' B2", "B'" },
            { "B2 B2 B2", "B2" },
            { "B2 B2", "" },

            // Nested cancellations
            { "R U U' R'", "" },
            { "R R' U U' R R'", "" },
            { "L R U U' R' L'", "" },
            { "B R U U' R' B'", "" },
            { "D B R U U' R' B' D'", "" },
            { "F' B R U U' R' B' F", "" },
            { "U F' B R U U' R' B' F U'", "" },
            { "U U F' B R U U' R' B' F U' U'", "" },
            { "R2 U F' B R U U' R' B' F U' R2", "" },
            { "R U2 D' B B' D U2 R' B' L U R2 R2 U' L' B", "" },
            { "F2 R U2 D' B B' D U2 R' B' L U R2 R2 U' L' B F F", "" },
            { "R F' B D U2 U2 D' B' F D F' R B B' R' F D' U", "R U" },
            { "L U R R F' B D U2 U2 D' B' F D F' R B B' R' F D' U", "L U R2 U" },
            { "R R R B U U2 U B2 B2 B' R R R", "R2" },
            { "R R R B U U2 U B2 B2 B' R R R U R L U R L U R L", "R2 U R L U R L U R L" },
            { "D B L D B L D B L R R R B U U2 U B2 B2 B' R R R", "D B L D B L D B L R2" },
            { "D B L D B L D B L R R R B U U2 U B2 B2 B' R R R R2 L' B' D' L' B' D' L' B' D'", "" },
            { "L U L' U' R D D' R' F L B U U2 U B' U L U' L'", "L U L' U' F L U L U' L'" },
            { "B D D' B' L U L' U' R D D' R' F L B U U2 U B' U L U' L' B D D' B'", "L U L' U' F L U L U' L'" },

            // Commuting face optimization
            { "R L R L", "R2 L2" },
            { "U D U D", "U2 D2" },
            { "F B F B", "F2 B2" },

            { "R L R' L'", "" },
            { "L R L' R'", "" },
            { "R2 L2 R2 L2", "" },
            { "R2 L2 R L", "R' L'" },
            { "R L2 R2 L R L' R' L2 R' L'", "R2 L'" },
            { "R2 L R' L2 R L' R2 L2 R'", "R'" },
            { "R2 L2 F2 B2 U2 D2 U2 D2 B2 F2 R2 L2", "" },
            
            { "U D U' D'", "" },
            { "D U D' U'", "" },
            { "U2 D2 U2 D2", "" },
            { "U2 D2 U D", "U' D'" },
            { "U D2 U2 D U D' U' D2 U' D'", "U2 D'" },
            { "U2 D U' D2 U D' U2 D2 U'", "U'" },

            { "F B F' B'", "" },
            { "B F B' F'", "" },
            { "F2 B2 F2 B2", "" },
            { "F2 B2 F B", "F' B'" },
            { "F B2 F2 B F B' F' B2 F' B'", "F2 B'" },
            { "F2 B F' B2 F B' F2 B2 F'", "F'" },

            // Combined
            { "L D D' L' U R", "U R" },
            { "U R L D D' L'", "U R" },
            { "F D R F F2 F R' F D", "F D F D" },
            { "D L U R L R L R2 L2 U' L' D'", "" },
            { "F U B R2 L2 R L' B' U' F'", "F U B R' L B' U' F'" },
            { "D U B U D U2 D' B' U' D'", "D U B U' B' U' D'" },
            { "B R' F' U U R L R' L' U2 F U D U2 D2 D U R B'", "" },
            { "B D' U2 U R R2 R U D R F2 B2 F B F B D' R2 L2 R2 L2 L U L", "B R D' L U L" },
            { "B R B' R' U R L R L R L R L U U2 D L D' L' U2 D2 R' U U' R U2 D2", "B R B' R' D L D' L'" },
            { "B R B' R' U R L R L R L R L U U2 D L D' L' U2 D2 R' U U' R U2 D2 L U R L", "B R B' R' D L D' U R L" },
            { "U F D' R D L L' D' R' B U F F' U' B' D F' U' R L R L U F L L2 L' L2 F' U' R2 L2", "" },
            { "F R F R' U F D' R D L L' D' R' B U F F' U' B' D F' U' R L R L U F L L2 L' L2 F' U' R2 L2  R F' R' F'", "" },
            { "B F R F R' U F D' R D L L' D' R' B U F F' U' B' D F' U' R L R L U F L L2 L' L2 F' U' R2 L2 R F' R' F'", "B" },
            { "F R F R' U F D' R D L L' D' R' B U F F' U' B' D F' U' R L R L U F L L2 L' L2 F' U' R2 L2  R F' R' F' F", "F" },

            { "R L U' R D D' R' U R L", "R2 L2" },
            { "R L U' R D U2 D2 U2 D2 D' R' U R L", "R2 L2" },
            { "R2 L D' B U' R L' R L2 R2 L' U B' D R' L2", "R L'" },

            // No optimization
            { "R U L D F B", "R U L D F B" },
            { "R2 L2 U L2 R2", "R2 L2 U L2 R2" },
            { "R U R' U'", "R U R' U'" },
            { "U D R D U", "U D R D U" },
            { "U R' D' F2 L F2 D R U'", "U R' D' F2 L F2 D R U'" },
            { "R L U R L", "R L U R L" },
            { "L R U R L", "L R U R L" },
            { "D R L U R L D'", "D R L U R L D'" },
            { "R L' U B2 F2 U' F R'", "R L' U B2 F2 U' F R'" },
            { "R2 L2 U2 D2 F2 B2 L2 R2 D2 U2 F2 B2", "R2 L2 U2 D2 F2 B2 L2 R2 D2 U2 F2 B2" },

            { "", "" },
            { "R", "R" },
            { "L", "L" },
            { "U", "U" },
            { "D", "D" },
            { "F", "F" },
            { "B", "B" },
            
            { "R'", "R'" },
            { "L'", "L'" },
            { "U'", "U'" },
            { "D'", "D'" },
            { "F'", "F'" },
            { "B'", "B'" },

            // Order of opposite sides keeps same
            { "U D", "U D" }, { "R U D", "R U D" }, { "R L", "R L" }, { "F B", "F B" },
            { "D U", "D U" }, { "R D U", "R D U" }, { "L R", "L R" }, { "B F", "B F" },
            { "U' D", "U' D" }, { "R U' D", "R U' D" }, { "R' L", "R' L" }, { "F' B", "F' B" },
            { "D U'", "D U'" }, { "R D U'", "R D U'" }, { "L R'", "L R'" }, { "B F'", "B F'" },
            { "U D'", "U D'" }, { "R U D'", "R U D'" }, { "R L'", "R L'" }, { "F B'", "F B'" },
            { "D' U", "D' U" }, { "R D' U", "R D' U" }, { "L' R", "L' R" }, { "B' F", "B' F" },
            { "U' D'", "U' D'" }, { "R U' D'", "R U' D'" }, { "R' L'", "R' L'" }, { "F' B'", "F' B'" },
            { "D' U'", "D' U'" }, { "R D' U'", "R D' U'" }, { "L' R'", "L' R'" }, { "B' F'", "B' F'" },
            { "U2 D", "U2 D" }, { "R U2 D", "R U2 D" }, { "R2 L", "R2 L" }, { "F2 B", "F2 B" },
            { "D U2", "D U2" }, { "R D U2", "R D U2" }, { "L R2", "L R2" }, { "B F2", "B F2" },
            { "U D2", "U D2" }, { "R U D2", "R U D2" }, { "R L2", "R L2" }, { "F B2", "F B2" },
            { "D2 U", "D2 U" }, { "R D2 U", "R D2 U" }, { "L2 R", "L2 R" }, { "B2 F", "B2 F" },
            { "U2 D'", "U2 D'" }, { "R U2 D'", "R U2 D'" }, { "R2 L'", "R2 L'" }, { "F2 B'", "F2 B'" },
            { "D' U2", "D' U2" }, { "R D' U2", "R D' U2" }, { "L' R2", "L' R2" }, { "B' F2", "B' F2" },
            { "U' D2", "U' D2" }, { "R U' D2", "R U' D2" }, { "R' L2", "R' L2" }, { "F' B2", "F' B2" },
            { "D2 U'", "D2 U'" }, { "R D2 U'", "R D2 U'" }, { "L2 R'", "L2 R'" }, { "B2 F'", "B2 F'" },
            { "U2 D2", "U2 D2" }, { "R U2 D2", "R U2 D2" }, { "R2 L2", "R2 L2" }, { "F2 B2", "F2 B2" },
            { "D2 U2", "D2 U2" }, { "R D2 U2", "R D2 U2" }, { "L2 R2", "L2 R2" }, { "B2 F2", "B2 F2" },

            { "U U D D", "U2 D2" },
            { "D D U U", "D2 U2" },

            { "U U D D U U", "D2" },
            { "D D U U D D", "U2" },
            { "D D U U D D U U D D U U", "D2 U2" },
            { "U U D D U U D D U U D D", "U2 D2" },
            
            { "R R L L", "R2 L2" },
            { "L L R R", "L2 R2" },

            { "R R L L R R", "L2" },
            { "L L R R L L", "R2" },
            { "L L R R L L R R L L R R", "L2 R2" },
            { "R R L L R R L L R R L L", "R2 L2" },
            
            { "F F B B", "F2 B2" },
            { "B B F F", "B2 F2" },

            { "F F B B F F", "B2" },
            { "B B F F B B", "F2" },
            { "B B F F B B F F B B F F", "B2 F2" },
            { "F F B B F F B B F F B B", "F2 B2" },

            // normalize sequence
            { " U ", "U" }, { " R ", "R" }, { " D ", "D" }, { " L ", "L" }, { " F ", "F" }, { " B ", "B" },
            { " U", "U" }, { " R", "R" }, { " D", "D" }, { " L", "L" }, { " F", "F" }, { " B", "B" },
            { "U ", "U" }, { "R ", "R" }, { "D ", "D" }, { "L ", "L" }, { "F ", "F" }, { "B ", "B" },
            { "U' ", "U'" }, { "R' ", "R'" }, { "D' ", "D'" }, { "L' ", "L'" }, { "F' ", "F'" }, { "B' ", "B'" },
            { " U'", "U'" }, { " R'", "R'" }, { " D'", "D'" }, { " L'", "L'" }, { " F'", "F'" }, { " B'", "B'" },
            { " U' ", "U'" }, { " R' ", "R'" }, { " D' ", "D'" }, { " L' ", "L'" }, { " F' ", "F'" }, { " B' ", "B'" },
            { " U2 ", "U2" }, { " R2 ", "R2" }, { " D2 ", "D2" }, { " L2 ", "L2" }, { " F2 ", "F2" }, { " B2 ", "B2" },
            { " U2", "U2" }, { " R2", "R2" }, { " D2", "D2" }, { " L2", "L2" }, { " F2", "F2" }, { " B2", "B2" },
            { "U2 ", "U2" }, { "R2 ", "R2" }, { "D2 ", "D2" }, { "L2 ", "L2" }, { "F2 ", "F2" }, { "B2 ", "B2" },
            { "U ' ", "U'" }, { "R ' ", "R'" }, { "D ' ", "D'" }, { "L ' ", "L'" }, { "F ' ", "F'" }, { "B ' ", "B'" },
            { " U '", "U'" }, { " R '", "R'" }, { " D '", "D'" }, { " L '", "L'" }, { " F '", "F'" }, { " B '", "B'" },
            { " U ' ", "U'" }, { " R ' ", "R'" }, { " D ' ", "D'" }, { " L ' ", "L'" }, { " F ' ", "F'" }, { " B ' ", "B'" },
            { " U 2 ", "U2" }, { " R 2 ", "R2" }, { " D 2 ", "D2" }, { " L 2 ", "L2" }, { " F 2 ", "F2" }, { " B 2 ", "B2" },
            { " U 2", "U2" }, { " R 2", "R2" }, { " D 2", "D2" }, { " L 2", "L2" }, { " F 2", "F2" }, { " B 2", "B2" },
            { "U 2 ", "U2" }, { "R 2 ", "R2" }, { "D 2 ", "D2" }, { "L 2 ", "L2" }, { "F 2 ", "F2" }, { "B 2 ", "B2" },

            { "UU", "U2" },
            { " UU ", "U2" },
            { " UU", "U2" },
            { "UU ", "U2" },

            { "URUL'B2", "U R U L' B2" },
            { "    ", "" },
            { "U    R    U'    R'", "U R U' R'" },
            { "U 2   R    'U'    L2R'", "U2 R' U' L2 R'" },
            { "U 2\t\t\t   \t\tR   \n\n\n 'U'    L\n\n\n2R'\n\n\n", "U2 R' U' L2 R'" },
            { "\n\n\n", "" },
            { "\t", "" },

            { " R L U\t\t '\n\n  R D\r\r  D \t\t'  R\n ' \tU   R L ", "R2 L2" },
            { "RLU '   R   D U 2  D2   \tU \t2\t  D\n2 D\t' R'\n UR L", "R2 L2" },
            { "\nR2LD     'BU'R L ' RL2 R2  L' UB ' D R' L 2\n", "R L'" },

            { "UU'U2U2RR'R2R2LL'L2L2DD'D2D2BB'B2B2FF'F2F2", "" },
            { "\r\rU\r\rU\r\r'\r\rU\r\r2\r\rU\r\r2\r\rR\r\rR\r\r'\r\rR\r\r2\r\rR\r\r2\r\rL\r\rL\r\r'\r\rL\r\r2\r\rL\r\r2\r\r", "" },
            { "U\r\rU\r\r'\r\rU\r\r2\r\rU\r\r2\r\rR\r\rR\r\r'\r\rR\r\r2\r\rR\r\r2\r\rL\r\rL\r\r'\r\rL\r\r2\r\rL\r\r2", "" },
            { "\nU\nU\n'\nU\n2\nU\n2\nR\nR'\nR\n2\nR\n2\nL\nL\n'\nL\n2\nL\n2\nD\nD\n'\nD\n2\nD\n2\nB\nB\n'\nB\n2\nB\n2\nF\nF\n'\nF\n2\nF\n2\n", "" },
            { "UU ' U 2 U 2RR 'R 2 R 2 LL ' L  2  L 2    D D ' D 2 D2 B B' B 2 B 2 F F 'F 2 F2", "" },

            { " R\n  L '  U  \nB 2  F 2   U '\r\r F \t R'\t", "R L' U B2 F2 U' F R'" },
            { "U\t\t F\t\t2\t\t R U\n\n2 D'\n\n B B\n\n' D U\n\n 2 \n\nR' B' L U R2\t\n\n\tR2 U\n\n' L  \n\n  ' B F F U", "U2" },

            // invalid sequence
            { "'", "Exception" },
            { "2", "Exception" },
            { " '", "Exception" },
            { " 2", "Exception" },
            { " ' ", "Exception" },
            { " 2 ", "Exception" },
            { "' ", "Exception" },
            { "2 ", "Exception" },
            { "t", "Exception" },
            { "f ", "Exception" },
            { " , ", "Exception" },
            { "U U'  'U U", "Exception" },
            { "R R' 2L R", "Exception" },
            { "UDUDUDUuDUDUDUDU", "Exception" },
            { "'U", "Exception" },
            { "'U ", "Exception" },
            { " 'U", "Exception" },
            { " 'U ", "Exception" },
            { "' U", "Exception" },
            { " ' U", "Exception" },
            { "' U ", "Exception" },
            { " ' U ", "Exception" },
            { "2U", "Exception" },
            { "2U ", "Exception" },
            { " 2U", "Exception" },
            { " 2U ", "Exception" },
            { "2 U", "Exception" },
            { " 2 U", "Exception" },
            { "2 U ", "Exception" },
            { " 2 U ", "Exception" },

            { "R'R'R'2LDLUBFDFDFDFDFD", "Exception" },
            { "R'R'R'LDLUBFDFD'FDFDFD''", "Exception" },
            { "R'R'R'LDLUBFDFD'FDFDFD'' ", "Exception" },
            { "R'R'R'LDLUBFDFD'FDFDFD'2", "Exception" },
            { "R'R'R'LDLUBFDFD'FDFDFD' 2 ", "Exception" },
            { "R'R'R'LDLUBFDFD'FDFDFD'2 ", "Exception" },
            { "R2'R'R'LDLUBFDFD'FDFDFD'2 ", "Exception" },
            { "2R2'R'R'LDLUBFDFD'FDFDFD2 ", "Exception" },
            { "R2'R'R'LDLUBFDFD'FDFDFD2'", "Exception" },


        };
        int testsCount = optimizeTestCases.Count;
        int failedTests = 0;
        foreach(var kvp in optimizeTestCases){
            string input = kvp.Key;
            string expected = kvp.Value;
            string optimized = "";
            try{
                optimized = Algorithms.Optimize(input);
            }
            catch(FormatException){
                optimized = "Exception";
            }

            if(optimized != expected){
                failedTests++;
                Debug.LogError($"Input: \"{input}\" → Expected: \"{expected}\" but was \"{optimized}\"");
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
