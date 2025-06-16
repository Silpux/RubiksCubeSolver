using System;

namespace KociembaSolver{

    public class CoordCube{

        internal const short N_TWIST = 2187;

        internal const short N_FLIP = 2048;

        internal const short N_SLICE1 = 495;

        internal const short N_SLICE2 = 24;

        internal const short N_PARITY = 2;

        internal const short N_URFtoDLF = 20160;

        internal const short N_FRtoBR = 11880;

        internal const short N_URtoUL = 1320;

        internal const short N_UBtoDF = 1320;

        internal const short N_URtoDF = 20160;

        internal const int N_URFtoDLB = 40320;

        internal const int N_URtoBR = 479001600;

        internal const short N_MOVE = 18;

        internal short twist;

        internal short flip;

        internal short parity;

        internal short FRtoBR;

        internal short URFtoDLF;

        internal short URtoUL;

        internal short UBtoDF;

        internal int URtoDF;

        internal static readonly short[,] twistMove = CoordCubeTables.twist;

        internal static readonly short[,] flipMove = CoordCubeTables.flip;

        internal static readonly short[][] parityMove = new short[2][]{
            new short[18]{
                1, 0, 1, 1, 0, 1, 1, 0, 1, 1,
                0, 1, 1, 0, 1, 1, 0, 1
            },
            new short[18]{
                0, 1, 0, 0, 1, 0, 0, 1, 0, 0,
                1, 0, 0, 1, 0, 0, 1, 0
            }
        };

        internal static readonly short[,] FRtoBR_Move = CoordCubeTables.FRtoBR;

        internal static readonly short[,] URFtoDLF_Move = CoordCubeTables.URFtoDLF;

        internal static readonly short[,] URtoDF_Move = CoordCubeTables.URtoDF;

        internal static readonly short[,] URtoUL_Move = CoordCubeTables.URtoUL;

        internal static readonly short[,] UBtoDF_Move = CoordCubeTables.UBtoDF;

        internal static readonly short[,] MergeURtoULandUBtoDF = CoordCubeTables.MergeURtoULandUBtoDF;

        internal static readonly sbyte[] Slice_URFtoDLF_Parity_Prun = CoordCubeTables.Slice_URFtoDLF_Parity_Prun;

        internal static readonly sbyte[] Slice_URtoDF_Parity_Prun = CoordCubeTables.Slice_URtoDF_Parity_Prun;

        internal static readonly sbyte[] Slice_Twist_Prun = CoordCubeTables.Slice_Twist_Prun;

        internal static readonly sbyte[] Slice_Flip_Prun = CoordCubeTables.Slice_Flip_Prun;

        internal CoordCube(CubieCube c){
            twist = c.GetTwist();
            flip = c.GetFlip();
            parity = c.CornerParity();
            FRtoBR = c.GetFRtoBR();
            URFtoDLF = c.GetURFtoDLF();
            URtoUL = c.GetURtoUL();
            UBtoDF = c.GetUBtoDF();
            URtoDF = c.GetURtoDF();
        }

        internal virtual void Move(int m){
            twist = twistMove[twist, m];
            flip = flipMove[flip, m];
            parity = parityMove[parity][m];
            FRtoBR = FRtoBR_Move[FRtoBR, m];
            URFtoDLF = URFtoDLF_Move[URFtoDLF, m];
            URtoUL = URtoUL_Move[URtoUL, m];
            UBtoDF = UBtoDF_Move[UBtoDF, m];
            if(URtoUL < 336 && UBtoDF < 336){
                URtoDF = MergeURtoULandUBtoDF[URtoUL, UBtoDF];
            }
        }

        internal static void SetPruning(sbyte[] table, int index, sbyte value){
            if((index & 1) == 0){
                table[index / 2] &= (sbyte)(0xF0 | value);
            }
            else{
                table[index / 2] &= (sbyte)(0xF | (value << 4));
            }
        }

        internal static sbyte GetPruning(sbyte[] table, int index){
            if((index & 1) == 0){
                return (sbyte)(table[index / 2] & 0xF);
            }
            return (sbyte)((uint)(table[index / 2] & 0xF0) >> 4);
        }
    }

    public static class CoordCubeTables{
        public static readonly short[,] twist = Tools.DeserializeTable("twist");

        public static readonly short[,] flip = Tools.DeserializeTable("flip");

        public static readonly short[,] FRtoBR = Tools.DeserializeTable("FRtoBR");

        public static readonly short[,] URFtoDLF = Tools.DeserializeTable("URFtoDLF");

        public static readonly short[,] URtoDF = Tools.DeserializeTable("URtoDF");

        public static readonly short[,] URtoUL = Tools.DeserializeTable("URtoUL");

        public static readonly short[,] UBtoDF = Tools.DeserializeTable("UBtoDF");

        public static readonly short[,] MergeURtoULandUBtoDF = Tools.DeserializeTable("MergeURtoULandUBtoDF");

        public static readonly sbyte[] Slice_URFtoDLF_Parity_Prun = Tools.DeserializeSbyteArray("Slice_URFtoDLF_Parity_Prun");

        public static readonly sbyte[] Slice_URtoDF_Parity_Prun = Tools.DeserializeSbyteArray("Slice_URtoDF_Parity_Prun");

        public static readonly sbyte[] Slice_Twist_Prun = Tools.DeserializeSbyteArray("Slice_Twist_Prun");

        public static readonly sbyte[] Slice_Flip_Prun = Tools.DeserializeSbyteArray("Slice_Flip_Prun");
    }

}
