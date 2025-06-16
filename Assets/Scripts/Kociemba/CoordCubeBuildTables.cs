

namespace KociembaSolver{
    public class CoordCubeBuildTables{
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

        internal static short[,] twistMove;

        internal static short[,] flipMove;

        internal static short[][] parityMove;

        internal static short[,] FRtoBR_Move;

        internal static short[,] URFtoDLF_Move;

        internal static short[,] URtoDF_Move;

        internal static short[,] URtoUL_Move;

        internal static short[,] UBtoDF_Move;

        internal static short[,] MergeURtoULandUBtoDF;

        internal static sbyte[] Slice_URFtoDLF_Parity_Prun;

        internal static sbyte[] Slice_URtoDF_Parity_Prun;

        internal static sbyte[] Slice_Twist_Prun;

        internal static sbyte[] Slice_Flip_Prun;

        internal CoordCubeBuildTables(CubieCube c, bool unpackTables = false){
            twist = c.GetTwist();
            flip = c.GetFlip();
            parity = c.CornerParity();
            FRtoBR = c.GetFRtoBR();
            URFtoDLF = c.GetURFtoDLF();
            URtoUL = c.GetURtoUL();
            UBtoDF = c.GetUBtoDF();
            URtoDF = c.GetURtoDF();
            if(unpackTables){
                Tools.SerializeTable("twist", twistMove);
                Tools.SerializeTable("flip", flipMove);
                Tools.SerializeTable("FRtoBR", FRtoBR_Move);
                Tools.SerializeTable("URFtoDLF", URFtoDLF_Move);
                Tools.SerializeTable("URtoDF", URtoDF_Move);
                Tools.SerializeTable("URtoUL", URtoUL_Move);
                Tools.SerializeTable("UBtoDF", UBtoDF_Move);
                Tools.SerializeTable("MergeURtoULandUBtoDF", MergeURtoULandUBtoDF);
                Tools.SerializeSbyteArray("Slice_URFtoDLF_Parity_Prun", Slice_URFtoDLF_Parity_Prun);
                Tools.SerializeSbyteArray("Slice_URtoDF_Parity_Prun", Slice_URtoDF_Parity_Prun);
                Tools.SerializeSbyteArray("Slice_Twist_Prun", Slice_Twist_Prun);
                Tools.SerializeSbyteArray("Slice_Flip_Prun", Slice_Flip_Prun);
            }
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

        static CoordCubeBuildTables(){
            twistMove = new short[2187, 18];
            flipMove = new short[2048, 18];
            parityMove = new short[2][]{
                new short[18]{
                    1, 0, 1, 1, 0, 1, 1, 0, 1, 1,
                    0, 1, 1, 0, 1, 1, 0, 1
                },
                new short[18]{
                    0, 1, 0, 0, 1, 0, 0, 1, 0, 0,
                    1, 0, 0, 1, 0, 0, 1, 0
                }
            };
            FRtoBR_Move = new short[11880, 18];
            URFtoDLF_Move = new short[20160, 18];
            URtoDF_Move = new short[20160, 18];
            URtoUL_Move = new short[1320, 18];
            UBtoDF_Move = new short[1320, 18];
            MergeURtoULandUBtoDF = new short[336, 336];
            Slice_URFtoDLF_Parity_Prun = new sbyte[483840];
            Slice_URtoDF_Parity_Prun = new sbyte[483840];
            Slice_Twist_Prun = new sbyte[541283];
            Slice_Flip_Prun = new sbyte[506880];
            CubieCube a = new();
            for(short i = 0; i < 2187; i = (short)(i + 1)){
                a.SetTwist(i);
                for(int j2 = 0; j2 < 6; j2++){
                    for(int k2 = 0; k2 < 3; k2++){
                        a.CornerMultiply(CubieCube.moveCube[j2]);
                        twistMove[i, 3 * j2 + k2] = a.GetTwist();
                    }
                    a.CornerMultiply(CubieCube.moveCube[j2]);
                }
            }
            a = new CubieCube();
            for(short j = 0; j < 2048; j = (short)(j + 1)){
                a.SetFlip(j);
                for(int j3 = 0; j3 < 6; j3++){
                    for(int k3 = 0; k3 < 3; k3++){
                        a.EdgeMultiply(CubieCube.moveCube[j3]);
                        flipMove[j, 3 * j3 + k3] = a.GetFlip();
                    }
                    a.EdgeMultiply(CubieCube.moveCube[j3]);
                }
            }
            a = new CubieCube();
            for(short k = 0; k < 11880; k = (short)(k + 1)){
                a.SetFRtoBR(k);
                for(int j4 = 0; j4 < 6; j4++){
                    for(int k4 = 0; k4 < 3; k4++){
                        a.EdgeMultiply(CubieCube.moveCube[j4]);
                        FRtoBR_Move[k, 3 * j4 + k4] = a.GetFRtoBR();
                    }
                    a.EdgeMultiply(CubieCube.moveCube[j4]);
                }
            }
            a = new CubieCube();
            for(short m = 0; m < 20160; m = (short)(m + 1)){
                a.SetURFtoDLF(m);
                for(int j5 = 0; j5 < 6; j5++){
                    for(int k5 = 0; k5 < 3; k5++){
                        a.CornerMultiply(CubieCube.moveCube[j5]);
                        URFtoDLF_Move[m, 3 * j5 + k5] = a.GetURFtoDLF();
                    }
                    a.CornerMultiply(CubieCube.moveCube[j5]);
                }
            }
            a = new CubieCube();
            for(short i10 = 0; i10 < 20160; i10 = (short)(i10 + 1)){
                a.SetURtoDF(i10);
                for(int j6 = 0; j6 < 6; j6++){
                    for(int k6 = 0; k6 < 3; k6++){
                        a.EdgeMultiply(CubieCube.moveCube[j6]);
                        URtoDF_Move[i10, 3 * j6 + k6] = (short)a.GetURtoDF();
                    }
                    a.EdgeMultiply(CubieCube.moveCube[j6]);
                }
            }
            a = new CubieCube();
            for(short i9 = 0; i9 < 1320; i9 = (short)(i9 + 1)){
                a.SetURtoUL(i9);
                for(int j7 = 0; j7 < 6; j7++){
                    for(int k7 = 0; k7 < 3; k7++){
                        a.EdgeMultiply(CubieCube.moveCube[j7]);
                        URtoUL_Move[i9, 3 * j7 + k7] = a.GetURtoUL();
                    }
                    a.EdgeMultiply(CubieCube.moveCube[j7]);
                }
            }
            a = new CubieCube();
            for(short i8 = 0; i8 < 1320; i8 = (short)(i8 + 1)){
                a.SetUBtoDF(i8);
                for(int j8 = 0; j8 < 6; j8++){
                    for(int k8 = 0; k8 < 3; k8++){
                        a.EdgeMultiply(CubieCube.moveCube[j8]);
                        UBtoDF_Move[i8, 3 * j8 + k8] = a.GetUBtoDF();
                    }
                    a.EdgeMultiply(CubieCube.moveCube[j8]);
                }
            }
            for(short uRtoUL = 0; uRtoUL < 336; uRtoUL = (short)(uRtoUL + 1)){
                for(short uBtoDF = 0; uBtoDF < 336; uBtoDF = (short)(uBtoDF + 1)){
                    MergeURtoULandUBtoDF[uRtoUL, uBtoDF] = (short)CubieCube.GetURtoDF(uRtoUL, uBtoDF);
                }
            }
            for(int i7 = 0; i7 < 483840; i7++){
                Slice_URFtoDLF_Parity_Prun[i7] = -1;
            }
            int depth = 0;
            SetPruning(Slice_URFtoDLF_Parity_Prun, 0, 0);
            int done = 1;
            while(done != 967680){
                for(int l = 0; l < 967680; l++){
                    int parity = l % 2;
                    int URFtoDLF = l / 2 / 24;
                    int slice = l / 2 % 24;
                    if(GetPruning(Slice_URFtoDLF_Parity_Prun, l) != depth){
                        continue;
                    }
                    for(int j9 = 0; j9 < 18; j9++){
                        switch(j9){
                        case 3:
                        case 5:
                        case 6:
                        case 8:
                        case 12:
                        case 14:
                        case 15:
                        case 17:
                            continue;
                        }
                        int newSlice = FRtoBR_Move[slice, j9];
                        int newURFtoDLF = URFtoDLF_Move[URFtoDLF, j9];
                        int newParity = parityMove[parity][j9];
                        if(GetPruning(Slice_URFtoDLF_Parity_Prun, (24 * newURFtoDLF + newSlice) * 2 + newParity) == 15){
                            SetPruning(Slice_URFtoDLF_Parity_Prun, (24 * newURFtoDLF + newSlice) * 2 + newParity, (sbyte)(depth + 1));
                            done++;
                        }
                    }
                }
                depth++;
            }
            for(int i6 = 0; i6 < 483840; i6++){
                Slice_URtoDF_Parity_Prun[i6] = -1;
            }
            depth = 0;
            SetPruning(Slice_URtoDF_Parity_Prun, 0, 0);
            done = 1;
            while(done != 967680){
                for(int n = 0; n < 967680; n++){
                    int parity2 = n % 2;
                    int URtoDF = n / 2 / 24;
                    int slice2 = n / 2 % 24;
                    if(GetPruning(Slice_URtoDF_Parity_Prun, n) != depth){
                        continue;
                    }
                    for(int j10 = 0; j10 < 18; j10++){
                        switch(j10){
                        case 3:
                        case 5:
                        case 6:
                        case 8:
                        case 12:
                        case 14:
                        case 15:
                        case 17:
                            continue;
                        }
                        int newSlice2 = FRtoBR_Move[slice2, j10];
                        int newURtoDF = URtoDF_Move[URtoDF, j10];
                        int newParity2 = parityMove[parity2][j10];
                        if(GetPruning(Slice_URtoDF_Parity_Prun, (24 * newURtoDF + newSlice2) * 2 + newParity2) == 15){
                            SetPruning(Slice_URtoDF_Parity_Prun, (24 * newURtoDF + newSlice2) * 2 + newParity2, (sbyte)(depth + 1));
                            done++;
                        }
                    }
                }
                depth++;
            }
            for(int i5 = 0; i5 < 541283; i5++){
                Slice_Twist_Prun[i5] = -1;
            }
            depth = 0;
            SetPruning(Slice_Twist_Prun, 0, 0);
            done = 1;
            while(done != 1082565){
                for(int i2 = 0; i2 < 1082565; i2++){
                    int twist = i2 / 495;
                    int slice3 = i2 % 495;
                    if(GetPruning(Slice_Twist_Prun, i2) != depth){
                        continue;
                    }
                    for(int j11 = 0; j11 < 18; j11++){
                        int newSlice3 = FRtoBR_Move[slice3 * 24, j11] / 24;
                        int newTwist = twistMove[twist, j11];
                        if(GetPruning(Slice_Twist_Prun, 495 * newTwist + newSlice3) == 15){
                            SetPruning(Slice_Twist_Prun, 495 * newTwist + newSlice3, (sbyte)(depth + 1));
                            done++;
                        }
                    }
                }
                depth++;
            }
            for(int i4 = 0; i4 < 506880; i4++){
                Slice_Flip_Prun[i4] = -1;
            }
            depth = 0;
            SetPruning(Slice_Flip_Prun, 0, 0);
            done = 1;
            while(done != 1013760){
                for(int i3 = 0; i3 < 1013760; i3++){
                    int flip = i3 / 495;
                    int slice4 = i3 % 495;
                    if(GetPruning(Slice_Flip_Prun, i3) != depth){
                        continue;
                    }
                    for(int j12 = 0; j12 < 18; j12++){
                        int newSlice4 = FRtoBR_Move[slice4 * 24, j12] / 24;
                        int newFlip = flipMove[flip, j12];
                        if(GetPruning(Slice_Flip_Prun, 495 * newFlip + newSlice4) == 15){
                            SetPruning(Slice_Flip_Prun, 495 * newFlip + newSlice4, (sbyte)(depth + 1));
                            done++;
                        }
                    }
                }
                depth++;
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
}
