using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class RubiksCube{

    private Dictionary<CubeFace, int[,]> groups = new();

    private readonly CubeSide[] sides = new CubeSide[6]{
        new(CubeFace.Left),
        new(CubeFace.Front),
        new(CubeFace.Right),
        new(CubeFace.Back),
        new(CubeFace.Up),
        new(CubeFace.Down),
    };

    private CubeSide this[CubeFace cubeFace]{
        get{
            return sides.FirstOrDefault(s => s.CubeFace == cubeFace) ?? throw new InvalidOperationException($"Cannot find {cubeFace} face in cube");
        }
    }

    public RubiksCube(){

        foreach(var side in sides){

            int[,] group = new int[5,4];

            group[0,0] = side[0,0];
            group[0,1] = side[0,2];
            group[0,2] = side[2,2];
            group[0,3] = side[2,0];

            group[1,0] = side[0,1];
            group[1,1] = side[1,2];
            group[1,2] = side[2,1];
            group[1,3] = side[1,0];

            int[,] upSide = GetUpperNeighbourSideMatrix(side.CubeFace);
            int[,] downSide = GetDownNeighbourSideMatrix(side.CubeFace);
            int[,] rightSide = GetRightNeighbourSideMatrix(side.CubeFace);
            int[,] leftSide = GetLeftNeighbourSideMatrix(side.CubeFace);

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

            groups[side.CubeFace] = group;

        }
    }

    private int[,] GetUpperNeighbourSideMatrix(CubeFace cubeFace){
        return cubeFace switch{
            CubeFace.Left => this[CubeFace.Up].RotatedMatrix(-1),
            CubeFace.Front => this[CubeFace.Up].Matrix,
            CubeFace.Right => this[CubeFace.Up].RotatedMatrix(1),
            CubeFace.Back => this[CubeFace.Up].RotatedMatrix(2),
            CubeFace.Up => this[CubeFace.Back].RotatedMatrix(2),
            CubeFace.Down => this[CubeFace.Front].Matrix,
            _ => throw new ArgumentException("Invalid parameter name", nameof(cubeFace)),
        };
    }

    private int[,] GetDownNeighbourSideMatrix(CubeFace cubeFace){
        return cubeFace switch{
            CubeFace.Left => this[CubeFace.Down].RotatedMatrix(1),
            CubeFace.Front => this[CubeFace.Down].Matrix,
            CubeFace.Right => this[CubeFace.Down].RotatedMatrix(-1),
            CubeFace.Back => this[CubeFace.Down].RotatedMatrix(2),
            CubeFace.Up => this[CubeFace.Front].Matrix,
            CubeFace.Down => this[CubeFace.Back].RotatedMatrix(2),
            _ => throw new ArgumentException("Invalid parameter name", nameof(cubeFace)),
        };
    }

    private int[,] GetRightNeighbourSideMatrix(CubeFace cubeFace){
        return cubeFace switch{
            CubeFace.Left => this[CubeFace.Front].Matrix,
            CubeFace.Front => this[CubeFace.Right].Matrix,
            CubeFace.Right => this[CubeFace.Back].Matrix,
            CubeFace.Back => this[CubeFace.Left].Matrix,
            CubeFace.Up => this[CubeFace.Right].RotatedMatrix(-1),
            CubeFace.Down => this[CubeFace.Right].RotatedMatrix(1),
            _ => throw new ArgumentException("Invalid parameter name", nameof(cubeFace)),
        };
    }

    private int[,] GetLeftNeighbourSideMatrix(CubeFace cubeFace){
        return cubeFace switch{
            CubeFace.Left => this[CubeFace.Back].Matrix,
            CubeFace.Front => this[CubeFace.Left].Matrix,
            CubeFace.Right => this[CubeFace.Front].Matrix,
            CubeFace.Back => this[CubeFace.Right].Matrix,
            CubeFace.Up => this[CubeFace.Left].RotatedMatrix(1),
            CubeFace.Down => this[CubeFace.Left].RotatedMatrix(-1),
            _ => throw new ArgumentException("Invalid parameter name", nameof(cubeFace)),
        };
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

        private int[,] matrix = new int[3,3];

        public CubeFace CubeFace{get;}

        public int this[int row, int col]{
            get => matrix[row, col];
        }

        public int[,] Matrix{
            get{
                int[,] result = new int[3,3];
                for(int i = 0;i<3;i++){
                    for(int j = 0;j<3;j++){
                        result[i,j] = matrix[i,j];
                    }
                }
                return result;
            }
        }

        public CubeSide(CubeFace cubeFace) : this(((int)cubeFace - 1) * 8){
            CubeFace = cubeFace;
        }

        public CubeSide(int startIndex){
            for(int i = 0;i<3;i++){
                for(int j = 0;j<3;j++){
                    if(i==1 && j==1){
                        matrix[i,j] = -1;
                        continue;
                    }
                    matrix[i,j] = startIndex++;
                }
            }
        }

        public CubeSide(int[,] matrix){
            this.matrix = matrix;
        }

        public int[,] RotatedMatrix(int rotations){

            int normalizedRotations = ((rotations % 4) + 4) % 4;

            int[,] matrix = Matrix;

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

    }

}

public enum CubeFace{
    None = 0,
    Left = 1,
    Front = 2,
    Right = 3,
    Back = 4,
    Up = 5,
    Down = 6
}

public enum CubeColor{
    None = 0,
    Orange = 1,
    Green = 2,
    Red = 3,
    Blue = 4,
    White = 5,
    Yellow = 6
}