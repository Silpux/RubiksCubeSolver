using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class RubiksCube{

    private Dictionary<CubeFace, (CubeFace, int, int)[,]> groups = new();
    private CubeFace[,,] cubeState = new CubeFace[6,3,3];

    public CubeFace this[CubeFace cubeFace, int row, int col]{
        get => cubeState[(int)cubeFace, row, col];
    }

    private (int,int)[,] DefaultMatrix{
        get => new (int,int)[3,3]{
            {(0,0),(0,1),(0,2)},
            {(1,0),(1,1),(1,2)},
            {(2,0),(2,1),(2,2)}
        };
    }

    private const string SOLVED = "UUUUUUUUURRRRRRRRRFFFFFFFFFDDDDDDDDDLLLLLLLLLBBBBBBBBB";

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

    public void Reset(){
        for(int i = 0;i<6;i++){
            for(int j = 0;j<3;j++){
                for(int k = 0;k<3;k++){
                    cubeState[i,j,k] = (CubeFace)i;
                }
            }
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

            (CubeFace cubeFace, int row, int col)[,] group = new (CubeFace, int, int)[5,4];

            group[0,0] = ((CubeFace)i, 0, 0);
            group[0,1] = ((CubeFace)i, 0, 2);
            group[0,2] = ((CubeFace)i, 2, 2);
            group[0,3] = ((CubeFace)i, 2, 0);

            group[1,0] = ((CubeFace)i, 0, 1);
            group[1,1] = ((CubeFace)i, 1, 2);
            group[1,2] = ((CubeFace)i, 2, 1);
            group[1,3] = ((CubeFace)i, 1, 0);

            (CubeFace cubeFace, (int row, int col)[,] matrix) upSide = GetUpperNeighbourSideMatrix((CubeFace)i);
            (CubeFace cubeFace, (int row, int col)[,] matrix) downSide = GetDownNeighbourSideMatrix((CubeFace)i);
            (CubeFace cubeFace, (int row, int col)[,] matrix) rightSide = GetRightNeighbourSideMatrix((CubeFace)i);
            (CubeFace cubeFace, (int row, int col)[,] matrix) leftSide = GetLeftNeighbourSideMatrix((CubeFace)i);

            group[2,0] = (upSide.cubeFace, upSide.matrix[2,0].row, upSide.matrix[2,0].col);
            group[2,1] = (rightSide.cubeFace, rightSide.matrix[0,0].row, rightSide.matrix[0,0].col);
            group[2,2] = (downSide.cubeFace, downSide.matrix[0,2].row, downSide.matrix[0,2].col);
            group[2,3] = (leftSide.cubeFace, leftSide.matrix[2,2].row, leftSide.matrix[2,2].col);

            group[3,0] = (upSide.cubeFace, upSide.matrix[2,2].row, upSide.matrix[2,2].col);
            group[3,1] = (rightSide.cubeFace, rightSide.matrix[2,0].row, rightSide.matrix[2,0].col);
            group[3,2] = (downSide.cubeFace, downSide.matrix[0,0].row, downSide.matrix[0,0].col);
            group[3,3] = (leftSide.cubeFace, leftSide.matrix[0,2].row, leftSide.matrix[0,2].col);

            group[4,0] = (upSide.cubeFace, upSide.matrix[2,1].row, upSide.matrix[2,1].col);
            group[4,1] = (rightSide.cubeFace, rightSide.matrix[1,0].row, rightSide.matrix[1,0].col);
            group[4,2] = (downSide.cubeFace, downSide.matrix[0,1].row, downSide.matrix[0,1].col);
            group[4,3] = (leftSide.cubeFace, leftSide.matrix[1,2].row, leftSide.matrix[1,2].col);

            groups[(CubeFace)i] = group;

        }

    }

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

    private (CubeFace, (int,int)[,]) GetUpperNeighbourSideMatrix(CubeFace cubeFace){
        return cubeFace switch{
            CubeFace.Left => (CubeFace.Up, RotatedMatrix(-1)),
            CubeFace.Front => (CubeFace.Up, DefaultMatrix),
            CubeFace.Right => (CubeFace.Up, RotatedMatrix(1)),
            CubeFace.Back => (CubeFace.Up, RotatedMatrix(2)),
            CubeFace.Up => (CubeFace.Back, RotatedMatrix(2)),
            CubeFace.Down => (CubeFace.Front, DefaultMatrix),
            _ => throw new ArgumentException("Invalid parameter name", nameof(cubeFace)),
        };
    }

    private (CubeFace, (int,int)[,]) GetDownNeighbourSideMatrix(CubeFace cubeFace){
        return cubeFace switch{
            CubeFace.Left => (CubeFace.Down, RotatedMatrix(1)),
            CubeFace.Front => (CubeFace.Down, DefaultMatrix),
            CubeFace.Right => (CubeFace.Down, RotatedMatrix(-1)),
            CubeFace.Back => (CubeFace.Down, RotatedMatrix(2)),
            CubeFace.Up => (CubeFace.Front, DefaultMatrix),
            CubeFace.Down => (CubeFace.Back, RotatedMatrix(2)),
            _ => throw new ArgumentException("Invalid parameter name", nameof(cubeFace)),
        };
    }

    private (CubeFace, (int,int)[,]) GetRightNeighbourSideMatrix(CubeFace cubeFace){
        return cubeFace switch{
            CubeFace.Left => (CubeFace.Front, DefaultMatrix),
            CubeFace.Front => (CubeFace.Right, DefaultMatrix),
            CubeFace.Right => (CubeFace.Back, DefaultMatrix),
            CubeFace.Back => (CubeFace.Left, DefaultMatrix),
            CubeFace.Up => (CubeFace.Right, RotatedMatrix(-1)),
            CubeFace.Down => (CubeFace.Right, RotatedMatrix(1)),
            _ => throw new ArgumentException("Invalid parameter name", nameof(cubeFace)),
        };
    }

    private (CubeFace, (int,int)[,]) GetLeftNeighbourSideMatrix(CubeFace cubeFace){
        return cubeFace switch{
            CubeFace.Left => (CubeFace.Back, DefaultMatrix),
            CubeFace.Front => (CubeFace.Left, DefaultMatrix),
            CubeFace.Right => (CubeFace.Front, DefaultMatrix),
            CubeFace.Back => (CubeFace.Right, DefaultMatrix),
            CubeFace.Up => (CubeFace.Left, RotatedMatrix(1)),
            CubeFace.Down => (CubeFace.Left, RotatedMatrix(-1)),
            _ => throw new ArgumentException("Invalid parameter name", nameof(cubeFace)),
        };
    }

    private (int,int)[,] RotatedMatrix(int rotations){

        int normalizedRotations = ((rotations % 4) + 4) % 4;

        (int,int)[,] matrix = DefaultMatrix;

        for(int r = 0;r<normalizedRotations;r++){
            (int,int)[,] rotated = new (int,int)[3, 3];
            for(int i = 0;i<3;i++){
                for(int j = 0;j<3;j++){
                    rotated[j, 2-i] = matrix[i, j];
                }
            }
            matrix = rotated;
        }

        return matrix;
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
