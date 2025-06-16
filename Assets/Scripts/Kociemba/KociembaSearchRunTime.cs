using System;
using UnityEngine;

namespace KociembaSolver{

    public class KociembaSearchRunTime{
        internal static int[] ax = new int[31];

        internal static int[] po = new int[31];

        internal static int[] flip = new int[31];

        internal static int[] twist = new int[31];

        internal static int[] slice = new int[31];

        internal static int[] parity = new int[31];

        internal static int[] URFtoDLF = new int[31];

        internal static int[] FRtoBR = new int[31];

        internal static int[] URtoUL = new int[31];

        internal static int[] UBtoDF = new int[31];

        internal static int[] URtoDF = new int[31];

        internal static int[] minDistPhase1 = new int[31];

        internal static int[] minDistPhase2 = new int[31];

        internal static string SolutionToString(int length){
            string s = "";
            for(int i = 0; i < length; i++){
                switch(ax[i]){
                case 0:
                    s += "U";
                    break;
                case 1:
                    s += "R";
                    break;
                case 2:
                    s += "F";
                    break;
                case 3:
                    s += "D";
                    break;
                case 4:
                    s += "L";
                    break;
                case 5:
                    s += "B";
                    break;
                }
                switch(po[i]){
                case 1:
                    s += " ";
                    break;
                case 2:
                    s += "2 ";
                    break;
                case 3:
                    s += "' ";
                    break;
                }
            }
            return s;
        }

        internal static string SolutionToString(int length, int depthPhase1){
            string s = "";
            for(int i = 0; i < length; i++){
                switch(ax[i]){
                case 0:
                    s += "U";
                    break;
                case 1:
                    s += "R";
                    break;
                case 2:
                    s += "F";
                    break;
                case 3:
                    s += "D";
                    break;
                case 4:
                    s += "L";
                    break;
                case 5:
                    s += "B";
                    break;
                }
                switch(po[i]){
                case 1:
                    s += " ";
                    break;
                case 2:
                    s += "2 ";
                    break;
                case 3:
                    s += "' ";
                    break;
                }
                if(i == depthPhase1 - 1){
                    s += ". ";
                }
            }
            return s;
        }

        public static string Solution(string facelets, int maxDepth = 22, long timeOut = 6000L, bool useSeparator = false, bool buildTables = false){
            if(facelets == "UUUUUUUUURRRRRRRRRFFFFFFFFFDDDDDDDDDLLLLLLLLLBBBBBBBBB"){
                return "";
            }
            int[] count = new int[6];
            try{
                for(int i = 0; i < 54; i++){
                    count[(int)Enum.Parse<CubeColor>(facelets.Substring(i, 1))]++;
                }
            }
            catch(Exception){
                throw new ArgumentException("Facelets are in wrong format!");
            }
            for(int j = 0; j < 6; j++){
                if(count[j] != 9){
                    throw new ArgumentException($"Found {count[j]} facelets of {(CubeColor)j} color. Should be 9.");
                }
            }
            FaceCube fc = new(facelets);
            CubieCube cc = fc.ToCubieCube();
            int s;
            if((s = cc.Verify()) != 0){
                string error = "Cube is not solvable!";
                switch(Math.Abs(s)){
                    case 2:
                        error = "Edge appeared 0 or 2+ times in cube!";
                        break;
                    case 3:
                        error = "One edge is flipped! Cube is not solvable!";
                        break;
                    case 4:
                        error = "Corner appeared 0 or 2+ times in cube!";
                        break;
                    case 5:
                        error = "Corner orientation sum is not divisible by 3! Cube is not solvable!";
                        break;
                    case 6:
                        error = "Corner and edge swaps sum is not even! Cube is not solvable!";
                        break;
                }
                throw new ArgumentException(error);
            }
            if(buildTables){
                Debug.Log("Generating tables at " + Kociemba.TABLES_FOLDER_PATH);
            }
            CoordCubeBuildTables c = new(cc, buildTables);
            po[0] = 0;
            ax[0] = 0;
            flip[0] = c.flip;
            twist[0] = c.twist;
            parity[0] = c.parity;
            slice[0] = c.FRtoBR / 24;
            URFtoDLF[0] = c.URFtoDLF;
            FRtoBR[0] = c.FRtoBR;
            URtoUL[0] = c.URtoUL;
            UBtoDF[0] = c.UBtoDF;
            minDistPhase1[1] = 1;
            int k = 0;
            bool busy = false;
            int depthPhase1 = 1;
            long tStart = DateTimeHelper.CurrentUnixTimeMillis();
            while(true){
                if(depthPhase1 - k > minDistPhase1[k + 1] && !busy){
                    if(ax[k] == 0 || ax[k] == 3){
                        ax[++k] = 1;
                    }
                    else{
                        ax[++k] = 0;
                    }
                    po[k] = 1;
                }
                else if(++po[k] > 3){
                    do{
                        if(++ax[k] > 5){
                            if(DateTimeHelper.CurrentUnixTimeMillis() - tStart > timeOut << 10){
                                return "Error 8";
                            }
                            if(k == 0){
                                if(depthPhase1 >= maxDepth){
                                    return "Error 7";
                                }
                                depthPhase1++;
                                ax[k] = 0;
                                po[k] = 1;
                                busy = false;
                                break;
                            }
                            k--;
                            busy = true;
                            break;
                        }
                        po[k] = 1;
                        busy = false;
                    }
                    while(k != 0 && (ax[k - 1] == ax[k] || ax[k - 1] - 3 == ax[k]));
                }
                else{
                    busy = false;
                }
                if(busy){
                    continue;
                }
                int mv = 3 * ax[k] + po[k] - 1;
                flip[k + 1] = CoordCubeBuildTables.flipMove[flip[k], mv];
                twist[k + 1] = CoordCubeBuildTables.twistMove[twist[k], mv];
                slice[k + 1] = CoordCubeBuildTables.FRtoBR_Move[slice[k] * 24, mv] / 24;
                minDistPhase1[k + 1] = Math.Max(CoordCubeBuildTables.GetPruning(CoordCubeBuildTables.Slice_Flip_Prun, 495 * flip[k + 1] + slice[k + 1]), CoordCubeBuildTables.GetPruning(CoordCubeBuildTables.Slice_Twist_Prun, 495 * twist[k + 1] + slice[k + 1]));
                if(minDistPhase1[k + 1] == 0 && k >= depthPhase1 - 5){
                    minDistPhase1[k + 1] = 10;
                    if(k == depthPhase1 - 1 && (s = TotalDepth(depthPhase1, maxDepth)) >= 0 && (s == depthPhase1 || (ax[depthPhase1 - 1] != ax[depthPhase1] && ax[depthPhase1 - 1] != ax[depthPhase1] + 3))){
                        break;
                    }
                }
            }
            return useSeparator ? SolutionToString(s, depthPhase1) : SolutionToString(s);
        }

        internal static int TotalDepth(int depthPhase1, int maxDepth){
            int maxDepthPhase2 = Math.Min(10, maxDepth - depthPhase1);
            int mv;
            for (int i = 0; i < depthPhase1; i++)
            {
                mv = 3 * ax[i] + po[i] - 1;
                URFtoDLF[i + 1] = CoordCubeBuildTables.URFtoDLF_Move[URFtoDLF[i], mv];
                FRtoBR[i + 1] = CoordCubeBuildTables.FRtoBR_Move[FRtoBR[i], mv];
                parity[i + 1] = CoordCubeBuildTables.parityMove[parity[i]][mv];
            }
            int d1;
            if ((d1 = CoordCubeBuildTables.GetPruning(CoordCubeBuildTables.Slice_URFtoDLF_Parity_Prun, (24 * URFtoDLF[depthPhase1] + FRtoBR[depthPhase1]) * 2 + parity[depthPhase1])) > maxDepthPhase2)
            {
                return -1;
            }
            for (int j = 0; j < depthPhase1; j++){
                mv = 3 * ax[j] + po[j] - 1;
                URtoUL[j + 1] = CoordCubeBuildTables.URtoUL_Move[URtoUL[j], mv];
                UBtoDF[j + 1] = CoordCubeBuildTables.UBtoDF_Move[UBtoDF[j], mv];
            }
            URtoDF[depthPhase1] = CoordCubeBuildTables.MergeURtoULandUBtoDF[URtoUL[depthPhase1], UBtoDF[depthPhase1]];
            int d2;
            if ((d2 = CoordCubeBuildTables.GetPruning(CoordCubeBuildTables.Slice_URtoDF_Parity_Prun, (24 * URtoDF[depthPhase1] + FRtoBR[depthPhase1]) * 2 + parity[depthPhase1])) > maxDepthPhase2)
            {
                return -1;
            }
            if ((minDistPhase2[depthPhase1] = Math.Max(d1, d2)) == 0){
                return depthPhase1;
            }
            int depthPhase2 = 1;
            int k = depthPhase1;
            bool busy = false;
            po[depthPhase1] = 0;
            ax[depthPhase1] = 0;
            minDistPhase2[k + 1] = 1;
            while(true){
                if(depthPhase1 + depthPhase2 - k > minDistPhase2[k + 1] && !busy){
                    if(ax[k] == 0 || ax[k] == 3){
                        ax[++k] = 1;
                        po[k] = 2;
                    }
                    else{
                        ax[++k] = 0;
                        po[k] = 1;
                    }
                }
                else if((ax[k] == 0 || ax[k] == 3) ? (++po[k] > 3) : ((po[k] += 2) > 3)){
                    do{
                        if(++ax[k] > 5){
                            if(k == depthPhase1){
                                if(depthPhase2 >= maxDepthPhase2){
                                    return -1;
                                }
                                depthPhase2++;
                                ax[k] = 0;
                                po[k] = 1;
                                busy = false;
                                break;
                            }
                            k--;
                            busy = true;
                            break;
                        }
                        if(ax[k] == 0 || ax[k] == 3){
                            po[k] = 1;
                        }
                        else{
                            po[k] = 2;
                        }
                        busy = false;
                    }
                    while(k != depthPhase1 && (ax[k - 1] == ax[k] || ax[k - 1] - 3 == ax[k]));
                }
                else{
                    busy = false;
                }
                if(!busy){
                    mv = 3 * ax[k] + po[k] - 1;
                    URFtoDLF[k + 1] = CoordCubeBuildTables.URFtoDLF_Move[URFtoDLF[k], mv];
                    FRtoBR[k + 1] = CoordCubeBuildTables.FRtoBR_Move[FRtoBR[k], mv];
                    parity[k + 1] = CoordCubeBuildTables.parityMove[parity[k]][mv];
                    URtoDF[k + 1] = CoordCubeBuildTables.URtoDF_Move[URtoDF[k], mv];
                    minDistPhase2[k + 1] = Math.Max(CoordCubeBuildTables.GetPruning(CoordCubeBuildTables.Slice_URtoDF_Parity_Prun, (24 * URtoDF[k + 1] + FRtoBR[k + 1]) * 2 + parity[k + 1]), CoordCubeBuildTables.GetPruning(CoordCubeBuildTables.Slice_URFtoDLF_Parity_Prun, (24 * URFtoDLF[k + 1] + FRtoBR[k + 1]) * 2 + parity[k + 1]));
                    if(minDistPhase2[k + 1] == 0){
                        break;
                    }
                }
            }
            return depthPhase1 + depthPhase2;
        }
    }
}