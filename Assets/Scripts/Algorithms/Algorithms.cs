using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class Algorithms{

    public static string Optimize(string algorithm){

        algorithm = NormalizeAlgorithm(algorithm);

        Dictionary<char, char> opposites = new Dictionary<char, char>{
            { 'U', 'D' }, { 'D', 'U' },
            { 'L', 'R' }, { 'R', 'L' },
            { 'F', 'B' }, { 'B', 'F' }
        };

        var split = algorithm.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var moves = new List<(char face, int amount)>(split.Length);

        foreach(var move in split){

            (char face, int amount) entry = (move[0], RotationValue(move));

            if(moves.Count == 0){
                moves.Add(entry);
                continue;
            }

            var top = moves[^1];

            if(top.face == entry.face){
                int sum = (top.amount + entry.amount) % 4;
                if(sum != 0){
                    moves[^1] = (entry.face, sum);
                }
                else{
                    moves.RemoveAt(moves.Count - 1);
                }
                continue;
            }

            if(moves.Count > 1){

                var a = top;
                var b = moves[^2];

                if(a.face == opposites[entry.face] && b.face == entry.face){

                    int faceCount = (entry.amount + b.amount) % 4;
                    if(faceCount != 0){
                        moves[^2] = (entry.face, faceCount);
                    }
                    else{
                        moves.RemoveAt(moves.Count - 2);
                    }
                    continue;

                }
            }
            moves.Add(entry);
        }
        return string.Join(" ", moves.Select(x => FormatMove(x.face, x.amount)));
    }

    private static string FormatMove(char face, int rotation){
        return rotation == 0 ? "" :
            rotation == 1 ? face.ToString() :
            rotation == 2 ? face + "2" :
            rotation == 3 ? face + "'" : "";
    }

    private static int RotationValue(string move){
        return move.Length == 1 ? 1 :
            move[1] == '\'' ? 3 :
            move[1] == '2' ? 2 : 0;
    }

    public static (CubeFace cubeFace, bool clockwise, bool doubleTurn) GetMove(string move){

        if(string.IsNullOrEmpty(move)){
            return (CubeFace.None, true, false);
        }

        char faceChar = move[0];

        CubeFace face = faceChar switch{
            'L' => CubeFace.Left,
            'F' => CubeFace.Front,
            'R' => CubeFace.Right,
            'B' => CubeFace.Back,
            'U' => CubeFace.Up,
            'D' => CubeFace.Down,
            _ => throw new ArgumentException($"Move is not in correct format! \"{move}\"")
        };

        bool clockwise = true;
        bool doubleTurn = false;

        if(move.Length > 1){
            if(move[1] == '\''){
                clockwise = false;
            }
            else if(move[1] == '2'){
                doubleTurn = true;
            }
            else{
                throw new ArgumentException($"Move is not in correct format! \"{move}\"");
            }
        }

        return (face, clockwise, doubleTurn);
    }

    public static string NormalizeAlgorithm(string input){

        var normalized = new List<string>();
        int i = 0;

        while(i < input.Length){
            char c = input[i];

            if("UDLRFB".Contains(c)){
                for(i++; i < input.Length && char.IsWhiteSpace(input[i]); i++);
                string move = c.ToString();
                if(i < input.Length && (input[i] == '\'' || input[i] == '2')){
                    move += input[i];
                    i++;
                }
                normalized.Add(move);
                continue;
            }
            else if(char.IsWhiteSpace(c)){
                i++;
            }
            else{
                throw new FormatException($"Invalid character in move sequence: '{c}' at position {i}");
            }

        }

        return string.Join(" ", normalized);
    }
    public static string RemoveWhiteSpaces(string input){
        if(input == null){
            return input!;
        }

        StringBuilder result = new System.Text.StringBuilder(input.Length);
        foreach(char c in input){
            if(!char.IsWhiteSpace(c)){
                result.Append(c);
            }
        }
        return result.ToString();
    }

    public static string GenerateScramble(int length){

        char?[] modifiers = { null, '\'', '2' };
        List<char> availableFaces = new List<char>(){ 'R', 'L', 'U', 'D', 'F', 'B' };

        Dictionary<char, char> opposites = new Dictionary<char, char>{
            { 'U', 'D' }, { 'D', 'U' },
            { 'L', 'R' }, { 'R', 'L' },
            { 'F', 'B' }, { 'B', 'F' }
        };

        System.Random rand = new System.Random();

        List<string> sequence = new List<string>();

        for(int i = 0; i < length; i++){

            char face = availableFaces[rand.Next(availableFaces.Count)];

            availableFaces.Remove(face);

            if(i > 0 && opposites[sequence[i-1][0]] != face){
                availableFaces.Add(sequence[i-1][0]);

                if(i > 1 && opposites[sequence[i-2][0]] == sequence[i-1][0]){
                    availableFaces.Add(sequence[i-2][0]);
                }
            }

            char? modifier = modifiers[rand.Next(modifiers.Length)];
            sequence.Add(face.ToString() + modifier);
        }

        return string.Join(" ", sequence);
    }

    
    public static string GenerateRandomSequence(int length){

        string[] faces = { "R", "L", "U", "D", "F", "B" };
        string[] modifiers = { "", "'", "2" };
        System.Random rand = new System.Random();

        List<string> sequence = new List<string>();

        for(int i = 0; i < length; i++){
            string face = faces[rand.Next(faces.Length)];
            string modifier = modifiers[rand.Next(modifiers.Length)];
            sequence.Add(face + modifier);
        }

        return string.Join(" ", sequence);
    }


    public static bool IsValidSequence(string input){

        int i = 0;
        while(i < input.Length){
            if("UDLRFB".Contains(input[i])){
                for(i++; i < input.Length && char.IsWhiteSpace(input[i]); i++);
                if(i < input.Length){
                    if(input[i] == '\'' || input[i] == '2'){
                        i++;
                    }
                    else if(!"UDLRFB".Contains(input[i])){
                        return false;
                    }
                }
            }
            else if(char.IsWhiteSpace(input[i])){
                i++;
            }
            else{
                return false;
            }
        }
        return true;
    }

    public static string InverseAlgorithm(string sequence){
        string[] tokens = NormalizeAlgorithm(sequence).Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        List<string> inverse = new List<string>();

        for(int i = tokens.Length-1;i>=0;i--){
            inverse.Add(InvertMove(tokens[i]));
        }

        return string.Join(" ", inverse);
    }

    private static string InvertMove(string move){
        char face = move[0];
        string suffix = move.Length > 1 ? move.Substring(1) : "";

        return suffix switch{
            "" => face + "'",
            "'" => face.ToString(),
            "2" => face + "2",
            _ => throw new FormatException($"Invalid move: {move}")
        };
    }

    public static int MovesCount(string algorithm){
        return NormalizeAlgorithm(algorithm).Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
    }

    public static int PeriodLength(string algorithm){

        string optimized = Algorithms.Optimize(algorithm);

        RubiksCube rc = new RubiksCube();

        int cycles = 0;
        do{
            cycles++;
            rc.ApplyAlgorithm(optimized);
        } while(!rc.IsSolved);

        return cycles;

    }

    public static bool AreEquivalentAlgorithms(string a1, string a2){

        RubiksCube rc1 = new RubiksCube();
        RubiksCube rc2 = new RubiksCube();

        rc1.ApplyAlgorithm(a1);
        rc2.ApplyAlgorithm(a2);

        return rc1 == rc2;

    }

    public static string RotateAlgorithm(string algorithm, int y, int x, int z){

        algorithm = NormalizeAlgorithm(algorithm);
        string[] moves = algorithm.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        x = ((x % 4) + 4) % 4;
        y = ((y % 4) + 4) % 4;
        z = ((z % 4) + 4) % 4;

        Dictionary<char, char[]> rotationMaps = new(){
            ['x'] = new[] { 'F', 'U', 'B', 'D' },
            ['y'] = new[] { 'F', 'L', 'B', 'R' },
            ['z'] = new[] { 'U', 'L', 'D', 'R' },
        };

        for(int i = 0; i < moves.Length; i++){

            string move = moves[i];
            char face = move[0];
            string modifier = move.Length > 1 ? move.Substring(1) : "";

            if(face != 'U' && face != 'D'){
                var map = rotationMaps['y'];
                face = map[(Array.IndexOf(map, face) + y) % 4];
            }
            if(face != 'R' && face != 'L'){
                var map = rotationMaps['x'];
                face = map[(Array.IndexOf(map, face) + x) % 4];
            }
            if(face != 'F' && face != 'B'){
                var map = rotationMaps['z'];
                face = map[(Array.IndexOf(map, face) + z) % 4];
            }

            moves[i] = face + modifier;
        }

        return string.Join(" ", moves);

    }

}
