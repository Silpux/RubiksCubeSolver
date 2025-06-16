using System;
using System.Linq;

namespace CFOPSolver{

    internal static class Tools{
        public static int ConjugateEdge(int Edge){
            return Edge switch{
                1 => 41, 
                10 => 37, 
                19 => 39, 
                28 => 43, 
                5 => 12, 
                14 => 21, 
                23 => 30, 
                32 => 3, 
                7 => 50, 
                16 => 52, 
                25 => 48, 
                34 => 46, 
                41 => 1, 
                37 => 10, 
                39 => 19, 
                43 => 28, 
                12 => 5, 
                21 => 14, 
                30 => 23, 
                3 => 32, 
                50 => 7, 
                52 => 16, 
                48 => 25, 
                46 => 34, 
                _ => 999, 
            };
        }

        public static string YdPerm(string algo){
            char[] alg = algo.ToCharArray();
            for(int i = 0; i < alg.Length; i++){
                switch(alg[i]){
                case 'R':
                    alg[i] = 'F';
                    break;
                case 'B':
                    alg[i] = 'R';
                    break;
                case 'L':
                    alg[i] = 'B';
                    break;
                case 'F':
                    alg[i] = 'L';
                    break;
                }
            }
            return new string(alg);
        }

        public static string Y2Perm(string algo){
            char[] alg = algo.ToCharArray();
            for(int i = 0; i < alg.Length; i++){
                switch(alg[i]){
                case 'R':
                    alg[i] = 'L';
                    break;
                case 'B':
                    alg[i] = 'F';
                    break;
                case 'L':
                    alg[i] = 'R';
                    break;
                case 'F':
                    alg[i] = 'B';
                    break;
                }
            }
            return new string(alg);
        }

        public static string YPerm(string algo){
            char[] alg = algo.ToCharArray();
            for(int i = 0; i < alg.Length; i++){
                switch(alg[i]){
                case 'R':
                    alg[i] = 'B';
                    break;
                case 'B':
                    alg[i] = 'L';
                    break;
                case 'L':
                    alg[i] = 'F';
                    break;
                case 'F':
                    alg[i] = 'R';
                    break;
                }
            }
            return new string(alg);
        }

        public static void RotateCube(char[] cube, int st, int cn){
            int fa = 0;
            char[] talg = new char[100];
            switch(st){
            case 0:
                switch(cn){
                case 0:
                    talg = " U".ToCharArray();
                    break;
                case 1:
                    talg = " U'".ToCharArray();
                    break;
                case 2:
                    talg = " U2".ToCharArray();
                    break;
                }
                break;
            case 1:
                talg = Constants.crossAlgs[cn].ToCharArray();
                break;
            case 2:
                talg = YPerm(Constants.F2LAlgs[cn]).ToCharArray();
                break;
            case 3:
                talg = Y2Perm(Constants.F2LAlgs[cn]).ToCharArray();
                break;
            case 4:
                talg = YdPerm(Constants.F2LAlgs[cn]).ToCharArray();
                break;
            case 5:
                talg = Constants.F2LAlgs[cn].ToCharArray();
                break;
            case 6:
                talg = YdPerm(Constants.OLLAlgs[cn]).ToCharArray();
                break;
            case 7:
                talg = Constants.OLLAlgs[cn].ToCharArray();
                break;
            case 8:
                talg = YPerm(Constants.OLLAlgs[cn]).ToCharArray();
                break;
            case 9:
                talg = Y2Perm(Constants.OLLAlgs[cn]).ToCharArray();
                break;
            case 10:
                talg = "U' ".ToCharArray();
                talg = talg.Concat(Constants.PLLAlgs[cn]).ToArray();
                break;
            case 11:
                talg = Constants.PLLAlgs[cn].ToCharArray();
                break;
            case 12:
                talg = "U ".ToCharArray();
                talg = talg.Concat(Constants.PLLAlgs[cn]).ToArray();
                break;
            case 13:
                talg = "U2 ".ToCharArray();
                talg = talg.Concat(Constants.PLLAlgs[cn]).ToArray();
                break;
            case 14:
                switch(cn){
                case 1:
                    talg = "R".ToCharArray();
                    break;
                case 2:
                    talg = "R'".ToCharArray();
                    break;
                case 3:
                    talg = "R2".ToCharArray();
                    break;
                }
                break;
            case 15:
                switch(cn){
                case 1:
                    talg = "U".ToCharArray();
                    break;
                case 2:
                    talg = "U'".ToCharArray();
                    break;
                case 3:
                    talg = "U2".ToCharArray();
                    break;
                }
                break;
            case 16:
                switch(cn){
                case 1:
                    talg = "F".ToCharArray();
                    break;
                case 2:
                    talg = "F'".ToCharArray();
                    break;
                case 3:
                    talg = "F2".ToCharArray();
                    break;
                }
                break;
            case 17:
                switch(cn){
                case 1:
                    talg = "B".ToCharArray();
                    break;
                case 2:
                    talg = "B'".ToCharArray();
                    break;
                case 3:
                    talg = "B2".ToCharArray();
                    break;
                }
                break;
            case 18:
                switch(cn){
                case 1:
                    talg = "L".ToCharArray();
                    break;
                case 2:
                    talg = "L'".ToCharArray();
                    break;
                case 3:
                    talg = "L2".ToCharArray();
                    break;
                }
                break;
            case 19:
                switch(cn){
                case 1:
                    talg = "D".ToCharArray();
                    break;
                case 2:
                    talg = "D'".ToCharArray();
                    break;
                case 3:
                    talg = "D2".ToCharArray();
                    break;
                }
                break;
            }
            int i = 0;
            while(i < talg.Length){
                if(talg[i] == ' '){
                    i++;
                    continue;
                }
                if(talg[i] == 'R' || talg[i] == 'U' || talg[i] == 'F' || talg[i] == 'D' || talg[i] == 'B' || talg[i] == 'L'){
                    switch(char.ToLower(talg[i])){
                    case 'r':
                        fa = 1;
                        break;
                    case 'u':
                        fa = 2;
                        break;
                    case 'f':
                        fa = 3;
                        break;
                    case 'l':
                        fa = 4;
                        break;
                    case 'b':
                        fa = 5;
                        break;
                    case 'd':
                        fa = 6;
                        break;
                    }
                }
                int dir;
                int tim;
                try{
                    if(talg[i + 1] == '\''){
                        dir = -1;
                        tim = 1;
                        i++;
                    }
                    else if(talg[i + 1] == '2'){
                        dir = 1;
                        tim = 2;
                        i++;
                    }
                    else{
                        if(talg[i] != 'R' && talg[i] != 'U' && talg[i] != 'F' && talg[i] != 'D' && talg[i] != 'B' && talg[i] != 'L'){
                            i++;
                            continue;
                        }
                        dir = 1;
                        tim = 1;
                    }
                }
                catch(IndexOutOfRangeException){
                    dir = 1;
                    tim = 1;
                }
                switch(fa){
                default:
                    return;
                case 1:
                    switch(tim){
                    default:
                        return;
                    case 1:
                        switch(dir){
                        case 1:{
                            char a = cube[8];
                            char b = cube[5];
                            char c = cube[2];
                            cube[8] = cube[51];
                            cube[5] = cube[52];
                            cube[2] = cube[53];
                            cube[51] = cube[18];
                            cube[52] = cube[21];
                            cube[53] = cube[24];
                            cube[18] = cube[38];
                            cube[21] = cube[37];
                            cube[24] = cube[36];
                            cube[38] = a;
                            cube[37] = b;
                            cube[36] = c;
                            a = cube[9];
                            b = cube[10];
                            cube[9] = cube[15];
                            cube[10] = cube[12];
                            cube[15] = cube[17];
                            cube[12] = cube[16];
                            cube[17] = cube[11];
                            cube[16] = cube[14];
                            cube[11] = a;
                            cube[14] = b;
                            i++;
                            break;
                        }
                        case -1:{
                            char a = cube[2];
                            char b = cube[5];
                            char c = cube[8];
                            cube[2] = cube[36];
                            cube[5] = cube[37];
                            cube[8] = cube[38];
                            cube[36] = cube[24];
                            cube[37] = cube[21];
                            cube[38] = cube[18];
                            cube[24] = cube[53];
                            cube[21] = cube[52];
                            cube[18] = cube[51];
                            cube[53] = a;
                            cube[52] = b;
                            cube[51] = c;
                            b = cube[10];
                            a = cube[9];
                            cube[10] = cube[14];
                            cube[9] = cube[11];
                            cube[14] = cube[16];
                            cube[11] = cube[17];
                            cube[16] = cube[12];
                            cube[17] = cube[15];
                            cube[12] = b;
                            cube[15] = a;
                            i++;
                            break;
                        }
                        default:
                            return;
                        }
                        break;
                    case 2:{
                        char a = cube[8];
                        char b = cube[5];
                        char c = cube[2];
                        cube[8] = cube[51];
                        cube[5] = cube[52];
                        cube[2] = cube[53];
                        cube[51] = cube[18];
                        cube[52] = cube[21];
                        cube[53] = cube[24];
                        cube[18] = cube[38];
                        cube[21] = cube[37];
                        cube[24] = cube[36];
                        cube[38] = a;
                        cube[37] = b;
                        cube[36] = c;
                        a = cube[9];
                        b = cube[10];
                        cube[9] = cube[15];
                        cube[10] = cube[12];
                        cube[15] = cube[17];
                        cube[12] = cube[16];
                        cube[17] = cube[11];
                        cube[16] = cube[14];
                        cube[11] = a;
                        cube[14] = b;
                        a = cube[8];
                        b = cube[5];
                        c = cube[2];
                        cube[8] = cube[51];
                        cube[5] = cube[52];
                        cube[2] = cube[53];
                        cube[51] = cube[18];
                        cube[52] = cube[21];
                        cube[53] = cube[24];
                        cube[18] = cube[38];
                        cube[21] = cube[37];
                        cube[24] = cube[36];
                        cube[38] = a;
                        cube[37] = b;
                        cube[36] = c;
                        a = cube[9];
                        b = cube[10];
                        cube[9] = cube[15];
                        cube[10] = cube[12];
                        cube[15] = cube[17];
                        cube[12] = cube[16];
                        cube[17] = cube[11];
                        cube[16] = cube[14];
                        cube[11] = a;
                        cube[14] = b;
                        i++;
                        break;
                    }
                    }
                    break;
                case 2:
                    switch(tim){
                    default:
                        return;
                    case 1:
                        switch(dir){
                        case 1:{
                            char a = cube[2];
                            char b = cube[1];
                            char c = cube[0];
                            cube[2] = cube[11];
                            cube[1] = cube[10];
                            cube[0] = cube[9];
                            cube[11] = cube[20];
                            cube[10] = cube[19];
                            cube[9] = cube[18];
                            cube[20] = cube[29];
                            cube[19] = cube[28];
                            cube[18] = cube[27];
                            cube[29] = a;
                            cube[28] = b;
                            cube[27] = c;
                            a = cube[42];
                            b = cube[39];
                            cube[42] = cube[44];
                            cube[39] = cube[43];
                            cube[44] = cube[38];
                            cube[43] = cube[41];
                            cube[38] = cube[36];
                            cube[41] = cube[37];
                            cube[36] = a;
                            cube[37] = b;
                            i++;
                            break;
                        }
                        case -1:{
                            char a = cube[0];
                            char b = cube[1];
                            char c = cube[2];
                            cube[0] = cube[27];
                            cube[1] = cube[28];
                            cube[2] = cube[29];
                            cube[27] = cube[18];
                            cube[28] = cube[19];
                            cube[29] = cube[20];
                            cube[18] = cube[9];
                            cube[19] = cube[10];
                            cube[20] = cube[11];
                            cube[9] = a;
                            cube[10] = b;
                            cube[11] = c;
                            a = cube[42];
                            b = cube[39];
                            cube[42] = cube[36];
                            cube[39] = cube[37];
                            cube[36] = cube[38];
                            cube[37] = cube[41];
                            cube[38] = cube[44];
                            cube[41] = cube[43];
                            cube[44] = a;
                            cube[43] = b;
                            i++;
                            break;
                        }
                        default:
                            return;
                        }
                        break;
                    case 2:{
                        char a = cube[2];
                        char b = cube[1];
                        char c = cube[0];
                        cube[2] = cube[11];
                        cube[1] = cube[10];
                        cube[0] = cube[9];
                        cube[11] = cube[20];
                        cube[10] = cube[19];
                        cube[9] = cube[18];
                        cube[20] = cube[29];
                        cube[19] = cube[28];
                        cube[18] = cube[27];
                        cube[29] = a;
                        cube[28] = b;
                        cube[27] = c;
                        a = cube[42];
                        b = cube[39];
                        cube[42] = cube[44];
                        cube[39] = cube[43];
                        cube[44] = cube[38];
                        cube[43] = cube[41];
                        cube[38] = cube[36];
                        cube[41] = cube[37];
                        cube[36] = a;
                        cube[37] = b;
                        a = cube[2];
                        b = cube[1];
                        c = cube[0];
                        cube[2] = cube[11];
                        cube[1] = cube[10];
                        cube[0] = cube[9];
                        cube[11] = cube[20];
                        cube[10] = cube[19];
                        cube[9] = cube[18];
                        cube[20] = cube[29];
                        cube[19] = cube[28];
                        cube[18] = cube[27];
                        cube[29] = a;
                        cube[28] = b;
                        cube[27] = c;
                        a = cube[42];
                        b = cube[39];
                        cube[42] = cube[44];
                        cube[39] = cube[43];
                        cube[44] = cube[38];
                        cube[43] = cube[41];
                        cube[38] = cube[36];
                        cube[41] = cube[37];
                        cube[36] = a;
                        cube[37] = b;
                        i++;
                        break;
                    }
                    }
                    break;
                case 3:
                    switch(tim){
                    default:
                        return;
                    case 1:
                        switch(dir){
                        case 1:{
                            char a = cube[38];
                            char b = cube[41];
                            char c = cube[44];
                            cube[38] = cube[29];
                            cube[41] = cube[32];
                            cube[44] = cube[35];
                            cube[29] = cube[47];
                            cube[32] = cube[50];
                            cube[35] = cube[53];
                            cube[47] = cube[15];
                            cube[50] = cube[12];
                            cube[53] = cube[9];
                            cube[15] = a;
                            cube[12] = b;
                            cube[9] = c;
                            a = cube[0];
                            b = cube[1];
                            cube[0] = cube[6];
                            cube[1] = cube[3];
                            cube[6] = cube[8];
                            cube[3] = cube[7];
                            cube[8] = cube[2];
                            cube[7] = cube[5];
                            cube[2] = a;
                            cube[5] = b;
                            i++;
                            break;
                        }
                        case -1:{
                            char a = cube[38];
                            char b = cube[41];
                            char c = cube[44];
                            cube[38] = cube[15];
                            cube[41] = cube[12];
                            cube[44] = cube[9];
                            cube[15] = cube[47];
                            cube[12] = cube[50];
                            cube[9] = cube[53];
                            cube[47] = cube[29];
                            cube[50] = cube[32];
                            cube[53] = cube[35];
                            cube[29] = a;
                            cube[32] = b;
                            cube[35] = c;
                            a = cube[0];
                            b = cube[1];
                            cube[0] = cube[2];
                            cube[1] = cube[5];
                            cube[2] = cube[8];
                            cube[5] = cube[7];
                            cube[8] = cube[6];
                            cube[7] = cube[3];
                            cube[6] = a;
                            cube[3] = b;
                            i++;
                            break;
                        }
                        default:
                            return;
                        }
                        break;
                    case 2:{
                        char a = cube[38];
                        char b = cube[41];
                        char c = cube[44];
                        cube[38] = cube[29];
                        cube[41] = cube[32];
                        cube[44] = cube[35];
                        cube[29] = cube[47];
                        cube[32] = cube[50];
                        cube[35] = cube[53];
                        cube[47] = cube[15];
                        cube[50] = cube[12];
                        cube[53] = cube[9];
                        cube[15] = a;
                        cube[12] = b;
                        cube[9] = c;
                        a = cube[0];
                        b = cube[1];
                        cube[0] = cube[6];
                        cube[1] = cube[3];
                        cube[6] = cube[8];
                        cube[3] = cube[7];
                        cube[8] = cube[2];
                        cube[7] = cube[5];
                        cube[2] = a;
                        cube[5] = b;
                        a = cube[38];
                        b = cube[41];
                        c = cube[44];
                        cube[38] = cube[29];
                        cube[41] = cube[32];
                        cube[44] = cube[35];
                        cube[29] = cube[47];
                        cube[32] = cube[50];
                        cube[35] = cube[53];
                        cube[47] = cube[15];
                        cube[50] = cube[12];
                        cube[53] = cube[9];
                        cube[15] = a;
                        cube[12] = b;
                        cube[9] = c;
                        a = cube[0];
                        b = cube[1];
                        cube[0] = cube[6];
                        cube[1] = cube[3];
                        cube[6] = cube[8];
                        cube[3] = cube[7];
                        cube[8] = cube[2];
                        cube[7] = cube[5];
                        cube[2] = a;
                        cube[5] = b;
                        i++;
                        break;
                    }
                    }
                    break;
                case 4:
                    switch(tim){
                    default:
                        return;
                    case 1:
                        switch(dir){
                        case 1:{
                            char a = cube[0];
                            char b = cube[3];
                            char c = cube[6];
                            cube[0] = cube[42];
                            cube[3] = cube[43];
                            cube[6] = cube[44];
                            cube[42] = cube[26];
                            cube[43] = cube[23];
                            cube[44] = cube[20];
                            cube[26] = cube[47];
                            cube[23] = cube[46];
                            cube[20] = cube[45];
                            cube[47] = a;
                            cube[46] = b;
                            cube[45] = c;
                            a = cube[27];
                            b = cube[28];
                            cube[27] = cube[33];
                            cube[28] = cube[30];
                            cube[33] = cube[35];
                            cube[30] = cube[34];
                            cube[35] = cube[29];
                            cube[34] = cube[32];
                            cube[29] = a;
                            cube[32] = b;
                            i++;
                            break;
                        }
                        case -1:{
                            char a = cube[6];
                            char b = cube[3];
                            char c = cube[0];
                            cube[6] = cube[45];
                            cube[3] = cube[46];
                            cube[0] = cube[47];
                            cube[45] = cube[20];
                            cube[46] = cube[23];
                            cube[47] = cube[26];
                            cube[20] = cube[44];
                            cube[23] = cube[43];
                            cube[26] = cube[42];
                            cube[44] = a;
                            cube[43] = b;
                            cube[42] = c;
                            a = cube[27];
                            b = cube[28];
                            cube[27] = cube[29];
                            cube[28] = cube[32];
                            cube[29] = cube[35];
                            cube[32] = cube[34];
                            cube[35] = cube[33];
                            cube[34] = cube[30];
                            cube[33] = a;
                            cube[30] = b;
                            i++;
                            break;
                        }
                        default:
                            return;
                        }
                        break;
                    case 2:{
                        char a = cube[0];
                        char b = cube[3];
                        char c = cube[6];
                        cube[0] = cube[42];
                        cube[3] = cube[43];
                        cube[6] = cube[44];
                        cube[42] = cube[26];
                        cube[43] = cube[23];
                        cube[44] = cube[20];
                        cube[26] = cube[47];
                        cube[23] = cube[46];
                        cube[20] = cube[45];
                        cube[47] = a;
                        cube[46] = b;
                        cube[45] = c;
                        a = cube[27];
                        b = cube[28];
                        cube[27] = cube[33];
                        cube[28] = cube[30];
                        cube[33] = cube[35];
                        cube[30] = cube[34];
                        cube[35] = cube[29];
                        cube[34] = cube[32];
                        cube[29] = a;
                        cube[32] = b;
                        a = cube[0];
                        b = cube[3];
                        c = cube[6];
                        cube[0] = cube[42];
                        cube[3] = cube[43];
                        cube[6] = cube[44];
                        cube[42] = cube[26];
                        cube[43] = cube[23];
                        cube[44] = cube[20];
                        cube[26] = cube[47];
                        cube[23] = cube[46];
                        cube[20] = cube[45];
                        cube[47] = a;
                        cube[46] = b;
                        cube[45] = c;
                        a = cube[27];
                        b = cube[28];
                        cube[27] = cube[33];
                        cube[28] = cube[30];
                        cube[33] = cube[35];
                        cube[30] = cube[34];
                        cube[35] = cube[29];
                        cube[34] = cube[32];
                        cube[29] = a;
                        cube[32] = b;
                        i++;
                        break;
                    }
                    }
                    break;
                case 5:
                    switch(tim){
                    default:
                        return;
                    case 1:
                        switch(dir){
                        case 1:{
                            char a = cube[36];
                            char b = cube[39];
                            char c = cube[42];
                            cube[36] = cube[17];
                            cube[39] = cube[14];
                            cube[42] = cube[11];
                            cube[17] = cube[45];
                            cube[14] = cube[48];
                            cube[11] = cube[51];
                            cube[45] = cube[27];
                            cube[48] = cube[30];
                            cube[51] = cube[33];
                            cube[27] = a;
                            cube[30] = b;
                            cube[33] = c;
                            a = cube[18];
                            b = cube[19];
                            cube[18] = cube[24];
                            cube[19] = cube[21];
                            cube[24] = cube[26];
                            cube[21] = cube[25];
                            cube[26] = cube[20];
                            cube[25] = cube[23];
                            cube[20] = a;
                            cube[23] = b;
                            i++;
                            break;
                        }
                        case -1:{
                            char a = cube[42];
                            char b = cube[39];
                            char c = cube[36];
                            cube[42] = cube[33];
                            cube[39] = cube[30];
                            cube[36] = cube[27];
                            cube[33] = cube[51];
                            cube[30] = cube[48];
                            cube[27] = cube[45];
                            cube[51] = cube[11];
                            cube[48] = cube[14];
                            cube[45] = cube[17];
                            cube[11] = a;
                            cube[14] = b;
                            cube[17] = c;
                            b = cube[19];
                            a = cube[18];
                            cube[19] = cube[23];
                            cube[18] = cube[20];
                            cube[23] = cube[25];
                            cube[20] = cube[26];
                            cube[25] = cube[21];
                            cube[26] = cube[24];
                            cube[21] = b;
                            cube[24] = a;
                            i++;
                            break;
                        }
                        default:
                            return;
                        }
                        break;
                    case 2:{
                        char a = cube[36];
                        char b = cube[39];
                        char c = cube[42];
                        cube[36] = cube[17];
                        cube[39] = cube[14];
                        cube[42] = cube[11];
                        cube[17] = cube[45];
                        cube[14] = cube[48];
                        cube[11] = cube[51];
                        cube[45] = cube[27];
                        cube[48] = cube[30];
                        cube[51] = cube[33];
                        cube[27] = a;
                        cube[30] = b;
                        cube[33] = c;
                        a = cube[18];
                        b = cube[19];
                        cube[18] = cube[24];
                        cube[19] = cube[21];
                        cube[24] = cube[26];
                        cube[21] = cube[25];
                        cube[26] = cube[20];
                        cube[25] = cube[23];
                        cube[20] = a;
                        cube[23] = b;
                        a = cube[36];
                        b = cube[39];
                        c = cube[42];
                        cube[36] = cube[17];
                        cube[39] = cube[14];
                        cube[42] = cube[11];
                        cube[17] = cube[45];
                        cube[14] = cube[48];
                        cube[11] = cube[51];
                        cube[45] = cube[27];
                        cube[48] = cube[30];
                        cube[51] = cube[33];
                        cube[27] = a;
                        cube[30] = b;
                        cube[33] = c;
                        a = cube[18];
                        b = cube[19];
                        cube[18] = cube[24];
                        cube[19] = cube[21];
                        cube[24] = cube[26];
                        cube[21] = cube[25];
                        cube[26] = cube[20];
                        cube[25] = cube[23];
                        cube[20] = a;
                        cube[23] = b;
                        i++;
                        break;
                    }
                    }
                    break;
                case 6:
                    switch(tim){
                    default:
                        return;
                    case 1:
                        switch(dir){
                        case 1:{
                            char a = cube[6];
                            char b = cube[7];
                            char c = cube[8];
                            cube[6] = cube[33];
                            cube[7] = cube[34];
                            cube[8] = cube[35];
                            cube[33] = cube[24];
                            cube[34] = cube[25];
                            cube[35] = cube[26];
                            cube[24] = cube[15];
                            cube[25] = cube[16];
                            cube[26] = cube[17];
                            cube[15] = a;
                            cube[16] = b;
                            cube[17] = c;
                            a = cube[47];
                            b = cube[50];
                            cube[47] = cube[45];
                            cube[50] = cube[46];
                            cube[45] = cube[51];
                            cube[46] = cube[48];
                            cube[51] = cube[53];
                            cube[48] = cube[52];
                            cube[53] = a;
                            cube[52] = b;
                            i++;
                            break;
                        }
                        case -1:{
                            char a = cube[8];
                            char b = cube[7];
                            char c = cube[6];
                            cube[8] = cube[17];
                            cube[7] = cube[16];
                            cube[6] = cube[15];
                            cube[17] = cube[26];
                            cube[16] = cube[25];
                            cube[15] = cube[24];
                            cube[26] = cube[35];
                            cube[25] = cube[34];
                            cube[24] = cube[33];
                            cube[35] = a;
                            cube[34] = b;
                            cube[33] = c;
                            b = cube[50];
                            a = cube[47];
                            cube[50] = cube[52];
                            cube[47] = cube[53];
                            cube[52] = cube[48];
                            cube[53] = cube[51];
                            cube[48] = cube[46];
                            cube[51] = cube[45];
                            cube[46] = b;
                            cube[45] = a;
                            i++;
                            break;
                        }
                        default:
                            return;
                        }
                        break;
                    case 2:{
                        char a = cube[6];
                        char b = cube[7];
                        char c = cube[8];
                        cube[6] = cube[33];
                        cube[7] = cube[34];
                        cube[8] = cube[35];
                        cube[33] = cube[24];
                        cube[34] = cube[25];
                        cube[35] = cube[26];
                        cube[24] = cube[15];
                        cube[25] = cube[16];
                        cube[26] = cube[17];
                        cube[15] = a;
                        cube[16] = b;
                        cube[17] = c;
                        a = cube[47];
                        b = cube[50];
                        cube[47] = cube[45];
                        cube[50] = cube[46];
                        cube[45] = cube[51];
                        cube[46] = cube[48];
                        cube[51] = cube[53];
                        cube[48] = cube[52];
                        cube[53] = a;
                        cube[52] = b;
                        a = cube[6];
                        b = cube[7];
                        c = cube[8];
                        cube[6] = cube[33];
                        cube[7] = cube[34];
                        cube[8] = cube[35];
                        cube[33] = cube[24];
                        cube[34] = cube[25];
                        cube[35] = cube[26];
                        cube[24] = cube[15];
                        cube[25] = cube[16];
                        cube[26] = cube[17];
                        cube[15] = a;
                        cube[16] = b;
                        cube[17] = c;
                        a = cube[47];
                        b = cube[50];
                        cube[47] = cube[45];
                        cube[50] = cube[46];
                        cube[45] = cube[51];
                        cube[46] = cube[48];
                        cube[51] = cube[53];
                        cube[48] = cube[52];
                        cube[53] = a;
                        cube[52] = b;
                        i++;
                        break;
                    }
                    }
                    break;
                }
            }
        }
    }
}
