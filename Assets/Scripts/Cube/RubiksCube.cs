using System;
using System.Collections.Generic;
using System.Text;
using KociembaSolver;
using UnityEngine;

public class RubiksCube{

    private static readonly Dictionary<CubeFace, (CubeFace, int, int)[,]> groups = new(){
        [CubeFace.Left] = new (CubeFace, int, int)[5,4]{
            {(CubeFace.Left, 0, 0), (CubeFace.Left, 0, 2), (CubeFace.Left, 2, 2), (CubeFace.Left, 2, 0), },
            {(CubeFace.Left, 0, 1), (CubeFace.Left, 1, 2), (CubeFace.Left, 2, 1), (CubeFace.Left, 1, 0), },
            {(CubeFace.Up, 0, 0), (CubeFace.Front, 0, 0), (CubeFace.Down, 0, 0), (CubeFace.Back, 2, 2), },
            {(CubeFace.Up, 2, 0), (CubeFace.Front, 2, 0), (CubeFace.Down, 2, 0), (CubeFace.Back, 0, 2), },
            {(CubeFace.Up, 1, 0), (CubeFace.Front, 1, 0), (CubeFace.Down, 1, 0), (CubeFace.Back, 1, 2), },
        },
        [CubeFace.Front] = new (CubeFace, int, int)[5,4]{
            {(CubeFace.Front, 0, 0), (CubeFace.Front, 0, 2), (CubeFace.Front, 2, 2), (CubeFace.Front, 2, 0), },
            {(CubeFace.Front, 0, 1), (CubeFace.Front, 1, 2), (CubeFace.Front, 2, 1), (CubeFace.Front, 1, 0), },
            {(CubeFace.Up, 2, 0), (CubeFace.Right, 0, 0), (CubeFace.Down, 0, 2), (CubeFace.Left, 2, 2), },
            {(CubeFace.Up, 2, 2), (CubeFace.Right, 2, 0), (CubeFace.Down, 0, 0), (CubeFace.Left, 0, 2), },
            {(CubeFace.Up, 2, 1), (CubeFace.Right, 1, 0), (CubeFace.Down, 0, 1), (CubeFace.Left, 1, 2), },
        },
        [CubeFace.Right] = new (CubeFace, int, int)[5,4]{
            {(CubeFace.Right, 0, 0), (CubeFace.Right, 0, 2), (CubeFace.Right, 2, 2), (CubeFace.Right, 2, 0), },
            {(CubeFace.Right, 0, 1), (CubeFace.Right, 1, 2), (CubeFace.Right, 2, 1), (CubeFace.Right, 1, 0), },
            {(CubeFace.Up, 2, 2), (CubeFace.Back, 0, 0), (CubeFace.Down, 2, 2), (CubeFace.Front, 2, 2), },
            {(CubeFace.Up, 0, 2), (CubeFace.Back, 2, 0), (CubeFace.Down, 0, 2), (CubeFace.Front, 0, 2), },
            {(CubeFace.Up, 1, 2), (CubeFace.Back, 1, 0), (CubeFace.Down, 1, 2), (CubeFace.Front, 1, 2), },
        },
        [CubeFace.Back] = new (CubeFace, int, int)[5,4]{
            {(CubeFace.Back, 0, 0), (CubeFace.Back, 0, 2), (CubeFace.Back, 2, 2), (CubeFace.Back, 2, 0), },
            {(CubeFace.Back, 0, 1), (CubeFace.Back, 1, 2), (CubeFace.Back, 2, 1), (CubeFace.Back, 1, 0), },
            {(CubeFace.Up, 0, 2), (CubeFace.Left, 0, 0), (CubeFace.Down, 2, 0), (CubeFace.Right, 2, 2), },
            {(CubeFace.Up, 0, 0), (CubeFace.Left, 2, 0), (CubeFace.Down, 2, 2), (CubeFace.Right, 0, 2), },
            {(CubeFace.Up, 0, 1), (CubeFace.Left, 1, 0), (CubeFace.Down, 2, 1), (CubeFace.Right, 1, 2), },
        },
        [CubeFace.Up] = new (CubeFace, int, int)[5,4]{
            {(CubeFace.Up, 0, 0), (CubeFace.Up, 0, 2), (CubeFace.Up, 2, 2), (CubeFace.Up, 2, 0), },
            {(CubeFace.Up, 0, 1), (CubeFace.Up, 1, 2), (CubeFace.Up, 2, 1), (CubeFace.Up, 1, 0), },
            {(CubeFace.Back, 0, 2), (CubeFace.Right, 0, 2), (CubeFace.Front, 0, 2), (CubeFace.Left, 0, 2), },
            {(CubeFace.Back, 0, 0), (CubeFace.Right, 0, 0), (CubeFace.Front, 0, 0), (CubeFace.Left, 0, 0), },
            {(CubeFace.Back, 0, 1), (CubeFace.Right, 0, 1), (CubeFace.Front, 0, 1), (CubeFace.Left, 0, 1), },
        },
        [CubeFace.Down] = new (CubeFace, int, int)[5,4]{
            {(CubeFace.Down, 0, 0), (CubeFace.Down, 0, 2), (CubeFace.Down, 2, 2), (CubeFace.Down, 2, 0), },
            {(CubeFace.Down, 0, 1), (CubeFace.Down, 1, 2), (CubeFace.Down, 2, 1), (CubeFace.Down, 1, 0), },
            {(CubeFace.Front, 2, 0), (CubeFace.Right, 2, 0), (CubeFace.Back, 2, 0), (CubeFace.Left, 2, 0), },
            {(CubeFace.Front, 2, 2), (CubeFace.Right, 2, 2), (CubeFace.Back, 2, 2), (CubeFace.Left, 2, 2), },
            {(CubeFace.Front, 2, 1), (CubeFace.Right, 2, 1), (CubeFace.Back, 2, 1), (CubeFace.Left, 2, 1), },
        },
    };
    private CubeFace[,,] cubeState = new CubeFace[6,3,3];

    public CubeFace this[CubeFace cubeFace, int row, int col]{
        get => cubeState[(int)cubeFace, row, col];
        set => cubeState[(int)cubeFace, row, col] = value;
    }

    public bool IsSolvable{
        get{
            string state = State;

            int[] count = new int[6];
            try{
                for(int i = 0; i < 54; i++){
                    count[(int)Enum.Parse(typeof(CubeColor), state.Substring(i, 1))]++;
                }
                for(int j = 0; j < 6; j++){
                    if (count[j] != 9){
                        return false;
                    }
                }
                return new FaceCube(state).ToCubieCube().Verify() == 0;
            }
            catch{
                return false;
            }

        }
    }

    public bool IsSolved{
        get{
            for(int i = 0;i<6;i++){
                for(int j = 0;j<3;j++){
                    for(int k = 0;k<3;k++){
                        if(cubeState[i,j,k] != (CubeFace)i){
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }

    public string State{
        get{
            StringBuilder sb = new StringBuilder(54);

            for(int i = 0;i<3;i++){
                for(int j = 0;j<3;j++){
                    sb.Append(CubeColorToChar(this[CubeFace.Up, i,j]));
                }
            }
            for(int i = 0;i<3;i++){
                for(int j = 0;j<3;j++){
                    sb.Append(CubeColorToChar(this[CubeFace.Right, i,j]));
                }
            }
            for(int i = 0;i<3;i++){
                for(int j = 0;j<3;j++){
                    sb.Append(CubeColorToChar(this[CubeFace.Front, i,j]));
                }
            }
            for(int i = 0;i<3;i++){
                for(int j = 0;j<3;j++){
                    sb.Append(CubeColorToChar(this[CubeFace.Down, i,j]));
                }
            }
            for(int i = 0;i<3;i++){
                for(int j = 0;j<3;j++){
                    sb.Append(CubeColorToChar(this[CubeFace.Left, i,j]));
                }
            }
            for(int i = 0;i<3;i++){
                for(int j = 0;j<3;j++){
                    sb.Append(CubeColorToChar(this[CubeFace.Back, i,j]));
                }
            }

            return sb.ToString();
        }
    }

    public void Reset(){
        for(int i = 0;i<6;i++){
            for(int j = 0;j<3;j++){
                for(int k = 0;k<3;k++){
                    cubeState[i,j,k] = (CubeFace)i;
                }
            }
        }
    }

    public bool Equals(RubiksCube rc){

        if(rc is null) return false;

        for(int i = 0;i<6;i++){
            for(int j = 0;j<3;j++){
                for(int k = 0;k<3;k++){
                    if(rc.cubeState[i,j,k] != cubeState[i,j,k]){
                        return false;
                    }
                }
            }
        }

        return true;

    }

    public static bool operator ==(RubiksCube l, RubiksCube r){
        return l.Equals(r);
    }

    public static bool operator !=(RubiksCube l, RubiksCube r){
        return !l.Equals(r);
    }

    public override bool Equals(object obj){
        if(ReferenceEquals(this, obj)) return true;
        if(obj is null || obj.GetType() != GetType()) return false;
        return Equals(obj as RubiksCube);
    }

    public override int GetHashCode(){

        int hash = unchecked((int)2166136261);
        for(int i = 0;i<6;i++){
            for(int j = 0;j<3;j++){
                for(int k = 0;k<3;k++){
                    hash ^= ((int)cubeState[i,j,k] + 7) * 123456789;
                    hash *= 16777619;
                }
            }
        }
        return hash;
    }

    private char CubeColorToChar(CubeFace cc) => cc switch{
        CubeFace.Up => 'U',
        CubeFace.Down => 'D',
        CubeFace.Front => 'F',
        CubeFace.Back => 'B',
        CubeFace.Right => 'R',
        CubeFace.Left => 'L',
        _ => throw new Exception()
    };

    public RubiksCube(){

        for(int i = 0;i<6;i++){

            for(int j = 0;j<3;j++){
                for(int k = 0;k<3;k++){
                    cubeState[i,j,k] = (CubeFace)i;
                }
            }
        }

    }

    public void SetState(string state){

        if(state.Length != 54){
            throw new ArgumentException("State string length must be 54!");
        }

        for(int i = 0;i<state.Length;i++){
            if(!"UDRLFB".Contains(state[i])){
                throw new ArgumentException("State can only have 'U', 'D', 'R', 'L', 'F', 'B' characters!");
            }
        }

        int idx = 0;
        for(int i = 0;i<3;i++){
            for(int j = 0;j<3;j++){
                this[CubeFace.Up, i,j] = CharToCubeFace(state[idx]);
                this[CubeFace.Right, i,j] = CharToCubeFace(state[idx + 9]);
                this[CubeFace.Front, i,j] = CharToCubeFace(state[idx + 18]);
                this[CubeFace.Down, i,j] = CharToCubeFace(state[idx + 27]);
                this[CubeFace.Left, i,j] = CharToCubeFace(state[idx + 36]);
                this[CubeFace.Back, i,j] = CharToCubeFace(state[idx + 45]);
                idx++;
            }
        }

    }

    private CubeFace CharToCubeFace(char face) => face switch{
        'U' => CubeFace.Up,
        'D' => CubeFace.Down,
        'L' => CubeFace.Left,
        'R' => CubeFace.Right,
        'F' => CubeFace.Front,
        'B' => CubeFace.Back,
        _ => throw new ArgumentException($"Wrong face character! {face}")
    };

    public void DoRotation(CubeFace cubeFace, int rotations){
        rotations = ((rotations % 4) + 4) % 4;

        (CubeFace cubeFace, int row, int col)[,] group = groups[cubeFace];

        for(int i = 0;i<5;i++){

            Span<CubeFace> cubeColors = stackalloc CubeFace[4]{
                cubeState[(int)group[i,0].cubeFace, group[i,0].row, group[i,0].col],
                cubeState[(int)group[i,1].cubeFace, group[i,1].row, group[i,1].col],
                cubeState[(int)group[i,2].cubeFace, group[i,2].row, group[i,2].col],
                cubeState[(int)group[i,3].cubeFace, group[i,3].row, group[i,3].col],
            };

            cubeState[(int)group[i,0].cubeFace, group[i,0].row, group[i,0].col] = cubeColors[(4 - rotations) % 4];
            cubeState[(int)group[i,1].cubeFace, group[i,1].row, group[i,1].col] = cubeColors[(5 - rotations) % 4];
            cubeState[(int)group[i,2].cubeFace, group[i,2].row, group[i,2].col] = cubeColors[(6 - rotations) % 4];
            cubeState[(int)group[i,3].cubeFace, group[i,3].row, group[i,3].col] = cubeColors[(7 - rotations) % 4];

        }

    }

    public void ApplyAlgorithm(string algorithm){
        
        algorithm = Algorithms.NormalizeAlgorithm(algorithm);

        var moveMap = new Dictionary<char, CubeFace>{
            { 'L', CubeFace.Left },
            { 'F', CubeFace.Front },
            { 'R', CubeFace.Right },
            { 'B', CubeFace.Back },
            { 'U', CubeFace.Up },
            { 'D', CubeFace.Down }
        };

        string[] moves = algorithm.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        foreach(var move in moves){
            if(move.Length == 0) continue;

            char faceChar = move[0];
            if(!moveMap.TryGetValue(faceChar, out CubeFace face))
                throw new ArgumentException($"Invalid face in move: {move}");

            int rotations = 1;
            if(move.Length > 1){
                if(move[1] == '\''){
                    rotations = 3;
                }
                else if (move[1] == '2'){
                    rotations = 2;
                }
                else{
                    throw new ArgumentException($"Invalid rotation modifier in move: {move}");
                }
            }

            DoRotation(face, rotations);
        }
    }
    
    private void PrintGroups(){

        foreach(var kvp in groups){
            Debug.Log(kvp.Key);
            StringBuilder sb = new StringBuilder();
            for(int i = 0;i<kvp.Value.GetLength(0);i++){
                for(int j = 0;j<kvp.Value.GetLength(1);j++){
                    sb.Append($"{kvp.Value[i,j]} ");
                }
                sb.Append("\n");
            }
            Debug.Log(sb.ToString());
        }

    }

}
