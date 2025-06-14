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

}
