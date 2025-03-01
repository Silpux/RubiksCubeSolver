using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class RubiksCube{

    private Dictionary<CubeFace, (CubeFace, int, int)[,]> groups = new();
    private CubeColor[,,] cubeState = new CubeColor[6,3,3];

    private (int,int)[,] DefaultMatrix{
        get => new (int,int)[3,3]{
            {(0,0),(0,1),(0,2)},
            {(1,0),(1,1),(1,2)},
            {(2,0),(2,1),(2,2)}
        };
    }

    public RubiksCube(){

        for(int i = 0;i<6;i++){

            for(int j = 0;j<3;j++){
                for(int k = 0;k<3;k++){
                    cubeState[i,j,k] = GetCubeColor((CubeFace)i);
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

        PrintGroups();

    }

    public void DoRotation(CubeFace cubeFace, int rotations){
        rotations = ((rotations % 4) + 4) % 4;



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
            CubeFace.Right => (CubeFace.Down, DefaultMatrix),
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

    private CubeColor GetCubeColor(CubeFace cubeFace){
        return cubeFace switch{
            CubeFace.Left => CubeColor.Orange,
            CubeFace.Front => CubeColor.Green,
            CubeFace.Right => CubeColor.Red,
            CubeFace.Back => CubeColor.Blue,
            CubeFace.Up => CubeColor.White,
            CubeFace.Down => CubeColor.Yellow,
            _ => throw new ArgumentException("Wrong cubeFace parameter", nameof(cubeFace)),
        };
    }

}

public enum CubeFace{
    None = -1,
    Left,
    Front,
    Right,
    Back,
    Up,
    Down
}

public enum CubeColor{
    None = -1,
    Orange,
    Green,
    Red,
    Blue,
    White,
    Yellow
}