using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class RubiksCube{

    private Dictionary<CubeFace, int[,]> groups = new();

    private readonly CubeSide[] sides;

    private CubeSide this[CubeFace cubeFace]{
        get{
            return sides.FirstOrDefault(s => s.CubeFace == cubeFace) ?? throw new InvalidOperationException($"Cannot find {cubeFace} face in cube");
        }
    }

    private int[,,] elementIndexes = new int[6,3,3];

    public RubiksCube(){

        sides = new CubeSide[6];
        int currentElementIndex = 0;
        for(int i = 0;i<6;i++){
            sides[i] = new CubeSide((CubeFace)i);
            for(int j = 0;j<3;j++){
                for(int k = 0;k<3;k++){
                    if(j == 1 && k == 1){
                        elementIndexes[i,j,k] = -1;
                        continue;
                    }
                    elementIndexes[i,j,k] = currentElementIndex++;
                }
            }
        }

        for(int i = 0;i<6;i++){

            int[,] group = new int[5,4];

            group[0,0] = elementIndexes[i,0,0];
            group[0,1] = elementIndexes[i,0,2];
            group[0,2] = elementIndexes[i,2,2];
            group[0,3] = elementIndexes[i,2,0];

            group[1,0] = elementIndexes[i,0,1];
            group[1,1] = elementIndexes[i,1,2];
            group[1,2] = elementIndexes[i,2,1];
            group[1,3] = elementIndexes[i,1,0];

            int[,] upSide = GetUpperNeighbourSideMatrix((CubeFace)i);
            int[,] downSide = GetDownNeighbourSideMatrix((CubeFace)i);
            int[,] rightSide = GetRightNeighbourSideMatrix((CubeFace)i);
            int[,] leftSide = GetLeftNeighbourSideMatrix((CubeFace)i);

            group[2,0] = upSide[2,0];
            group[2,1] = rightSide[0,0];
            group[2,2] = downSide[0,2];
            group[2,3] = leftSide[2,2];

            group[3,0] = upSide[2,2];
            group[3,1] = rightSide[2,0];
            group[3,2] = downSide[0,0];
            group[3,3] = leftSide[0,2];

            group[4,0] = upSide[2,1];
            group[4,1] = rightSide[1,0];
            group[4,2] = downSide[0,1];
            group[4,3] = leftSide[1,2];

            groups[(CubeFace)i] = group;

        }
        PrintGroups();
    }

    private int[,] GetUpperNeighbourSideMatrix(CubeFace cubeFace){
        return cubeFace switch{
            CubeFace.Left => RotatedMatrix(CubeFace.Up, -1),
            CubeFace.Front => MatrixCopy(CubeFace.Up),
            CubeFace.Right => RotatedMatrix(CubeFace.Up, 1),
            CubeFace.Back => RotatedMatrix(CubeFace.Up, 2),
            CubeFace.Up => RotatedMatrix(CubeFace.Back, 2),
            CubeFace.Down => MatrixCopy(CubeFace.Front),
            _ => throw new ArgumentException("Invalid parameter name", nameof(cubeFace)),
        };
    }

    private int[,] GetDownNeighbourSideMatrix(CubeFace cubeFace){
        return cubeFace switch{
            CubeFace.Left => RotatedMatrix(CubeFace.Down, 1),
            CubeFace.Front => MatrixCopy(CubeFace.Down),
            CubeFace.Right => RotatedMatrix(CubeFace.Down, -1),
            CubeFace.Back => RotatedMatrix(CubeFace.Down, 2),
            CubeFace.Up => MatrixCopy(CubeFace.Front),
            CubeFace.Down => RotatedMatrix(CubeFace.Back, 2),
            _ => throw new ArgumentException("Invalid parameter name", nameof(cubeFace)),
        };
    }

    private int[,] GetRightNeighbourSideMatrix(CubeFace cubeFace){
        return cubeFace switch{
            CubeFace.Left => MatrixCopy(CubeFace.Front),
            CubeFace.Front => MatrixCopy(CubeFace.Right),
            CubeFace.Right => MatrixCopy(CubeFace.Back),
            CubeFace.Back => MatrixCopy(CubeFace.Left),
            CubeFace.Up => RotatedMatrix(CubeFace.Right, -1),
            CubeFace.Down => RotatedMatrix(CubeFace.Right, 1),
            _ => throw new ArgumentException("Invalid parameter name", nameof(cubeFace)),
        };
    }

    private int[,] GetLeftNeighbourSideMatrix(CubeFace cubeFace){
        return cubeFace switch{
            CubeFace.Left => MatrixCopy(CubeFace.Back),
            CubeFace.Front => MatrixCopy(CubeFace.Left),
            CubeFace.Right => MatrixCopy(CubeFace.Front),
            CubeFace.Back => MatrixCopy(CubeFace.Right),
            CubeFace.Up => RotatedMatrix(CubeFace.Left, 1),
            CubeFace.Down => RotatedMatrix(CubeFace.Left, -1),
            _ => throw new ArgumentException("Invalid parameter name", nameof(cubeFace)),
        };
    }

    private int[,] MatrixCopy(CubeFace cubeFace){

        int[,] matrix = new int[3,3];

        for(int i = 0;i<3;i++){
            for(int j = 0;j<3;j++){
                matrix[i,j] = elementIndexes[(int)cubeFace, i,j];
            }
        }

        return matrix;

    }

    private int[,] RotatedMatrix(CubeFace cubeFace, int rotations){

        int normalizedRotations = ((rotations % 4) + 4) % 4;

        int[,] matrix = new int[3,3];

        for(int i = 0;i<3;i++){
            for(int j = 0;j<3;j++){
                matrix[i,j] = elementIndexes[(int)cubeFace, i,j];
            }
        }

        for(int r = 0;r<normalizedRotations;r++){
            int[,] rotated = new int[3, 3];
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

    private class CubeSide{

        private CubeColor[,] colors = new CubeColor[3,3];

        public CubeFace CubeFace{get;}

        public CubeColor this[int row, int col]{
            get => colors[row, col];
        }

        public CubeSide(CubeFace cubeFace){
            CubeFace = cubeFace;
            CubeColor color = GetCubeColor(cubeFace);
            for(int i = 0;i<3;i++){
                for(int j = 0;j<3;j++){
                    colors[i,j] = color;
                }
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