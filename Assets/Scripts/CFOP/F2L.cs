using System;

namespace CFOPSolver{

    internal static class F2L{
        private static int cc1;

        private static int cc2;

        private static int ecc1;

        private static int ecc2;

        public static string Solve(char[] cube){

            string solution = string.Empty;
            bool flag = false;
            for(int i = 0; i < 24; i++){
                if(cube[Constants.CornerPositions[i]] == 'D'){
                    AssignCorner(Constants.CornerPositions[i]);
                    if(cube[cc1] == 'R' && cube[cc2] == 'B'){
                        break;
                    }
                    if(cube[cc1] == 'B' && cube[cc2] == 'R'){
                        (cc1, cc2) = (cc2, cc1);
                        break;
                    }
                }
            }

            for(int i = 0; i < 16; i++){
                if(cube[Constants.WhiteLessEdges[i]] == cube[cc1] && cube[Tools.ConjugateEdge(Constants.WhiteLessEdges[i])] == cube[cc2]){
                    flag = true;
                    ecc1 = Constants.WhiteLessEdges[i];
                    ecc2 = Tools.ConjugateEdge(Constants.WhiteLessEdges[i]);
                    break;
                }
                if(cube[Constants.WhiteLessEdges[i]] == cube[cc2] && cube[Tools.ConjugateEdge(Constants.WhiteLessEdges[i])] == cube[cc1]){
                    flag = true;
                    ecc1 = Tools.ConjugateEdge(Constants.WhiteLessEdges[i]);
                    ecc2 = Constants.WhiteLessEdges[i];
                    break;
                }
            }
            if(!flag){
                throw new ArgumentException("F2L: Coundn't find edge piece pair for corner BR");
            }
            if(ecc1 != 14 || cc1 != 17){
                solution += F2L_OB(cube);
            }
            for(int i = 0; i < 24; i++){
                if(cube[Constants.CornerPositions[i]] == 'D'){
                    AssignCorner(Constants.CornerPositions[i]);
                    if(cube[cc1] == 'B' && cube[cc2] == 'L'){
                        break;
                    }
                    if(cube[cc1] == 'L' && cube[cc2] == 'B'){
                        (cc1, cc2) = (cc2, cc1);
                        break;
                    }
                }
            }
            flag = false;
            for(int i = 0; i < 16; i++){
                if(cube[Constants.WhiteLessEdges[i]] == cube[cc1] && cube[Tools.ConjugateEdge(Constants.WhiteLessEdges[i])] == cube[cc2]){
                    flag = true;
                    ecc1 = Constants.WhiteLessEdges[i];
                    ecc2 = Tools.ConjugateEdge(Constants.WhiteLessEdges[i]);
                    break;
                }
                if(cube[Constants.WhiteLessEdges[i]] == cube[cc2] && cube[Tools.ConjugateEdge(Constants.WhiteLessEdges[i])] == cube[cc1]){
                    flag = true;
                    ecc1 = Tools.ConjugateEdge(Constants.WhiteLessEdges[i]);
                    ecc2 = Constants.WhiteLessEdges[i];
                    break;
                }
            }
            if(!flag){
                throw new ArgumentException("F2L: Coundn't find edge piece pair for corner LB");
            }
            if(ecc1 != 23 || cc1 != 26){
                solution += F2L_BR(cube);
            }
            for(int i = 0; i < 24; i++){
                if(cube[Constants.CornerPositions[i]] == 'D'){
                    AssignCorner(Constants.CornerPositions[i]);
                    if(cube[cc1] == 'L' && cube[cc2] == 'F'){
                        break;
                    }
                    if(cube[cc1] == 'F' && cube[cc2] == 'L'){
                        (cc1, cc2) = (cc2, cc1);
                        break;
                    }
                }
            }
            flag = false;
            for(int i = 0; i < 16; i++){
                if(cube[Constants.WhiteLessEdges[i]] == cube[cc1] && cube[Tools.ConjugateEdge(Constants.WhiteLessEdges[i])] == cube[cc2]){
                    flag = true;
                    ecc1 = Constants.WhiteLessEdges[i];
                    ecc2 = Tools.ConjugateEdge(Constants.WhiteLessEdges[i]);
                    break;
                }
                if(cube[Constants.WhiteLessEdges[i]] == cube[cc2] && cube[Tools.ConjugateEdge(Constants.WhiteLessEdges[i])] == cube[cc1]){
                    flag = true;
                    ecc1 = Tools.ConjugateEdge(Constants.WhiteLessEdges[i]);
                    ecc2 = Constants.WhiteLessEdges[i];
                    break;
                }
            }
            if(!flag){
                throw new ArgumentException("F2L: Coundn't find edge piece pair for corner FL");
            }
            if(ecc1 != 32 || cc1 != 35){
                solution += F2L_RG(cube);
            }
            for(int i = 0; i < 24; i++){
                if(cube[Constants.CornerPositions[i]] == 'D'){
                    AssignCorner(Constants.CornerPositions[i]);
                    if(cube[cc1] == 'F' && cube[cc2] == 'R'){
                        break;
                    }
                    if(cube[cc1] == 'R' && cube[cc2] == 'F'){
                        (cc1, cc2) = (cc2, cc1);
                        break;
                    }
                }
            }
            flag = false;
            for(int i = 0; i < 16; i++){
                if(cube[Constants.WhiteLessEdges[i]] == cube[cc1] && cube[Tools.ConjugateEdge(Constants.WhiteLessEdges[i])] == cube[cc2]){
                    flag = true;
                    ecc1 = Constants.WhiteLessEdges[i];
                    ecc2 = Tools.ConjugateEdge(Constants.WhiteLessEdges[i]);
                    break;
                }
                if(cube[Constants.WhiteLessEdges[i]] == cube[cc2] && cube[Tools.ConjugateEdge(Constants.WhiteLessEdges[i])] == cube[cc1]){
                    flag = true;
                    ecc1 = Tools.ConjugateEdge(Constants.WhiteLessEdges[i]);
                    ecc2 = Constants.WhiteLessEdges[i];
                    break;
                }
            }
            if(!flag){
                throw new ArgumentException("F2L: Coundn't find edge piece pair for corner FR");
            }
            if(ecc1 != 5 || cc1 != 8){
                solution += F2L_GO(cube);
            }

            return solution;
        }

        private static string F2L_GO(char[] cube){
            switch(ecc1){
            case 5:
                switch(cc1){
                case 15:
                    Tools.RotateCube(cube, 5, 0);
                    return Constants.F2LAlgs[0];
                case 53:
                    Tools.RotateCube(cube, 5, 1);
                    return Constants.F2LAlgs[1];
                case 17:
                    Tools.RotateCube(cube, 5, 2);
                    return Constants.F2LAlgs[2];
                case 24:
                    Tools.RotateCube(cube, 5, 3);
                    return Constants.F2LAlgs[3];
                case 51:
                    Tools.RotateCube(cube, 5, 4);
                    return Constants.F2LAlgs[4];
                case 26:
                    Tools.RotateCube(cube, 5, 5);
                    return Constants.F2LAlgs[5];
                case 33:
                    Tools.RotateCube(cube, 5, 6);
                    return Constants.F2LAlgs[6];
                case 45:
                    Tools.RotateCube(cube, 5, 7);
                    return Constants.F2LAlgs[7];
                case 35:
                    Tools.RotateCube(cube, 5, 8);
                    return Constants.F2LAlgs[8];
                case 6:
                    Tools.RotateCube(cube, 5, 9);
                    return Constants.F2LAlgs[9];
                case 47:
                    Tools.RotateCube(cube, 5, 10);
                    return Constants.F2LAlgs[10];
                case 2:
                    Tools.RotateCube(cube, 5, 11);
                    return Constants.F2LAlgs[11];
                case 38:
                    Tools.RotateCube(cube, 5, 12);
                    return Constants.F2LAlgs[12];
                case 9:
                    Tools.RotateCube(cube, 5, 13);
                    return Constants.F2LAlgs[13];
                case 11:
                    Tools.RotateCube(cube, 5, 14);
                    return Constants.F2LAlgs[14];
                case 36:
                    Tools.RotateCube(cube, 5, 15);
                    return Constants.F2LAlgs[15];
                case 18:
                    Tools.RotateCube(cube, 5, 16);
                    return Constants.F2LAlgs[16];
                case 20:
                    Tools.RotateCube(cube, 5, 17);
                    return Constants.F2LAlgs[17];
                case 42:
                    Tools.RotateCube(cube, 5, 18);
                    return Constants.F2LAlgs[18];
                case 27:
                    Tools.RotateCube(cube, 5, 19);
                    return Constants.F2LAlgs[19];
                case 29:
                    Tools.RotateCube(cube, 5, 20);
                    return Constants.F2LAlgs[20];
                case 44:
                    Tools.RotateCube(cube, 5, 21);
                    return Constants.F2LAlgs[21];
                case 0:
                    Tools.RotateCube(cube, 5, 22);
                    return Constants.F2LAlgs[22];
                }
                break;
            case 12:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 5, 23);
                    return Constants.F2LAlgs[23];
                case 15:
                    Tools.RotateCube(cube, 5, 24);
                    return Constants.F2LAlgs[24];
                case 53:
                    Tools.RotateCube(cube, 5, 25);
                    return Constants.F2LAlgs[25];
                case 17:
                    Tools.RotateCube(cube, 5, 26);
                    return Constants.F2LAlgs[26];
                case 24:
                    Tools.RotateCube(cube, 5, 27);
                    return Constants.F2LAlgs[27];
                case 51:
                    Tools.RotateCube(cube, 5, 28);
                    return Constants.F2LAlgs[28];
                case 26:
                    Tools.RotateCube(cube, 5, 29);
                    return Constants.F2LAlgs[29];
                case 33:
                    Tools.RotateCube(cube, 5, 30);
                    return Constants.F2LAlgs[30];
                case 45:
                    Tools.RotateCube(cube, 5, 31);
                    return Constants.F2LAlgs[31];
                case 35:
                    Tools.RotateCube(cube, 5, 32);
                    return Constants.F2LAlgs[32];
                case 6:
                    Tools.RotateCube(cube, 5, 33);
                    return Constants.F2LAlgs[33];
                case 47:
                    Tools.RotateCube(cube, 5, 34);
                    return Constants.F2LAlgs[34];
                case 2:
                    Tools.RotateCube(cube, 5, 35);
                    return Constants.F2LAlgs[35];
                case 38:
                    Tools.RotateCube(cube, 5, 36);
                    return Constants.F2LAlgs[36];
                case 9:
                    Tools.RotateCube(cube, 5, 37);
                    return Constants.F2LAlgs[37];
                case 11:
                    Tools.RotateCube(cube, 5, 38);
                    return Constants.F2LAlgs[38];
                case 36:
                    Tools.RotateCube(cube, 5, 39);
                    return Constants.F2LAlgs[39];
                case 18:
                    Tools.RotateCube(cube, 5, 40);
                    return Constants.F2LAlgs[40];
                case 20:
                    Tools.RotateCube(cube, 5, 41);
                    return Constants.F2LAlgs[41];
                case 42:
                    Tools.RotateCube(cube, 5, 42);
                    return Constants.F2LAlgs[42];
                case 27:
                    Tools.RotateCube(cube, 5, 43);
                    return Constants.F2LAlgs[43];
                case 29:
                    Tools.RotateCube(cube, 5, 44);
                    return Constants.F2LAlgs[44];
                case 44:
                    Tools.RotateCube(cube, 5, 45);
                    return Constants.F2LAlgs[45];
                case 0:
                    Tools.RotateCube(cube, 5, 46);
                    return Constants.F2LAlgs[46];
                }
                break;
            case 14:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 5, 47);
                    return Constants.F2LAlgs[47];
                case 15:
                    Tools.RotateCube(cube, 5, 48);
                    return Constants.F2LAlgs[48];
                case 53:
                    Tools.RotateCube(cube, 5, 49);
                    return Constants.F2LAlgs[49];
                case 24:
                    Tools.RotateCube(cube, 5, 51);
                    return Constants.F2LAlgs[51];
                case 51:
                    Tools.RotateCube(cube, 5, 52);
                    return Constants.F2LAlgs[52];
                case 26:
                    Tools.RotateCube(cube, 5, 53);
                    return Constants.F2LAlgs[53];
                case 33:
                    Tools.RotateCube(cube, 5, 54);
                    return Constants.F2LAlgs[54];
                case 45:
                    Tools.RotateCube(cube, 5, 55);
                    return Constants.F2LAlgs[55];
                case 35:
                    Tools.RotateCube(cube, 5, 56);
                    return Constants.F2LAlgs[56];
                case 6:
                    Tools.RotateCube(cube, 5, 57);
                    return Constants.F2LAlgs[57];
                case 47:
                    Tools.RotateCube(cube, 5, 58);
                    return Constants.F2LAlgs[58];
                case 2:
                    Tools.RotateCube(cube, 5, 59);
                    return Constants.F2LAlgs[59];
                case 38:
                    Tools.RotateCube(cube, 5, 60);
                    return Constants.F2LAlgs[60];
                case 9:
                    Tools.RotateCube(cube, 5, 61);
                    return Constants.F2LAlgs[61];
                case 11:
                    Tools.RotateCube(cube, 5, 62);
                    return Constants.F2LAlgs[62];
                case 36:
                    Tools.RotateCube(cube, 5, 63);
                    return Constants.F2LAlgs[63];
                case 18:
                    Tools.RotateCube(cube, 5, 64);
                    return Constants.F2LAlgs[64];
                case 20:
                    Tools.RotateCube(cube, 5, 65);
                    return Constants.F2LAlgs[65];
                case 42:
                    Tools.RotateCube(cube, 5, 66);
                    return Constants.F2LAlgs[66];
                case 27:
                    Tools.RotateCube(cube, 5, 67);
                    return Constants.F2LAlgs[67];
                case 29:
                    Tools.RotateCube(cube, 5, 68);
                    return Constants.F2LAlgs[68];
                case 44:
                    Tools.RotateCube(cube, 5, 69);
                    return Constants.F2LAlgs[69];
                case 0:
                    Tools.RotateCube(cube, 5, 70);
                    return Constants.F2LAlgs[70];
                }
                break;
            case 21:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 5, 71);
                    return Constants.F2LAlgs[71];
                case 15:
                    Tools.RotateCube(cube, 5, 72);
                    return Constants.F2LAlgs[72];
                case 53:
                    Tools.RotateCube(cube, 5, 73);
                    return Constants.F2LAlgs[73];
                case 17:
                    Tools.RotateCube(cube, 5, 74);
                    return Constants.F2LAlgs[74];
                case 24:
                    Tools.RotateCube(cube, 5, 75);
                    return Constants.F2LAlgs[75];
                case 51:
                    Tools.RotateCube(cube, 5, 76);
                    return Constants.F2LAlgs[76];
                case 26:
                    Tools.RotateCube(cube, 5, 77);
                    return Constants.F2LAlgs[77];
                case 33:
                    Tools.RotateCube(cube, 5, 78);
                    return Constants.F2LAlgs[78];
                case 45:
                    Tools.RotateCube(cube, 5, 79);
                    return Constants.F2LAlgs[79];
                case 35:
                    Tools.RotateCube(cube, 5, 80);
                    return Constants.F2LAlgs[80];
                case 6:
                    Tools.RotateCube(cube, 5, 81);
                    return Constants.F2LAlgs[81];
                case 47:
                    Tools.RotateCube(cube, 5, 82);
                    return Constants.F2LAlgs[82];
                case 2:
                    Tools.RotateCube(cube, 5, 83);
                    return Constants.F2LAlgs[83];
                case 38:
                    Tools.RotateCube(cube, 5, 84);
                    return Constants.F2LAlgs[84];
                case 9:
                    Tools.RotateCube(cube, 5, 85);
                    return Constants.F2LAlgs[85];
                case 11:
                    Tools.RotateCube(cube, 5, 86);
                    return Constants.F2LAlgs[86];
                case 36:
                    Tools.RotateCube(cube, 5, 87);
                    return Constants.F2LAlgs[87];
                case 18:
                    Tools.RotateCube(cube, 5, 88);
                    return Constants.F2LAlgs[88];
                case 20:
                    Tools.RotateCube(cube, 5, 89);
                    return Constants.F2LAlgs[89];
                case 42:
                    Tools.RotateCube(cube, 5, 90);
                    return Constants.F2LAlgs[90];
                case 27:
                    Tools.RotateCube(cube, 5, 91);
                    return Constants.F2LAlgs[91];
                case 29:
                    Tools.RotateCube(cube, 5, 92);
                    return Constants.F2LAlgs[92];
                case 44:
                    Tools.RotateCube(cube, 5, 93);
                    return Constants.F2LAlgs[93];
                case 0:
                    Tools.RotateCube(cube, 5, 94);
                    return Constants.F2LAlgs[94];
                }
                break;
            case 23:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 5, 95);
                    return Constants.F2LAlgs[95];
                case 15:
                    Tools.RotateCube(cube, 5, 96);
                    return Constants.F2LAlgs[96];
                case 53:
                    Tools.RotateCube(cube, 5, 97);
                    return Constants.F2LAlgs[97];
                case 17:
                    Tools.RotateCube(cube, 5, 98);
                    return Constants.F2LAlgs[98];
                case 24:
                    Tools.RotateCube(cube, 5, 99);
                    return Constants.F2LAlgs[99];
                case 51:
                    Tools.RotateCube(cube, 5, 100);
                    return Constants.F2LAlgs[100];
                case 26:
                    Tools.RotateCube(cube, 5, 101);
                    return Constants.F2LAlgs[101];
                case 33:
                    Tools.RotateCube(cube, 5, 102);
                    return Constants.F2LAlgs[102];
                case 45:
                    Tools.RotateCube(cube, 5, 103);
                    return Constants.F2LAlgs[103];
                case 35:
                    Tools.RotateCube(cube, 5, 104);
                    return Constants.F2LAlgs[104];
                case 6:
                    Tools.RotateCube(cube, 5, 105);
                    return Constants.F2LAlgs[105];
                case 47:
                    Tools.RotateCube(cube, 5, 106);
                    return Constants.F2LAlgs[106];
                case 2:
                    Tools.RotateCube(cube, 5, 107);
                    return Constants.F2LAlgs[107];
                case 38:
                    Tools.RotateCube(cube, 5, 108);
                    return Constants.F2LAlgs[108];
                case 9:
                    Tools.RotateCube(cube, 5, 109);
                    return Constants.F2LAlgs[109];
                case 11:
                    Tools.RotateCube(cube, 5, 110);
                    return Constants.F2LAlgs[110];
                case 36:
                    Tools.RotateCube(cube, 5, 111);
                    return Constants.F2LAlgs[111];
                case 18:
                    Tools.RotateCube(cube, 5, 112);
                    return Constants.F2LAlgs[112];
                case 20:
                    Tools.RotateCube(cube, 5, 113);
                    return Constants.F2LAlgs[113];
                case 42:
                    Tools.RotateCube(cube, 5, 114);
                    return Constants.F2LAlgs[114];
                case 27:
                    Tools.RotateCube(cube, 5, 115);
                    return Constants.F2LAlgs[115];
                case 29:
                    Tools.RotateCube(cube, 5, 116);
                    return Constants.F2LAlgs[116];
                case 44:
                    Tools.RotateCube(cube, 5, 117);
                    return Constants.F2LAlgs[117];
                case 0:
                    Tools.RotateCube(cube, 5, 118);
                    return Constants.F2LAlgs[118];
                }
                break;
            case 30:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 5, 119);
                    return Constants.F2LAlgs[119];
                case 15:
                    Tools.RotateCube(cube, 5, 120);
                    return Constants.F2LAlgs[120];
                case 53:
                    Tools.RotateCube(cube, 5, 121);
                    return Constants.F2LAlgs[121];
                case 17:
                    Tools.RotateCube(cube, 5, 122);
                    return Constants.F2LAlgs[122];
                case 24:
                    Tools.RotateCube(cube, 5, 123);
                    return Constants.F2LAlgs[123];
                case 51:
                    Tools.RotateCube(cube, 5, 124);
                    return Constants.F2LAlgs[124];
                case 26:
                    Tools.RotateCube(cube, 5, 125);
                    return Constants.F2LAlgs[125];
                case 33:
                    Tools.RotateCube(cube, 5, 126);
                    return Constants.F2LAlgs[126];
                case 45:
                    Tools.RotateCube(cube, 5, 127);
                    return Constants.F2LAlgs[127];
                case 35:
                    Tools.RotateCube(cube, 5, 128);
                    return Constants.F2LAlgs[128];
                case 6:
                    Tools.RotateCube(cube, 5, 129);
                    return Constants.F2LAlgs[129];
                case 47:
                    Tools.RotateCube(cube, 5, 130);
                    return Constants.F2LAlgs[130];
                case 2:
                    Tools.RotateCube(cube, 5, 131);
                    return Constants.F2LAlgs[131];
                case 38:
                    Tools.RotateCube(cube, 5, 132);
                    return Constants.F2LAlgs[132];
                case 9:
                    Tools.RotateCube(cube, 5, 133);
                    return Constants.F2LAlgs[133];
                case 11:
                    Tools.RotateCube(cube, 5, 134);
                    return Constants.F2LAlgs[134];
                case 36:
                    Tools.RotateCube(cube, 5, 135);
                    return Constants.F2LAlgs[135];
                case 18:
                    Tools.RotateCube(cube, 5, 136);
                    return Constants.F2LAlgs[136];
                case 20:
                    Tools.RotateCube(cube, 5, 137);
                    return Constants.F2LAlgs[137];
                case 42:
                    Tools.RotateCube(cube, 5, 138);
                    return Constants.F2LAlgs[138];
                case 27:
                    Tools.RotateCube(cube, 5, 139);
                    return Constants.F2LAlgs[139];
                case 29:
                    Tools.RotateCube(cube, 5, 140);
                    return Constants.F2LAlgs[140];
                case 44:
                    Tools.RotateCube(cube, 5, 141);
                    return Constants.F2LAlgs[141];
                case 0:
                    Tools.RotateCube(cube, 5, 142);
                    return Constants.F2LAlgs[142];
                }
                break;
            case 32:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 5, 143);
                    return Constants.F2LAlgs[143];
                case 15:
                    Tools.RotateCube(cube, 5, 144);
                    return Constants.F2LAlgs[144];
                case 53:
                    Tools.RotateCube(cube, 5, 145);
                    return Constants.F2LAlgs[145];
                case 17:
                    Tools.RotateCube(cube, 5, 146);
                    return Constants.F2LAlgs[146];
                case 24:
                    Tools.RotateCube(cube, 5, 147);
                    return Constants.F2LAlgs[147];
                case 51:
                    Tools.RotateCube(cube, 5, 148);
                    return Constants.F2LAlgs[148];
                case 26:
                    Tools.RotateCube(cube, 5, 149);
                    return Constants.F2LAlgs[149];
                case 33:
                    Tools.RotateCube(cube, 5, 150);
                    return Constants.F2LAlgs[150];
                case 45:
                    Tools.RotateCube(cube, 5, 151);
                    return Constants.F2LAlgs[151];
                case 35:
                    Tools.RotateCube(cube, 5, 152);
                    return Constants.F2LAlgs[152];
                case 6:
                    Tools.RotateCube(cube, 5, 153);
                    return Constants.F2LAlgs[153];
                case 47:
                    Tools.RotateCube(cube, 5, 154);
                    return Constants.F2LAlgs[154];
                case 2:
                    Tools.RotateCube(cube, 5, 155);
                    return Constants.F2LAlgs[155];
                case 38:
                    Tools.RotateCube(cube, 5, 156);
                    return Constants.F2LAlgs[156];
                case 9:
                    Tools.RotateCube(cube, 5, 157);
                    return Constants.F2LAlgs[157];
                case 11:
                    Tools.RotateCube(cube, 5, 158);
                    return Constants.F2LAlgs[158];
                case 36:
                    Tools.RotateCube(cube, 5, 159);
                    return Constants.F2LAlgs[159];
                case 18:
                    Tools.RotateCube(cube, 5, 160);
                    return Constants.F2LAlgs[160];
                case 20:
                    Tools.RotateCube(cube, 5, 161);
                    return Constants.F2LAlgs[161];
                case 42:
                    Tools.RotateCube(cube, 5, 162);
                    return Constants.F2LAlgs[162];
                case 27:
                    Tools.RotateCube(cube, 5, 163);
                    return Constants.F2LAlgs[163];
                case 29:
                    Tools.RotateCube(cube, 5, 164);
                    return Constants.F2LAlgs[164];
                case 44:
                    Tools.RotateCube(cube, 5, 165);
                    return Constants.F2LAlgs[165];
                case 0:
                    Tools.RotateCube(cube, 5, 166);
                    return Constants.F2LAlgs[166];
                }
                break;
            case 3:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 5, 167);
                    return Constants.F2LAlgs[167];
                case 15:
                    Tools.RotateCube(cube, 5, 168);
                    return Constants.F2LAlgs[168];
                case 53:
                    Tools.RotateCube(cube, 5, 169);
                    return Constants.F2LAlgs[169];
                case 17:
                    Tools.RotateCube(cube, 5, 170);
                    return Constants.F2LAlgs[170];
                case 24:
                    Tools.RotateCube(cube, 5, 171);
                    return Constants.F2LAlgs[171];
                case 51:
                    Tools.RotateCube(cube, 5, 172);
                    return Constants.F2LAlgs[172];
                case 26:
                    Tools.RotateCube(cube, 5, 173);
                    return Constants.F2LAlgs[173];
                case 33:
                    Tools.RotateCube(cube, 5, 174);
                    return Constants.F2LAlgs[174];
                case 45:
                    Tools.RotateCube(cube, 5, 175);
                    return Constants.F2LAlgs[175];
                case 35:
                    Tools.RotateCube(cube, 5, 176);
                    return Constants.F2LAlgs[176];
                case 6:
                    Tools.RotateCube(cube, 5, 177);
                    return Constants.F2LAlgs[177];
                case 47:
                    Tools.RotateCube(cube, 5, 178);
                    return Constants.F2LAlgs[178];
                case 2:
                    Tools.RotateCube(cube, 5, 179);
                    return Constants.F2LAlgs[179];
                case 38:
                    Tools.RotateCube(cube, 5, 180);
                    return Constants.F2LAlgs[180];
                case 9:
                    Tools.RotateCube(cube, 5, 181);
                    return Constants.F2LAlgs[181];
                case 11:
                    Tools.RotateCube(cube, 5, 182);
                    return Constants.F2LAlgs[182];
                case 36:
                    Tools.RotateCube(cube, 5, 183);
                    return Constants.F2LAlgs[183];
                case 18:
                    Tools.RotateCube(cube, 5, 184);
                    return Constants.F2LAlgs[184];
                case 20:
                    Tools.RotateCube(cube, 5, 185);
                    return Constants.F2LAlgs[185];
                case 42:
                    Tools.RotateCube(cube, 5, 186);
                    return Constants.F2LAlgs[186];
                case 27:
                    Tools.RotateCube(cube, 5, 187);
                    return Constants.F2LAlgs[187];
                case 29:
                    Tools.RotateCube(cube, 5, 188);
                    return Constants.F2LAlgs[188];
                case 44:
                    Tools.RotateCube(cube, 5, 189);
                    return Constants.F2LAlgs[189];
                case 0:
                    Tools.RotateCube(cube, 5, 190);
                    return Constants.F2LAlgs[190];
                }
                break;
            case 1:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 5, 191);
                    return Constants.F2LAlgs[191];
                case 15:
                    Tools.RotateCube(cube, 5, 192);
                    return Constants.F2LAlgs[192];
                case 53:
                    Tools.RotateCube(cube, 5, 193);
                    return Constants.F2LAlgs[193];
                case 17:
                    Tools.RotateCube(cube, 5, 194);
                    return Constants.F2LAlgs[194];
                case 24:
                    Tools.RotateCube(cube, 5, 195);
                    return Constants.F2LAlgs[195];
                case 51:
                    Tools.RotateCube(cube, 5, 196);
                    return Constants.F2LAlgs[196];
                case 26:
                    Tools.RotateCube(cube, 5, 197);
                    return Constants.F2LAlgs[197];
                case 33:
                    Tools.RotateCube(cube, 5, 198);
                    return Constants.F2LAlgs[198];
                case 45:
                    Tools.RotateCube(cube, 5, 199);
                    return Constants.F2LAlgs[199];
                case 35:
                    Tools.RotateCube(cube, 5, 200);
                    return Constants.F2LAlgs[200];
                case 6:
                    Tools.RotateCube(cube, 5, 201);
                    return Constants.F2LAlgs[201];
                case 47:
                    Tools.RotateCube(cube, 5, 202);
                    return Constants.F2LAlgs[202];
                case 2:
                    Tools.RotateCube(cube, 5, 203);
                    return Constants.F2LAlgs[203];
                case 38:
                    Tools.RotateCube(cube, 5, 204);
                    return Constants.F2LAlgs[204];
                case 9:
                    Tools.RotateCube(cube, 5, 205);
                    return Constants.F2LAlgs[205];
                case 11:
                    Tools.RotateCube(cube, 5, 206);
                    return Constants.F2LAlgs[206];
                case 36:
                    Tools.RotateCube(cube, 5, 207);
                    return Constants.F2LAlgs[207];
                case 18:
                    Tools.RotateCube(cube, 5, 208);
                    return Constants.F2LAlgs[208];
                case 20:
                    Tools.RotateCube(cube, 5, 209);
                    return Constants.F2LAlgs[209];
                case 42:
                    Tools.RotateCube(cube, 5, 210);
                    return Constants.F2LAlgs[210];
                case 27:
                    Tools.RotateCube(cube, 5, 211);
                    return Constants.F2LAlgs[211];
                case 29:
                    Tools.RotateCube(cube, 5, 212);
                    return Constants.F2LAlgs[212];
                case 44:
                    Tools.RotateCube(cube, 5, 213);
                    return Constants.F2LAlgs[213];
                case 0:
                    Tools.RotateCube(cube, 5, 214);
                    return Constants.F2LAlgs[214];
                }
                break;
            case 41:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 5, 215);
                    return Constants.F2LAlgs[215];
                case 15:
                    Tools.RotateCube(cube, 5, 216);
                    return Constants.F2LAlgs[216];
                case 53:
                    Tools.RotateCube(cube, 5, 217);
                    return Constants.F2LAlgs[217];
                case 17:
                    Tools.RotateCube(cube, 5, 218);
                    return Constants.F2LAlgs[218];
                case 24:
                    Tools.RotateCube(cube, 5, 219);
                    return Constants.F2LAlgs[219];
                case 51:
                    Tools.RotateCube(cube, 5, 220);
                    return Constants.F2LAlgs[220];
                case 26:
                    Tools.RotateCube(cube, 5, 221);
                    return Constants.F2LAlgs[221];
                case 33:
                    Tools.RotateCube(cube, 5, 222);
                    return Constants.F2LAlgs[222];
                case 45:
                    Tools.RotateCube(cube, 5, 223);
                    return Constants.F2LAlgs[223];
                case 35:
                    Tools.RotateCube(cube, 5, 224);
                    return Constants.F2LAlgs[224];
                case 6:
                    Tools.RotateCube(cube, 5, 225);
                    return Constants.F2LAlgs[225];
                case 47:
                    Tools.RotateCube(cube, 5, 226);
                    return Constants.F2LAlgs[226];
                case 2:
                    Tools.RotateCube(cube, 5, 227);
                    return Constants.F2LAlgs[227];
                case 38:
                    Tools.RotateCube(cube, 5, 228);
                    return Constants.F2LAlgs[228];
                case 9:
                    Tools.RotateCube(cube, 5, 229);
                    return Constants.F2LAlgs[229];
                case 11:
                    Tools.RotateCube(cube, 5, 230);
                    return Constants.F2LAlgs[230];
                case 36:
                    Tools.RotateCube(cube, 5, 231);
                    return Constants.F2LAlgs[231];
                case 18:
                    Tools.RotateCube(cube, 5, 232);
                    return Constants.F2LAlgs[232];
                case 20:
                    Tools.RotateCube(cube, 5, 233);
                    return Constants.F2LAlgs[233];
                case 42:
                    Tools.RotateCube(cube, 5, 234);
                    return Constants.F2LAlgs[234];
                case 27:
                    Tools.RotateCube(cube, 5, 235);
                    return Constants.F2LAlgs[235];
                case 29:
                    Tools.RotateCube(cube, 5, 236);
                    return Constants.F2LAlgs[236];
                case 44:
                    Tools.RotateCube(cube, 5, 237);
                    return Constants.F2LAlgs[237];
                case 0:
                    Tools.RotateCube(cube, 5, 238);
                    return Constants.F2LAlgs[238];
                }
                break;
            case 10:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 5, 239);
                    return Constants.F2LAlgs[239];
                case 15:
                    Tools.RotateCube(cube, 5, 240);
                    return Constants.F2LAlgs[240];
                case 53:
                    Tools.RotateCube(cube, 5, 241);
                    return Constants.F2LAlgs[241];
                case 17:
                    Tools.RotateCube(cube, 5, 242);
                    return Constants.F2LAlgs[242];
                case 24:
                    Tools.RotateCube(cube, 5, 243);
                    return Constants.F2LAlgs[243];
                case 51:
                    Tools.RotateCube(cube, 5, 244);
                    return Constants.F2LAlgs[244];
                case 26:
                    Tools.RotateCube(cube, 5, 245);
                    return Constants.F2LAlgs[245];
                case 33:
                    Tools.RotateCube(cube, 5, 246);
                    return Constants.F2LAlgs[246];
                case 45:
                    Tools.RotateCube(cube, 5, 247);
                    return Constants.F2LAlgs[247];
                case 35:
                    Tools.RotateCube(cube, 5, 248);
                    return Constants.F2LAlgs[248];
                case 6:
                    Tools.RotateCube(cube, 5, 249);
                    return Constants.F2LAlgs[249];
                case 47:
                    Tools.RotateCube(cube, 5, 250);
                    return Constants.F2LAlgs[250];
                case 2:
                    Tools.RotateCube(cube, 5, 251);
                    return Constants.F2LAlgs[251];
                case 38:
                    Tools.RotateCube(cube, 5, 252);
                    return Constants.F2LAlgs[252];
                case 9:
                    Tools.RotateCube(cube, 5, 253);
                    return Constants.F2LAlgs[253];
                case 11:
                    Tools.RotateCube(cube, 5, 254);
                    return Constants.F2LAlgs[254];
                case 36:
                    Tools.RotateCube(cube, 5, 255);
                    return Constants.F2LAlgs[255];
                case 18:
                    Tools.RotateCube(cube, 5, 256);
                    return Constants.F2LAlgs[256];
                case 20:
                    Tools.RotateCube(cube, 5, 257);
                    return Constants.F2LAlgs[257];
                case 42:
                    Tools.RotateCube(cube, 5, 258);
                    return Constants.F2LAlgs[258];
                case 27:
                    Tools.RotateCube(cube, 5, 259);
                    return Constants.F2LAlgs[259];
                case 29:
                    Tools.RotateCube(cube, 5, 260);
                    return Constants.F2LAlgs[260];
                case 44:
                    Tools.RotateCube(cube, 5, 261);
                    return Constants.F2LAlgs[261];
                case 0:
                    Tools.RotateCube(cube, 5, 262);
                    return Constants.F2LAlgs[262];
                }
                break;
            case 37:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 5, 263);
                    return Constants.F2LAlgs[263];
                case 15:
                    Tools.RotateCube(cube, 5, 264);
                    return Constants.F2LAlgs[264];
                case 53:
                    Tools.RotateCube(cube, 5, 265);
                    return Constants.F2LAlgs[265];
                case 17:
                    Tools.RotateCube(cube, 5, 266);
                    return Constants.F2LAlgs[266];
                case 24:
                    Tools.RotateCube(cube, 5, 267);
                    return Constants.F2LAlgs[267];
                case 51:
                    Tools.RotateCube(cube, 5, 268);
                    return Constants.F2LAlgs[268];
                case 26:
                    Tools.RotateCube(cube, 5, 269);
                    return Constants.F2LAlgs[269];
                case 33:
                    Tools.RotateCube(cube, 5, 270);
                    return Constants.F2LAlgs[270];
                case 45:
                    Tools.RotateCube(cube, 5, 271);
                    return Constants.F2LAlgs[271];
                case 35:
                    Tools.RotateCube(cube, 5, 272);
                    return Constants.F2LAlgs[272];
                case 6:
                    Tools.RotateCube(cube, 5, 273);
                    return Constants.F2LAlgs[273];
                case 47:
                    Tools.RotateCube(cube, 5, 274);
                    return Constants.F2LAlgs[274];
                case 2:
                    Tools.RotateCube(cube, 5, 275);
                    return Constants.F2LAlgs[275];
                case 38:
                    Tools.RotateCube(cube, 5, 276);
                    return Constants.F2LAlgs[276];
                case 9:
                    Tools.RotateCube(cube, 5, 277);
                    return Constants.F2LAlgs[277];
                case 11:
                    Tools.RotateCube(cube, 5, 278);
                    return Constants.F2LAlgs[278];
                case 36:
                    Tools.RotateCube(cube, 5, 279);
                    return Constants.F2LAlgs[279];
                case 18:
                    Tools.RotateCube(cube, 5, 280);
                    return Constants.F2LAlgs[280];
                case 20:
                    Tools.RotateCube(cube, 5, 281);
                    return Constants.F2LAlgs[281];
                case 42:
                    Tools.RotateCube(cube, 5, 282);
                    return Constants.F2LAlgs[282];
                case 27:
                    Tools.RotateCube(cube, 5, 283);
                    return Constants.F2LAlgs[283];
                case 29:
                    Tools.RotateCube(cube, 5, 284);
                    return Constants.F2LAlgs[284];
                case 44:
                    Tools.RotateCube(cube, 5, 285);
                    return Constants.F2LAlgs[285];
                case 0:
                    Tools.RotateCube(cube, 5, 286);
                    return Constants.F2LAlgs[286];
                }
                break;
            case 19:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 5, 287);
                    return Constants.F2LAlgs[287];
                case 15:
                    Tools.RotateCube(cube, 5, 288);
                    return Constants.F2LAlgs[288];
                case 53:
                    Tools.RotateCube(cube, 5, 289);
                    return Constants.F2LAlgs[289];
                case 17:
                    Tools.RotateCube(cube, 5, 290);
                    return Constants.F2LAlgs[290];
                case 24:
                    Tools.RotateCube(cube, 5, 291);
                    return Constants.F2LAlgs[291];
                case 51:
                    Tools.RotateCube(cube, 5, 292);
                    return Constants.F2LAlgs[292];
                case 26:
                    Tools.RotateCube(cube, 5, 293);
                    return Constants.F2LAlgs[293];
                case 33:
                    Tools.RotateCube(cube, 5, 294);
                    return Constants.F2LAlgs[294];
                case 45:
                    Tools.RotateCube(cube, 5, 295);
                    return Constants.F2LAlgs[295];
                case 35:
                    Tools.RotateCube(cube, 5, 296);
                    return Constants.F2LAlgs[296];
                case 6:
                    Tools.RotateCube(cube, 5, 297);
                    return Constants.F2LAlgs[297];
                case 47:
                    Tools.RotateCube(cube, 5, 298);
                    return Constants.F2LAlgs[298];
                case 2:
                    Tools.RotateCube(cube, 5, 299);
                    return Constants.F2LAlgs[299];
                case 38:
                    Tools.RotateCube(cube, 5, 300);
                    return Constants.F2LAlgs[300];
                case 9:
                    Tools.RotateCube(cube, 5, 301);
                    return Constants.F2LAlgs[301];
                case 11:
                    Tools.RotateCube(cube, 5, 302);
                    return Constants.F2LAlgs[302];
                case 36:
                    Tools.RotateCube(cube, 5, 303);
                    return Constants.F2LAlgs[303];
                case 18:
                    Tools.RotateCube(cube, 5, 304);
                    return Constants.F2LAlgs[304];
                case 20:
                    Tools.RotateCube(cube, 5, 305);
                    return Constants.F2LAlgs[305];
                case 42:
                    Tools.RotateCube(cube, 5, 306);
                    return Constants.F2LAlgs[306];
                case 27:
                    Tools.RotateCube(cube, 5, 307);
                    return Constants.F2LAlgs[307];
                case 29:
                    Tools.RotateCube(cube, 5, 308);
                    return Constants.F2LAlgs[308];
                case 44:
                    Tools.RotateCube(cube, 5, 309);
                    return Constants.F2LAlgs[309];
                case 0:
                    Tools.RotateCube(cube, 5, 310);
                    return Constants.F2LAlgs[310];
                }
                break;
            case 39:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 5, 311);
                    return Constants.F2LAlgs[311];
                case 15:
                    Tools.RotateCube(cube, 5, 312);
                    return Constants.F2LAlgs[312];
                case 53:
                    Tools.RotateCube(cube, 5, 313);
                    return Constants.F2LAlgs[313];
                case 17:
                    Tools.RotateCube(cube, 5, 314);
                    return Constants.F2LAlgs[314];
                case 24:
                    Tools.RotateCube(cube, 5, 315);
                    return Constants.F2LAlgs[315];
                case 51:
                    Tools.RotateCube(cube, 5, 316);
                    return Constants.F2LAlgs[316];
                case 26:
                    Tools.RotateCube(cube, 5, 317);
                    return Constants.F2LAlgs[317];
                case 33:
                    Tools.RotateCube(cube, 5, 318);
                    return Constants.F2LAlgs[318];
                case 45:
                    Tools.RotateCube(cube, 5, 319);
                    return Constants.F2LAlgs[319];
                case 35:
                    Tools.RotateCube(cube, 5, 320);
                    return Constants.F2LAlgs[320];
                case 6:
                    Tools.RotateCube(cube, 5, 321);
                    return Constants.F2LAlgs[321];
                case 47:
                    Tools.RotateCube(cube, 5, 322);
                    return Constants.F2LAlgs[322];
                case 2:
                    Tools.RotateCube(cube, 5, 323);
                    return Constants.F2LAlgs[323];
                case 38:
                    Tools.RotateCube(cube, 5, 324);
                    return Constants.F2LAlgs[324];
                case 9:
                    Tools.RotateCube(cube, 5, 325);
                    return Constants.F2LAlgs[325];
                case 11:
                    Tools.RotateCube(cube, 5, 326);
                    return Constants.F2LAlgs[326];
                case 36:
                    Tools.RotateCube(cube, 5, 327);
                    return Constants.F2LAlgs[327];
                case 18:
                    Tools.RotateCube(cube, 5, 328);
                    return Constants.F2LAlgs[328];
                case 20:
                    Tools.RotateCube(cube, 5, 329);
                    return Constants.F2LAlgs[329];
                case 42:
                    Tools.RotateCube(cube, 5, 330);
                    return Constants.F2LAlgs[330];
                case 27:
                    Tools.RotateCube(cube, 5, 331);
                    return Constants.F2LAlgs[331];
                case 29:
                    Tools.RotateCube(cube, 5, 332);
                    return Constants.F2LAlgs[332];
                case 44:
                    Tools.RotateCube(cube, 5, 333);
                    return Constants.F2LAlgs[333];
                case 0:
                    Tools.RotateCube(cube, 5, 334);
                    return Constants.F2LAlgs[334];
                }
                break;
            case 28:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 5, 335);
                    return Constants.F2LAlgs[335];
                case 15:
                    Tools.RotateCube(cube, 5, 336);
                    return Constants.F2LAlgs[336];
                case 53:
                    Tools.RotateCube(cube, 5, 337);
                    return Constants.F2LAlgs[337];
                case 17:
                    Tools.RotateCube(cube, 5, 338);
                    return Constants.F2LAlgs[338];
                case 24:
                    Tools.RotateCube(cube, 5, 339);
                    return Constants.F2LAlgs[339];
                case 51:
                    Tools.RotateCube(cube, 5, 340);
                    return Constants.F2LAlgs[340];
                case 26:
                    Tools.RotateCube(cube, 5, 341);
                    return Constants.F2LAlgs[341];
                case 33:
                    Tools.RotateCube(cube, 5, 342);
                    return Constants.F2LAlgs[342];
                case 45:
                    Tools.RotateCube(cube, 5, 343);
                    return Constants.F2LAlgs[343];
                case 35:
                    Tools.RotateCube(cube, 5, 344);
                    return Constants.F2LAlgs[344];
                case 6:
                    Tools.RotateCube(cube, 5, 345);
                    return Constants.F2LAlgs[345];
                case 47:
                    Tools.RotateCube(cube, 5, 346);
                    return Constants.F2LAlgs[346];
                case 2:
                    Tools.RotateCube(cube, 5, 347);
                    return Constants.F2LAlgs[347];
                case 38:
                    Tools.RotateCube(cube, 5, 348);
                    return Constants.F2LAlgs[348];
                case 9:
                    Tools.RotateCube(cube, 5, 349);
                    return Constants.F2LAlgs[349];
                case 11:
                    Tools.RotateCube(cube, 5, 350);
                    return Constants.F2LAlgs[350];
                case 36:
                    Tools.RotateCube(cube, 5, 351);
                    return Constants.F2LAlgs[351];
                case 18:
                    Tools.RotateCube(cube, 5, 352);
                    return Constants.F2LAlgs[352];
                case 20:
                    Tools.RotateCube(cube, 5, 353);
                    return Constants.F2LAlgs[353];
                case 42:
                    Tools.RotateCube(cube, 5, 354);
                    return Constants.F2LAlgs[354];
                case 27:
                    Tools.RotateCube(cube, 5, 355);
                    return Constants.F2LAlgs[355];
                case 29:
                    Tools.RotateCube(cube, 5, 356);
                    return Constants.F2LAlgs[356];
                case 44:
                    Tools.RotateCube(cube, 5, 357);
                    return Constants.F2LAlgs[357];
                case 0:
                    Tools.RotateCube(cube, 5, 358);
                    return Constants.F2LAlgs[358];
                }
                break;
            case 43:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 5, 359);
                    return Constants.F2LAlgs[359];
                case 15:
                    Tools.RotateCube(cube, 5, 360);
                    return Constants.F2LAlgs[360];
                case 53:
                    Tools.RotateCube(cube, 5, 361);
                    return Constants.F2LAlgs[361];
                case 17:
                    Tools.RotateCube(cube, 5, 362);
                    return Constants.F2LAlgs[362];
                case 24:
                    Tools.RotateCube(cube, 5, 363);
                    return Constants.F2LAlgs[363];
                case 51:
                    Tools.RotateCube(cube, 5, 364);
                    return Constants.F2LAlgs[364];
                case 26:
                    Tools.RotateCube(cube, 5, 365);
                    return Constants.F2LAlgs[365];
                case 33:
                    Tools.RotateCube(cube, 5, 366);
                    return Constants.F2LAlgs[366];
                case 45:
                    Tools.RotateCube(cube, 5, 367);
                    return Constants.F2LAlgs[367];
                case 35:
                    Tools.RotateCube(cube, 5, 368);
                    return Constants.F2LAlgs[368];
                case 6:
                    Tools.RotateCube(cube, 5, 369);
                    return Constants.F2LAlgs[369];
                case 47:
                    Tools.RotateCube(cube, 5, 370);
                    return Constants.F2LAlgs[370];
                case 2:
                    Tools.RotateCube(cube, 5, 371);
                    return Constants.F2LAlgs[371];
                case 38:
                    Tools.RotateCube(cube, 5, 372);
                    return Constants.F2LAlgs[372];
                case 9:
                    Tools.RotateCube(cube, 5, 373);
                    return Constants.F2LAlgs[373];
                case 11:
                    Tools.RotateCube(cube, 5, 374);
                    return Constants.F2LAlgs[374];
                case 36:
                    Tools.RotateCube(cube, 5, 375);
                    return Constants.F2LAlgs[375];
                case 18:
                    Tools.RotateCube(cube, 5, 376);
                    return Constants.F2LAlgs[376];
                case 20:
                    Tools.RotateCube(cube, 5, 377);
                    return Constants.F2LAlgs[377];
                case 42:
                    Tools.RotateCube(cube, 5, 378);
                    return Constants.F2LAlgs[378];
                case 27:
                    Tools.RotateCube(cube, 5, 379);
                    return Constants.F2LAlgs[379];
                case 29:
                    Tools.RotateCube(cube, 5, 380);
                    return Constants.F2LAlgs[380];
                case 44:
                    Tools.RotateCube(cube, 5, 381);
                    return Constants.F2LAlgs[381];
                case 0:
                    Tools.RotateCube(cube, 5, 382);
                    return Constants.F2LAlgs[382];
                }
                break;
            }
            return string.Empty;
        }

        private static string F2L_RG(char[] cube){
            switch(ecc1){
            case 5:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 4, 50);
                    return Tools.YdPerm(Constants.F2LAlgs[50]);
                case 15:
                    Tools.RotateCube(cube, 4, 51);
                    return Tools.YdPerm(Constants.F2LAlgs[51]);
                case 53:
                    Tools.RotateCube(cube, 4, 52);
                    return Tools.YdPerm(Constants.F2LAlgs[52]);
                case 17:
                    Tools.RotateCube(cube, 4, 53);
                    return Tools.YdPerm(Constants.F2LAlgs[53]);
                case 24:
                    Tools.RotateCube(cube, 4, 54);
                    return Tools.YdPerm(Constants.F2LAlgs[54]);
                case 51:
                    Tools.RotateCube(cube, 4, 55);
                    return Tools.YdPerm(Constants.F2LAlgs[55]);
                case 26:
                    Tools.RotateCube(cube, 4, 56);
                    return Tools.YdPerm(Constants.F2LAlgs[56]);
                case 33:
                    Tools.RotateCube(cube, 4, 57);
                    return Tools.YdPerm(Constants.F2LAlgs[57]);
                case 45:
                    Tools.RotateCube(cube, 4, 58);
                    return Tools.YdPerm(Constants.F2LAlgs[58]);
                case 35:
                    Tools.RotateCube(cube, 4, 47);
                    return Tools.YdPerm(Constants.F2LAlgs[47]);
                case 6:
                    Tools.RotateCube(cube, 4, 48);
                    return Tools.YdPerm(Constants.F2LAlgs[48]);
                case 47:
                    Tools.RotateCube(cube, 4, 49);
                    return Tools.YdPerm(Constants.F2LAlgs[49]);
                case 2:
                    Tools.RotateCube(cube, 4, 62);
                    return Tools.YdPerm(Constants.F2LAlgs[62]);
                case 38:
                    Tools.RotateCube(cube, 4, 63);
                    return Tools.YdPerm(Constants.F2LAlgs[63]);
                case 9:
                    Tools.RotateCube(cube, 4, 64);
                    return Tools.YdPerm(Constants.F2LAlgs[64]);
                case 11:
                    Tools.RotateCube(cube, 4, 65);
                    return Tools.YdPerm(Constants.F2LAlgs[65]);
                case 36:
                    Tools.RotateCube(cube, 4, 66);
                    return Tools.YdPerm(Constants.F2LAlgs[66]);
                case 18:
                    Tools.RotateCube(cube, 4, 67);
                    return Tools.YdPerm(Constants.F2LAlgs[67]);
                case 20:
                    Tools.RotateCube(cube, 4, 68);
                    return Tools.YdPerm(Constants.F2LAlgs[68]);
                case 42:
                    Tools.RotateCube(cube, 4, 69);
                    return Tools.YdPerm(Constants.F2LAlgs[69]);
                case 27:
                    Tools.RotateCube(cube, 4, 70);
                    return Tools.YdPerm(Constants.F2LAlgs[70]);
                case 29:
                    Tools.RotateCube(cube, 4, 59);
                    return Tools.YdPerm(Constants.F2LAlgs[59]);
                case 44:
                    Tools.RotateCube(cube, 4, 60);
                    return Tools.YdPerm(Constants.F2LAlgs[60]);
                case 0:
                    Tools.RotateCube(cube, 4, 61);
                    return Tools.YdPerm(Constants.F2LAlgs[61]);
                }
                break;
            case 12:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 4, 74);
                    return Tools.YdPerm(Constants.F2LAlgs[74]);
                case 15:
                    Tools.RotateCube(cube, 4, 75);
                    return Tools.YdPerm(Constants.F2LAlgs[75]);
                case 53:
                    Tools.RotateCube(cube, 4, 76);
                    return Tools.YdPerm(Constants.F2LAlgs[76]);
                case 17:
                    Tools.RotateCube(cube, 4, 77);
                    return Tools.YdPerm(Constants.F2LAlgs[77]);
                case 24:
                    Tools.RotateCube(cube, 4, 78);
                    return Tools.YdPerm(Constants.F2LAlgs[78]);
                case 51:
                    Tools.RotateCube(cube, 4, 79);
                    return Tools.YdPerm(Constants.F2LAlgs[79]);
                case 26:
                    Tools.RotateCube(cube, 4, 80);
                    return Tools.YdPerm(Constants.F2LAlgs[80]);
                case 33:
                    Tools.RotateCube(cube, 4, 81);
                    return Tools.YdPerm(Constants.F2LAlgs[81]);
                case 45:
                    Tools.RotateCube(cube, 4, 82);
                    return Tools.YdPerm(Constants.F2LAlgs[82]);
                case 35:
                    Tools.RotateCube(cube, 4, 71);
                    return Tools.YdPerm(Constants.F2LAlgs[71]);
                case 6:
                    Tools.RotateCube(cube, 4, 72);
                    return Tools.YdPerm(Constants.F2LAlgs[72]);
                case 47:
                    Tools.RotateCube(cube, 4, 73);
                    return Tools.YdPerm(Constants.F2LAlgs[73]);
                case 2:
                    Tools.RotateCube(cube, 4, 86);
                    return Tools.YdPerm(Constants.F2LAlgs[86]);
                case 38:
                    Tools.RotateCube(cube, 4, 87);
                    return Tools.YdPerm(Constants.F2LAlgs[87]);
                case 9:
                    Tools.RotateCube(cube, 4, 88);
                    return Tools.YdPerm(Constants.F2LAlgs[88]);
                case 11:
                    Tools.RotateCube(cube, 4, 89);
                    return Tools.YdPerm(Constants.F2LAlgs[89]);
                case 36:
                    Tools.RotateCube(cube, 4, 90);
                    return Tools.YdPerm(Constants.F2LAlgs[90]);
                case 18:
                    Tools.RotateCube(cube, 4, 91);
                    return Tools.YdPerm(Constants.F2LAlgs[91]);
                case 20:
                    Tools.RotateCube(cube, 4, 92);
                    return Tools.YdPerm(Constants.F2LAlgs[92]);
                case 42:
                    Tools.RotateCube(cube, 4, 93);
                    return Tools.YdPerm(Constants.F2LAlgs[93]);
                case 27:
                    Tools.RotateCube(cube, 4, 94);
                    return Tools.YdPerm(Constants.F2LAlgs[94]);
                case 29:
                    Tools.RotateCube(cube, 4, 83);
                    return Tools.YdPerm(Constants.F2LAlgs[83]);
                case 44:
                    Tools.RotateCube(cube, 4, 84);
                    return Tools.YdPerm(Constants.F2LAlgs[84]);
                case 0:
                    Tools.RotateCube(cube, 4, 85);
                    return Tools.YdPerm(Constants.F2LAlgs[85]);
                }
                break;
            case 14:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 4, 98);
                    return Tools.YdPerm(Constants.F2LAlgs[98]);
                case 15:
                    Tools.RotateCube(cube, 4, 99);
                    return Tools.YdPerm(Constants.F2LAlgs[99]);
                case 53:
                    Tools.RotateCube(cube, 4, 100);
                    return Tools.YdPerm(Constants.F2LAlgs[100]);
                case 17:
                    Tools.RotateCube(cube, 4, 101);
                    return Tools.YdPerm(Constants.F2LAlgs[101]);
                case 24:
                    Tools.RotateCube(cube, 4, 102);
                    return Tools.YdPerm(Constants.F2LAlgs[102]);
                case 51:
                    Tools.RotateCube(cube, 4, 103);
                    return Tools.YdPerm(Constants.F2LAlgs[103]);
                case 26:
                    Tools.RotateCube(cube, 4, 104);
                    return Tools.YdPerm(Constants.F2LAlgs[104]);
                case 33:
                    Tools.RotateCube(cube, 4, 105);
                    return Tools.YdPerm(Constants.F2LAlgs[105]);
                case 45:
                    Tools.RotateCube(cube, 4, 106);
                    return Tools.YdPerm(Constants.F2LAlgs[106]);
                case 35:
                    Tools.RotateCube(cube, 4, 95);
                    return Tools.YdPerm(Constants.F2LAlgs[95]);
                case 6:
                    Tools.RotateCube(cube, 4, 96);
                    return Tools.YdPerm(Constants.F2LAlgs[96]);
                case 47:
                    Tools.RotateCube(cube, 4, 97);
                    return Tools.YdPerm(Constants.F2LAlgs[97]);
                case 2:
                    Tools.RotateCube(cube, 4, 110);
                    return Tools.YdPerm(Constants.F2LAlgs[110]);
                case 38:
                    Tools.RotateCube(cube, 4, 111);
                    return Tools.YdPerm(Constants.F2LAlgs[111]);
                case 9:
                    Tools.RotateCube(cube, 4, 112);
                    return Tools.YdPerm(Constants.F2LAlgs[112]);
                case 11:
                    Tools.RotateCube(cube, 4, 113);
                    return Tools.YdPerm(Constants.F2LAlgs[113]);
                case 36:
                    Tools.RotateCube(cube, 4, 114);
                    return Tools.YdPerm(Constants.F2LAlgs[114]);
                case 18:
                    Tools.RotateCube(cube, 4, 115);
                    return Tools.YdPerm(Constants.F2LAlgs[115]);
                case 20:
                    Tools.RotateCube(cube, 4, 116);
                    return Tools.YdPerm(Constants.F2LAlgs[116]);
                case 42:
                    Tools.RotateCube(cube, 4, 117);
                    return Tools.YdPerm(Constants.F2LAlgs[117]);
                case 27:
                    Tools.RotateCube(cube, 4, 118);
                    return Tools.YdPerm(Constants.F2LAlgs[118]);
                case 29:
                    Tools.RotateCube(cube, 4, 107);
                    return Tools.YdPerm(Constants.F2LAlgs[107]);
                case 44:
                    Tools.RotateCube(cube, 4, 108);
                    return Tools.YdPerm(Constants.F2LAlgs[108]);
                case 0:
                    Tools.RotateCube(cube, 4, 109);
                    return Tools.YdPerm(Constants.F2LAlgs[109]);
                }
                break;
            case 21:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 4, 122);
                    return Tools.YdPerm(Constants.F2LAlgs[122]);
                case 15:
                    Tools.RotateCube(cube, 4, 123);
                    return Tools.YdPerm(Constants.F2LAlgs[123]);
                case 53:
                    Tools.RotateCube(cube, 4, 124);
                    return Tools.YdPerm(Constants.F2LAlgs[124]);
                case 17:
                    Tools.RotateCube(cube, 4, 125);
                    return Tools.YdPerm(Constants.F2LAlgs[125]);
                case 24:
                    Tools.RotateCube(cube, 4, 126);
                    return Tools.YdPerm(Constants.F2LAlgs[126]);
                case 51:
                    Tools.RotateCube(cube, 4, 127);
                    return Tools.YdPerm(Constants.F2LAlgs[127]);
                case 26:
                    Tools.RotateCube(cube, 4, 128);
                    return Tools.YdPerm(Constants.F2LAlgs[128]);
                case 33:
                    Tools.RotateCube(cube, 4, 129);
                    return Tools.YdPerm(Constants.F2LAlgs[129]);
                case 45:
                    Tools.RotateCube(cube, 4, 130);
                    return Tools.YdPerm(Constants.F2LAlgs[130]);
                case 35:
                    Tools.RotateCube(cube, 4, 119);
                    return Tools.YdPerm(Constants.F2LAlgs[119]);
                case 6:
                    Tools.RotateCube(cube, 4, 120);
                    return Tools.YdPerm(Constants.F2LAlgs[120]);
                case 47:
                    Tools.RotateCube(cube, 4, 121);
                    return Tools.YdPerm(Constants.F2LAlgs[121]);
                case 2:
                    Tools.RotateCube(cube, 4, 134);
                    return Tools.YdPerm(Constants.F2LAlgs[134]);
                case 38:
                    Tools.RotateCube(cube, 4, 135);
                    return Tools.YdPerm(Constants.F2LAlgs[135]);
                case 9:
                    Tools.RotateCube(cube, 4, 136);
                    return Tools.YdPerm(Constants.F2LAlgs[136]);
                case 11:
                    Tools.RotateCube(cube, 4, 137);
                    return Tools.YdPerm(Constants.F2LAlgs[137]);
                case 36:
                    Tools.RotateCube(cube, 4, 138);
                    return Tools.YdPerm(Constants.F2LAlgs[138]);
                case 18:
                    Tools.RotateCube(cube, 4, 139);
                    return Tools.YdPerm(Constants.F2LAlgs[139]);
                case 20:
                    Tools.RotateCube(cube, 4, 140);
                    return Tools.YdPerm(Constants.F2LAlgs[140]);
                case 42:
                    Tools.RotateCube(cube, 4, 141);
                    return Tools.YdPerm(Constants.F2LAlgs[141]);
                case 27:
                    Tools.RotateCube(cube, 4, 142);
                    return Tools.YdPerm(Constants.F2LAlgs[142]);
                case 29:
                    Tools.RotateCube(cube, 4, 131);
                    return Tools.YdPerm(Constants.F2LAlgs[131]);
                case 44:
                    Tools.RotateCube(cube, 4, 132);
                    return Tools.YdPerm(Constants.F2LAlgs[132]);
                case 0:
                    Tools.RotateCube(cube, 4, 133);
                    return Tools.YdPerm(Constants.F2LAlgs[133]);
                }
                break;
            case 23:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 4, 146);
                    return Tools.YdPerm(Constants.F2LAlgs[146]);
                case 15:
                    Tools.RotateCube(cube, 4, 147);
                    return Tools.YdPerm(Constants.F2LAlgs[147]);
                case 53:
                    Tools.RotateCube(cube, 4, 148);
                    return Tools.YdPerm(Constants.F2LAlgs[148]);
                case 17:
                    Tools.RotateCube(cube, 4, 149);
                    return Tools.YdPerm(Constants.F2LAlgs[149]);
                case 24:
                    Tools.RotateCube(cube, 4, 150);
                    return Tools.YdPerm(Constants.F2LAlgs[150]);
                case 51:
                    Tools.RotateCube(cube, 4, 151);
                    return Tools.YdPerm(Constants.F2LAlgs[151]);
                case 26:
                    Tools.RotateCube(cube, 4, 152);
                    return Tools.YdPerm(Constants.F2LAlgs[152]);
                case 33:
                    Tools.RotateCube(cube, 4, 153);
                    return Tools.YdPerm(Constants.F2LAlgs[153]);
                case 45:
                    Tools.RotateCube(cube, 4, 154);
                    return Tools.YdPerm(Constants.F2LAlgs[154]);
                case 35:
                    Tools.RotateCube(cube, 4, 143);
                    return Tools.YdPerm(Constants.F2LAlgs[143]);
                case 6:
                    Tools.RotateCube(cube, 4, 144);
                    return Tools.YdPerm(Constants.F2LAlgs[144]);
                case 47:
                    Tools.RotateCube(cube, 4, 145);
                    return Tools.YdPerm(Constants.F2LAlgs[145]);
                case 2:
                    Tools.RotateCube(cube, 4, 158);
                    return Tools.YdPerm(Constants.F2LAlgs[158]);
                case 38:
                    Tools.RotateCube(cube, 4, 159);
                    return Tools.YdPerm(Constants.F2LAlgs[159]);
                case 9:
                    Tools.RotateCube(cube, 4, 160);
                    return Tools.YdPerm(Constants.F2LAlgs[160]);
                case 11:
                    Tools.RotateCube(cube, 4, 161);
                    return Tools.YdPerm(Constants.F2LAlgs[161]);
                case 36:
                    Tools.RotateCube(cube, 4, 162);
                    return Tools.YdPerm(Constants.F2LAlgs[162]);
                case 18:
                    Tools.RotateCube(cube, 4, 163);
                    return Tools.YdPerm(Constants.F2LAlgs[163]);
                case 20:
                    Tools.RotateCube(cube, 4, 164);
                    return Tools.YdPerm(Constants.F2LAlgs[164]);
                case 42:
                    Tools.RotateCube(cube, 4, 165);
                    return Tools.YdPerm(Constants.F2LAlgs[165]);
                case 27:
                    Tools.RotateCube(cube, 4, 166);
                    return Tools.YdPerm(Constants.F2LAlgs[166]);
                case 29:
                    Tools.RotateCube(cube, 4, 155);
                    return Tools.YdPerm(Constants.F2LAlgs[155]);
                case 44:
                    Tools.RotateCube(cube, 4, 156);
                    return Tools.YdPerm(Constants.F2LAlgs[156]);
                case 0:
                    Tools.RotateCube(cube, 4, 157);
                    return Tools.YdPerm(Constants.F2LAlgs[157]);
                }
                break;
            case 30:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 4, 170);
                    return Tools.YdPerm(Constants.F2LAlgs[170]);
                case 15:
                    Tools.RotateCube(cube, 4, 171);
                    return Tools.YdPerm(Constants.F2LAlgs[171]);
                case 53:
                    Tools.RotateCube(cube, 4, 172);
                    return Tools.YdPerm(Constants.F2LAlgs[172]);
                case 17:
                    Tools.RotateCube(cube, 4, 173);
                    return Tools.YdPerm(Constants.F2LAlgs[173]);
                case 24:
                    Tools.RotateCube(cube, 4, 174);
                    return Tools.YdPerm(Constants.F2LAlgs[174]);
                case 51:
                    Tools.RotateCube(cube, 4, 175);
                    return Tools.YdPerm(Constants.F2LAlgs[175]);
                case 26:
                    Tools.RotateCube(cube, 4, 176);
                    return Tools.YdPerm(Constants.F2LAlgs[176]);
                case 33:
                    Tools.RotateCube(cube, 4, 177);
                    return Tools.YdPerm(Constants.F2LAlgs[177]);
                case 45:
                    Tools.RotateCube(cube, 4, 178);
                    return Tools.YdPerm(Constants.F2LAlgs[178]);
                case 35:
                    Tools.RotateCube(cube, 4, 167);
                    return Tools.YdPerm(Constants.F2LAlgs[167]);
                case 6:
                    Tools.RotateCube(cube, 4, 168);
                    return Tools.YdPerm(Constants.F2LAlgs[168]);
                case 47:
                    Tools.RotateCube(cube, 4, 169);
                    return Tools.YdPerm(Constants.F2LAlgs[169]);
                case 2:
                    Tools.RotateCube(cube, 4, 182);
                    return Tools.YdPerm(Constants.F2LAlgs[182]);
                case 38:
                    Tools.RotateCube(cube, 4, 183);
                    return Tools.YdPerm(Constants.F2LAlgs[183]);
                case 9:
                    Tools.RotateCube(cube, 4, 184);
                    return Tools.YdPerm(Constants.F2LAlgs[184]);
                case 11:
                    Tools.RotateCube(cube, 4, 185);
                    return Tools.YdPerm(Constants.F2LAlgs[185]);
                case 36:
                    Tools.RotateCube(cube, 4, 186);
                    return Tools.YdPerm(Constants.F2LAlgs[186]);
                case 18:
                    Tools.RotateCube(cube, 4, 187);
                    return Tools.YdPerm(Constants.F2LAlgs[187]);
                case 20:
                    Tools.RotateCube(cube, 4, 188);
                    return Tools.YdPerm(Constants.F2LAlgs[188]);
                case 42:
                    Tools.RotateCube(cube, 4, 189);
                    return Tools.YdPerm(Constants.F2LAlgs[189]);
                case 27:
                    Tools.RotateCube(cube, 4, 190);
                    return Tools.YdPerm(Constants.F2LAlgs[190]);
                case 29:
                    Tools.RotateCube(cube, 4, 179);
                    return Tools.YdPerm(Constants.F2LAlgs[179]);
                case 44:
                    Tools.RotateCube(cube, 4, 180);
                    return Tools.YdPerm(Constants.F2LAlgs[180]);
                case 0:
                    Tools.RotateCube(cube, 4, 181);
                    return Tools.YdPerm(Constants.F2LAlgs[181]);
                }
                break;
            case 32:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 4, 2);
                    return Tools.YdPerm(Constants.F2LAlgs[2]);
                case 15:
                    Tools.RotateCube(cube, 4, 3);
                    return Tools.YdPerm(Constants.F2LAlgs[3]);
                case 53:
                    Tools.RotateCube(cube, 4, 4);
                    return Tools.YdPerm(Constants.F2LAlgs[4]);
                case 17:
                    Tools.RotateCube(cube, 4, 5);
                    return Tools.YdPerm(Constants.F2LAlgs[5]);
                case 24:
                    Tools.RotateCube(cube, 4, 6);
                    return Tools.YdPerm(Constants.F2LAlgs[6]);
                case 51:
                    Tools.RotateCube(cube, 4, 7);
                    return Tools.YdPerm(Constants.F2LAlgs[7]);
                case 26:
                    Tools.RotateCube(cube, 4, 8);
                    return Tools.YdPerm(Constants.F2LAlgs[8]);
                case 33:
                    Tools.RotateCube(cube, 4, 9);
                    return Tools.YdPerm(Constants.F2LAlgs[9]);
                case 45:
                    Tools.RotateCube(cube, 4, 10);
                    return Tools.YdPerm(Constants.F2LAlgs[10]);
                case 6:
                    Tools.RotateCube(cube, 4, 0);
                    return Tools.YdPerm(Constants.F2LAlgs[0]);
                case 47:
                    Tools.RotateCube(cube, 4, 1);
                    return Tools.YdPerm(Constants.F2LAlgs[1]);
                case 2:
                    Tools.RotateCube(cube, 4, 14);
                    return Tools.YdPerm(Constants.F2LAlgs[14]);
                case 38:
                    Tools.RotateCube(cube, 4, 15);
                    return Tools.YdPerm(Constants.F2LAlgs[15]);
                case 9:
                    Tools.RotateCube(cube, 4, 16);
                    return Tools.YdPerm(Constants.F2LAlgs[16]);
                case 11:
                    Tools.RotateCube(cube, 4, 17);
                    return Tools.YdPerm(Constants.F2LAlgs[17]);
                case 36:
                    Tools.RotateCube(cube, 4, 18);
                    return Tools.YdPerm(Constants.F2LAlgs[18]);
                case 18:
                    Tools.RotateCube(cube, 4, 19);
                    return Tools.YdPerm(Constants.F2LAlgs[19]);
                case 20:
                    Tools.RotateCube(cube, 4, 20);
                    return Tools.YdPerm(Constants.F2LAlgs[20]);
                case 42:
                    Tools.RotateCube(cube, 4, 21);
                    return Tools.YdPerm(Constants.F2LAlgs[21]);
                case 27:
                    Tools.RotateCube(cube, 4, 22);
                    return Tools.YdPerm(Constants.F2LAlgs[22]);
                case 29:
                    Tools.RotateCube(cube, 4, 11);
                    return Tools.YdPerm(Constants.F2LAlgs[11]);
                case 44:
                    Tools.RotateCube(cube, 4, 12);
                    return Tools.YdPerm(Constants.F2LAlgs[12]);
                case 0:
                    Tools.RotateCube(cube, 4, 13);
                    return Tools.YdPerm(Constants.F2LAlgs[13]);
                }
                break;
            case 3:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 4, 26);
                    return Tools.YdPerm(Constants.F2LAlgs[26]);
                case 15:
                    Tools.RotateCube(cube, 4, 27);
                    return Tools.YdPerm(Constants.F2LAlgs[27]);
                case 53:
                    Tools.RotateCube(cube, 4, 28);
                    return Tools.YdPerm(Constants.F2LAlgs[28]);
                case 17:
                    Tools.RotateCube(cube, 4, 29);
                    return Tools.YdPerm(Constants.F2LAlgs[29]);
                case 24:
                    Tools.RotateCube(cube, 4, 30);
                    return Tools.YdPerm(Constants.F2LAlgs[30]);
                case 51:
                    Tools.RotateCube(cube, 4, 31);
                    return Tools.YdPerm(Constants.F2LAlgs[31]);
                case 26:
                    Tools.RotateCube(cube, 4, 32);
                    return Tools.YdPerm(Constants.F2LAlgs[32]);
                case 33:
                    Tools.RotateCube(cube, 4, 33);
                    return Tools.YdPerm(Constants.F2LAlgs[33]);
                case 45:
                    Tools.RotateCube(cube, 4, 34);
                    return Tools.YdPerm(Constants.F2LAlgs[34]);
                case 35:
                    Tools.RotateCube(cube, 4, 23);
                    return Tools.YdPerm(Constants.F2LAlgs[23]);
                case 6:
                    Tools.RotateCube(cube, 4, 24);
                    return Tools.YdPerm(Constants.F2LAlgs[24]);
                case 47:
                    Tools.RotateCube(cube, 4, 25);
                    return Tools.YdPerm(Constants.F2LAlgs[25]);
                case 2:
                    Tools.RotateCube(cube, 4, 38);
                    return Tools.YdPerm(Constants.F2LAlgs[38]);
                case 38:
                    Tools.RotateCube(cube, 4, 39);
                    return Tools.YdPerm(Constants.F2LAlgs[39]);
                case 9:
                    Tools.RotateCube(cube, 4, 40);
                    return Tools.YdPerm(Constants.F2LAlgs[40]);
                case 11:
                    Tools.RotateCube(cube, 4, 41);
                    return Tools.YdPerm(Constants.F2LAlgs[41]);
                case 36:
                    Tools.RotateCube(cube, 4, 42);
                    return Tools.YdPerm(Constants.F2LAlgs[42]);
                case 18:
                    Tools.RotateCube(cube, 4, 43);
                    return Tools.YdPerm(Constants.F2LAlgs[43]);
                case 20:
                    Tools.RotateCube(cube, 4, 44);
                    return Tools.YdPerm(Constants.F2LAlgs[44]);
                case 42:
                    Tools.RotateCube(cube, 4, 45);
                    return Tools.YdPerm(Constants.F2LAlgs[45]);
                case 27:
                    Tools.RotateCube(cube, 4, 46);
                    return Tools.YdPerm(Constants.F2LAlgs[46]);
                case 29:
                    Tools.RotateCube(cube, 4, 35);
                    return Tools.YdPerm(Constants.F2LAlgs[35]);
                case 44:
                    Tools.RotateCube(cube, 4, 36);
                    return Tools.YdPerm(Constants.F2LAlgs[36]);
                case 0:
                    Tools.RotateCube(cube, 4, 37);
                    return Tools.YdPerm(Constants.F2LAlgs[37]);
                }
                break;
            case 1:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 4, 242);
                    return Tools.YdPerm(Constants.F2LAlgs[242]);
                case 15:
                    Tools.RotateCube(cube, 4, 243);
                    return Tools.YdPerm(Constants.F2LAlgs[243]);
                case 53:
                    Tools.RotateCube(cube, 4, 244);
                    return Tools.YdPerm(Constants.F2LAlgs[244]);
                case 17:
                    Tools.RotateCube(cube, 4, 245);
                    return Tools.YdPerm(Constants.F2LAlgs[245]);
                case 24:
                    Tools.RotateCube(cube, 4, 246);
                    return Tools.YdPerm(Constants.F2LAlgs[246]);
                case 51:
                    Tools.RotateCube(cube, 4, 247);
                    return Tools.YdPerm(Constants.F2LAlgs[247]);
                case 26:
                    Tools.RotateCube(cube, 4, 248);
                    return Tools.YdPerm(Constants.F2LAlgs[248]);
                case 33:
                    Tools.RotateCube(cube, 4, 249);
                    return Tools.YdPerm(Constants.F2LAlgs[249]);
                case 45:
                    Tools.RotateCube(cube, 4, 250);
                    return Tools.YdPerm(Constants.F2LAlgs[250]);
                case 35:
                    Tools.RotateCube(cube, 4, 239);
                    return Tools.YdPerm(Constants.F2LAlgs[239]);
                case 6:
                    Tools.RotateCube(cube, 4, 240);
                    return Tools.YdPerm(Constants.F2LAlgs[240]);
                case 47:
                    Tools.RotateCube(cube, 4, 241);
                    return Tools.YdPerm(Constants.F2LAlgs[241]);
                case 2:
                    Tools.RotateCube(cube, 4, 254);
                    return Tools.YdPerm(Constants.F2LAlgs[254]);
                case 38:
                    Tools.RotateCube(cube, 4, 255);
                    return Tools.YdPerm(Constants.F2LAlgs[255]);
                case 9:
                    Tools.RotateCube(cube, 4, 256);
                    return Tools.YdPerm(Constants.F2LAlgs[256]);
                case 11:
                    Tools.RotateCube(cube, 4, 257);
                    return Tools.YdPerm(Constants.F2LAlgs[257]);
                case 36:
                    Tools.RotateCube(cube, 4, 258);
                    return Tools.YdPerm(Constants.F2LAlgs[258]);
                case 18:
                    Tools.RotateCube(cube, 4, 259);
                    return Tools.YdPerm(Constants.F2LAlgs[259]);
                case 20:
                    Tools.RotateCube(cube, 4, 260);
                    return Tools.YdPerm(Constants.F2LAlgs[260]);
                case 42:
                    Tools.RotateCube(cube, 4, 261);
                    return Tools.YdPerm(Constants.F2LAlgs[261]);
                case 27:
                    Tools.RotateCube(cube, 4, 262);
                    return Tools.YdPerm(Constants.F2LAlgs[262]);
                case 29:
                    Tools.RotateCube(cube, 4, 251);
                    return Tools.YdPerm(Constants.F2LAlgs[251]);
                case 44:
                    Tools.RotateCube(cube, 4, 252);
                    return Tools.YdPerm(Constants.F2LAlgs[252]);
                case 0:
                    Tools.RotateCube(cube, 4, 253);
                    return Tools.YdPerm(Constants.F2LAlgs[253]);
                }
                break;
            case 41:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 4, 266);
                    return Tools.YdPerm(Constants.F2LAlgs[266]);
                case 15:
                    Tools.RotateCube(cube, 4, 267);
                    return Tools.YdPerm(Constants.F2LAlgs[267]);
                case 53:
                    Tools.RotateCube(cube, 4, 268);
                    return Tools.YdPerm(Constants.F2LAlgs[268]);
                case 17:
                    Tools.RotateCube(cube, 4, 269);
                    return Tools.YdPerm(Constants.F2LAlgs[269]);
                case 24:
                    Tools.RotateCube(cube, 4, 270);
                    return Tools.YdPerm(Constants.F2LAlgs[270]);
                case 51:
                    Tools.RotateCube(cube, 4, 271);
                    return Tools.YdPerm(Constants.F2LAlgs[271]);
                case 26:
                    Tools.RotateCube(cube, 4, 272);
                    return Tools.YdPerm(Constants.F2LAlgs[272]);
                case 33:
                    Tools.RotateCube(cube, 4, 273);
                    return Tools.YdPerm(Constants.F2LAlgs[273]);
                case 45:
                    Tools.RotateCube(cube, 4, 274);
                    return Tools.YdPerm(Constants.F2LAlgs[274]);
                case 35:
                    Tools.RotateCube(cube, 4, 263);
                    return Tools.YdPerm(Constants.F2LAlgs[263]);
                case 6:
                    Tools.RotateCube(cube, 4, 264);
                    return Tools.YdPerm(Constants.F2LAlgs[264]);
                case 47:
                    Tools.RotateCube(cube, 4, 265);
                    return Tools.YdPerm(Constants.F2LAlgs[265]);
                case 2:
                    Tools.RotateCube(cube, 4, 278);
                    return Tools.YdPerm(Constants.F2LAlgs[278]);
                case 38:
                    Tools.RotateCube(cube, 4, 279);
                    return Tools.YdPerm(Constants.F2LAlgs[279]);
                case 9:
                    Tools.RotateCube(cube, 4, 280);
                    return Tools.YdPerm(Constants.F2LAlgs[280]);
                case 11:
                    Tools.RotateCube(cube, 4, 281);
                    return Tools.YdPerm(Constants.F2LAlgs[281]);
                case 36:
                    Tools.RotateCube(cube, 4, 282);
                    return Tools.YdPerm(Constants.F2LAlgs[282]);
                case 18:
                    Tools.RotateCube(cube, 4, 283);
                    return Tools.YdPerm(Constants.F2LAlgs[283]);
                case 20:
                    Tools.RotateCube(cube, 4, 284);
                    return Tools.YdPerm(Constants.F2LAlgs[284]);
                case 42:
                    Tools.RotateCube(cube, 4, 285);
                    return Tools.YdPerm(Constants.F2LAlgs[285]);
                case 27:
                    Tools.RotateCube(cube, 4, 286);
                    return Tools.YdPerm(Constants.F2LAlgs[286]);
                case 29:
                    Tools.RotateCube(cube, 4, 275);
                    return Tools.YdPerm(Constants.F2LAlgs[275]);
                case 44:
                    Tools.RotateCube(cube, 4, 276);
                    return Tools.YdPerm(Constants.F2LAlgs[276]);
                case 0:
                    Tools.RotateCube(cube, 4, 277);
                    return Tools.YdPerm(Constants.F2LAlgs[277]);
                }
                break;
            case 10:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 4, 290);
                    return Tools.YdPerm(Constants.F2LAlgs[290]);
                case 15:
                    Tools.RotateCube(cube, 4, 291);
                    return Tools.YdPerm(Constants.F2LAlgs[291]);
                case 53:
                    Tools.RotateCube(cube, 4, 292);
                    return Tools.YdPerm(Constants.F2LAlgs[292]);
                case 17:
                    Tools.RotateCube(cube, 4, 293);
                    return Tools.YdPerm(Constants.F2LAlgs[293]);
                case 24:
                    Tools.RotateCube(cube, 4, 294);
                    return Tools.YdPerm(Constants.F2LAlgs[294]);
                case 51:
                    Tools.RotateCube(cube, 4, 295);
                    return Tools.YdPerm(Constants.F2LAlgs[295]);
                case 26:
                    Tools.RotateCube(cube, 4, 296);
                    return Tools.YdPerm(Constants.F2LAlgs[296]);
                case 33:
                    Tools.RotateCube(cube, 4, 297);
                    return Tools.YdPerm(Constants.F2LAlgs[297]);
                case 45:
                    Tools.RotateCube(cube, 4, 298);
                    return Tools.YdPerm(Constants.F2LAlgs[298]);
                case 35:
                    Tools.RotateCube(cube, 4, 287);
                    return Tools.YdPerm(Constants.F2LAlgs[287]);
                case 6:
                    Tools.RotateCube(cube, 4, 288);
                    return Tools.YdPerm(Constants.F2LAlgs[288]);
                case 47:
                    Tools.RotateCube(cube, 4, 289);
                    return Tools.YdPerm(Constants.F2LAlgs[289]);
                case 2:
                    Tools.RotateCube(cube, 4, 302);
                    return Tools.YdPerm(Constants.F2LAlgs[302]);
                case 38:
                    Tools.RotateCube(cube, 4, 303);
                    return Tools.YdPerm(Constants.F2LAlgs[303]);
                case 9:
                    Tools.RotateCube(cube, 4, 304);
                    return Tools.YdPerm(Constants.F2LAlgs[304]);
                case 11:
                    Tools.RotateCube(cube, 4, 305);
                    return Tools.YdPerm(Constants.F2LAlgs[305]);
                case 36:
                    Tools.RotateCube(cube, 4, 306);
                    return Tools.YdPerm(Constants.F2LAlgs[306]);
                case 18:
                    Tools.RotateCube(cube, 4, 307);
                    return Tools.YdPerm(Constants.F2LAlgs[307]);
                case 20:
                    Tools.RotateCube(cube, 4, 308);
                    return Tools.YdPerm(Constants.F2LAlgs[308]);
                case 42:
                    Tools.RotateCube(cube, 4, 309);
                    return Tools.YdPerm(Constants.F2LAlgs[309]);
                case 27:
                    Tools.RotateCube(cube, 4, 310);
                    return Tools.YdPerm(Constants.F2LAlgs[310]);
                case 29:
                    Tools.RotateCube(cube, 4, 299);
                    return Tools.YdPerm(Constants.F2LAlgs[299]);
                case 44:
                    Tools.RotateCube(cube, 4, 300);
                    return Tools.YdPerm(Constants.F2LAlgs[300]);
                case 0:
                    Tools.RotateCube(cube, 4, 301);
                    return Tools.YdPerm(Constants.F2LAlgs[301]);
                }
                break;
            case 37:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 4, 314);
                    return Tools.YdPerm(Constants.F2LAlgs[314]);
                case 15:
                    Tools.RotateCube(cube, 4, 315);
                    return Tools.YdPerm(Constants.F2LAlgs[315]);
                case 53:
                    Tools.RotateCube(cube, 4, 316);
                    return Tools.YdPerm(Constants.F2LAlgs[316]);
                case 17:
                    Tools.RotateCube(cube, 4, 317);
                    return Tools.YdPerm(Constants.F2LAlgs[317]);
                case 24:
                    Tools.RotateCube(cube, 4, 318);
                    return Tools.YdPerm(Constants.F2LAlgs[318]);
                case 51:
                    Tools.RotateCube(cube, 4, 319);
                    return Tools.YdPerm(Constants.F2LAlgs[319]);
                case 26:
                    Tools.RotateCube(cube, 4, 320);
                    return Tools.YdPerm(Constants.F2LAlgs[320]);
                case 33:
                    Tools.RotateCube(cube, 4, 321);
                    return Tools.YdPerm(Constants.F2LAlgs[321]);
                case 45:
                    Tools.RotateCube(cube, 4, 322);
                    return Tools.YdPerm(Constants.F2LAlgs[322]);
                case 35:
                    Tools.RotateCube(cube, 4, 311);
                    return Tools.YdPerm(Constants.F2LAlgs[311]);
                case 6:
                    Tools.RotateCube(cube, 4, 312);
                    return Tools.YdPerm(Constants.F2LAlgs[312]);
                case 47:
                    Tools.RotateCube(cube, 4, 313);
                    return Tools.YdPerm(Constants.F2LAlgs[313]);
                case 2:
                    Tools.RotateCube(cube, 4, 326);
                    return Tools.YdPerm(Constants.F2LAlgs[326]);
                case 38:
                    Tools.RotateCube(cube, 4, 327);
                    return Tools.YdPerm(Constants.F2LAlgs[327]);
                case 9:
                    Tools.RotateCube(cube, 4, 328);
                    return Tools.YdPerm(Constants.F2LAlgs[328]);
                case 11:
                    Tools.RotateCube(cube, 4, 329);
                    return Tools.YdPerm(Constants.F2LAlgs[329]);
                case 36:
                    Tools.RotateCube(cube, 4, 330);
                    return Tools.YdPerm(Constants.F2LAlgs[330]);
                case 18:
                    Tools.RotateCube(cube, 4, 331);
                    return Tools.YdPerm(Constants.F2LAlgs[331]);
                case 20:
                    Tools.RotateCube(cube, 4, 332);
                    return Tools.YdPerm(Constants.F2LAlgs[332]);
                case 42:
                    Tools.RotateCube(cube, 4, 333);
                    return Tools.YdPerm(Constants.F2LAlgs[333]);
                case 27:
                    Tools.RotateCube(cube, 4, 334);
                    return Tools.YdPerm(Constants.F2LAlgs[334]);
                case 29:
                    Tools.RotateCube(cube, 4, 323);
                    return Tools.YdPerm(Constants.F2LAlgs[323]);
                case 44:
                    Tools.RotateCube(cube, 4, 324);
                    return Tools.YdPerm(Constants.F2LAlgs[324]);
                case 0:
                    Tools.RotateCube(cube, 4, 325);
                    return Tools.YdPerm(Constants.F2LAlgs[325]);
                }
                break;
            case 19:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 4, 338);
                    return Tools.YdPerm(Constants.F2LAlgs[338]);
                case 15:
                    Tools.RotateCube(cube, 4, 339);
                    return Tools.YdPerm(Constants.F2LAlgs[339]);
                case 53:
                    Tools.RotateCube(cube, 4, 340);
                    return Tools.YdPerm(Constants.F2LAlgs[340]);
                case 17:
                    Tools.RotateCube(cube, 4, 341);
                    return Tools.YdPerm(Constants.F2LAlgs[341]);
                case 24:
                    Tools.RotateCube(cube, 4, 342);
                    return Tools.YdPerm(Constants.F2LAlgs[342]);
                case 51:
                    Tools.RotateCube(cube, 4, 343);
                    return Tools.YdPerm(Constants.F2LAlgs[343]);
                case 26:
                    Tools.RotateCube(cube, 4, 344);
                    return Tools.YdPerm(Constants.F2LAlgs[344]);
                case 33:
                    Tools.RotateCube(cube, 4, 345);
                    return Tools.YdPerm(Constants.F2LAlgs[345]);
                case 45:
                    Tools.RotateCube(cube, 4, 346);
                    return Tools.YdPerm(Constants.F2LAlgs[346]);
                case 35:
                    Tools.RotateCube(cube, 4, 335);
                    return Tools.YdPerm(Constants.F2LAlgs[335]);
                case 6:
                    Tools.RotateCube(cube, 4, 336);
                    return Tools.YdPerm(Constants.F2LAlgs[336]);
                case 47:
                    Tools.RotateCube(cube, 4, 337);
                    return Tools.YdPerm(Constants.F2LAlgs[337]);
                case 2:
                    Tools.RotateCube(cube, 4, 350);
                    return Tools.YdPerm(Constants.F2LAlgs[350]);
                case 38:
                    Tools.RotateCube(cube, 4, 351);
                    return Tools.YdPerm(Constants.F2LAlgs[351]);
                case 9:
                    Tools.RotateCube(cube, 4, 352);
                    return Tools.YdPerm(Constants.F2LAlgs[352]);
                case 11:
                    Tools.RotateCube(cube, 4, 353);
                    return Tools.YdPerm(Constants.F2LAlgs[353]);
                case 36:
                    Tools.RotateCube(cube, 4, 354);
                    return Tools.YdPerm(Constants.F2LAlgs[354]);
                case 18:
                    Tools.RotateCube(cube, 4, 355);
                    return Tools.YdPerm(Constants.F2LAlgs[355]);
                case 20:
                    Tools.RotateCube(cube, 4, 356);
                    return Tools.YdPerm(Constants.F2LAlgs[356]);
                case 42:
                    Tools.RotateCube(cube, 4, 357);
                    return Tools.YdPerm(Constants.F2LAlgs[357]);
                case 27:
                    Tools.RotateCube(cube, 4, 358);
                    return Tools.YdPerm(Constants.F2LAlgs[358]);
                case 29:
                    Tools.RotateCube(cube, 4, 347);
                    return Tools.YdPerm(Constants.F2LAlgs[347]);
                case 44:
                    Tools.RotateCube(cube, 4, 348);
                    return Tools.YdPerm(Constants.F2LAlgs[348]);
                case 0:
                    Tools.RotateCube(cube, 4, 349);
                    return Tools.YdPerm(Constants.F2LAlgs[349]);
                }
                break;
            case 39:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 4, 362);
                    return Tools.YdPerm(Constants.F2LAlgs[362]);
                case 15:
                    Tools.RotateCube(cube, 4, 363);
                    return Tools.YdPerm(Constants.F2LAlgs[363]);
                case 53:
                    Tools.RotateCube(cube, 4, 364);
                    return Tools.YdPerm(Constants.F2LAlgs[364]);
                case 17:
                    Tools.RotateCube(cube, 4, 365);
                    return Tools.YdPerm(Constants.F2LAlgs[365]);
                case 24:
                    Tools.RotateCube(cube, 4, 366);
                    return Tools.YdPerm(Constants.F2LAlgs[366]);
                case 51:
                    Tools.RotateCube(cube, 4, 367);
                    return Tools.YdPerm(Constants.F2LAlgs[367]);
                case 26:
                    Tools.RotateCube(cube, 4, 368);
                    return Tools.YdPerm(Constants.F2LAlgs[368]);
                case 33:
                    Tools.RotateCube(cube, 4, 369);
                    return Tools.YdPerm(Constants.F2LAlgs[369]);
                case 45:
                    Tools.RotateCube(cube, 4, 370);
                    return Tools.YdPerm(Constants.F2LAlgs[370]);
                case 35:
                    Tools.RotateCube(cube, 4, 359);
                    return Tools.YdPerm(Constants.F2LAlgs[359]);
                case 6:
                    Tools.RotateCube(cube, 4, 360);
                    return Tools.YdPerm(Constants.F2LAlgs[360]);
                case 47:
                    Tools.RotateCube(cube, 4, 361);
                    return Tools.YdPerm(Constants.F2LAlgs[361]);
                case 2:
                    Tools.RotateCube(cube, 4, 374);
                    return Tools.YdPerm(Constants.F2LAlgs[374]);
                case 38:
                    Tools.RotateCube(cube, 4, 375);
                    return Tools.YdPerm(Constants.F2LAlgs[375]);
                case 9:
                    Tools.RotateCube(cube, 4, 376);
                    return Tools.YdPerm(Constants.F2LAlgs[376]);
                case 11:
                    Tools.RotateCube(cube, 4, 377);
                    return Tools.YdPerm(Constants.F2LAlgs[377]);
                case 36:
                    Tools.RotateCube(cube, 4, 378);
                    return Tools.YdPerm(Constants.F2LAlgs[378]);
                case 18:
                    Tools.RotateCube(cube, 4, 379);
                    return Tools.YdPerm(Constants.F2LAlgs[379]);
                case 20:
                    Tools.RotateCube(cube, 4, 380);
                    return Tools.YdPerm(Constants.F2LAlgs[380]);
                case 42:
                    Tools.RotateCube(cube, 4, 381);
                    return Tools.YdPerm(Constants.F2LAlgs[381]);
                case 27:
                    Tools.RotateCube(cube, 4, 382);
                    return Tools.YdPerm(Constants.F2LAlgs[382]);
                case 29:
                    Tools.RotateCube(cube, 4, 371);
                    return Tools.YdPerm(Constants.F2LAlgs[371]);
                case 44:
                    Tools.RotateCube(cube, 4, 372);
                    return Tools.YdPerm(Constants.F2LAlgs[372]);
                case 0:
                    Tools.RotateCube(cube, 4, 373);
                    return Tools.YdPerm(Constants.F2LAlgs[373]);
                }
                break;
            case 28:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 4, 194);
                    return Tools.YdPerm(Constants.F2LAlgs[194]);
                case 15:
                    Tools.RotateCube(cube, 4, 195);
                    return Tools.YdPerm(Constants.F2LAlgs[195]);
                case 53:
                    Tools.RotateCube(cube, 4, 196);
                    return Tools.YdPerm(Constants.F2LAlgs[196]);
                case 17:
                    Tools.RotateCube(cube, 4, 197);
                    return Tools.YdPerm(Constants.F2LAlgs[197]);
                case 24:
                    Tools.RotateCube(cube, 4, 198);
                    return Tools.YdPerm(Constants.F2LAlgs[198]);
                case 51:
                    Tools.RotateCube(cube, 4, 199);
                    return Tools.YdPerm(Constants.F2LAlgs[199]);
                case 26:
                    Tools.RotateCube(cube, 4, 200);
                    return Tools.YdPerm(Constants.F2LAlgs[200]);
                case 33:
                    Tools.RotateCube(cube, 4, 201);
                    return Tools.YdPerm(Constants.F2LAlgs[201]);
                case 45:
                    Tools.RotateCube(cube, 4, 202);
                    return Tools.YdPerm(Constants.F2LAlgs[202]);
                case 35:
                    Tools.RotateCube(cube, 4, 191);
                    return Tools.YdPerm(Constants.F2LAlgs[191]);
                case 6:
                    Tools.RotateCube(cube, 4, 192);
                    return Tools.YdPerm(Constants.F2LAlgs[192]);
                case 47:
                    Tools.RotateCube(cube, 4, 193);
                    return Tools.YdPerm(Constants.F2LAlgs[193]);
                case 2:
                    Tools.RotateCube(cube, 4, 206);
                    return Tools.YdPerm(Constants.F2LAlgs[206]);
                case 38:
                    Tools.RotateCube(cube, 4, 207);
                    return Tools.YdPerm(Constants.F2LAlgs[207]);
                case 9:
                    Tools.RotateCube(cube, 4, 208);
                    return Tools.YdPerm(Constants.F2LAlgs[208]);
                case 11:
                    Tools.RotateCube(cube, 4, 209);
                    return Tools.YdPerm(Constants.F2LAlgs[209]);
                case 36:
                    Tools.RotateCube(cube, 4, 210);
                    return Tools.YdPerm(Constants.F2LAlgs[210]);
                case 18:
                    Tools.RotateCube(cube, 4, 211);
                    return Tools.YdPerm(Constants.F2LAlgs[211]);
                case 20:
                    Tools.RotateCube(cube, 4, 212);
                    return Tools.YdPerm(Constants.F2LAlgs[212]);
                case 42:
                    Tools.RotateCube(cube, 4, 213);
                    return Tools.YdPerm(Constants.F2LAlgs[213]);
                case 27:
                    Tools.RotateCube(cube, 4, 214);
                    return Tools.YdPerm(Constants.F2LAlgs[214]);
                case 29:
                    Tools.RotateCube(cube, 4, 203);
                    return Tools.YdPerm(Constants.F2LAlgs[203]);
                case 44:
                    Tools.RotateCube(cube, 4, 204);
                    return Tools.YdPerm(Constants.F2LAlgs[204]);
                case 0:
                    Tools.RotateCube(cube, 4, 205);
                    return Tools.YdPerm(Constants.F2LAlgs[205]);
                }
                break;
            case 43:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 4, 218);
                    return Tools.YdPerm(Constants.F2LAlgs[218]);
                case 15:
                    Tools.RotateCube(cube, 4, 219);
                    return Tools.YdPerm(Constants.F2LAlgs[219]);
                case 53:
                    Tools.RotateCube(cube, 4, 220);
                    return Tools.YdPerm(Constants.F2LAlgs[220]);
                case 17:
                    Tools.RotateCube(cube, 4, 221);
                    return Tools.YdPerm(Constants.F2LAlgs[221]);
                case 24:
                    Tools.RotateCube(cube, 4, 222);
                    return Tools.YdPerm(Constants.F2LAlgs[222]);
                case 51:
                    Tools.RotateCube(cube, 4, 223);
                    return Tools.YdPerm(Constants.F2LAlgs[223]);
                case 26:
                    Tools.RotateCube(cube, 4, 224);
                    return Tools.YdPerm(Constants.F2LAlgs[224]);
                case 33:
                    Tools.RotateCube(cube, 4, 225);
                    return Tools.YdPerm(Constants.F2LAlgs[225]);
                case 45:
                    Tools.RotateCube(cube, 4, 226);
                    return Tools.YdPerm(Constants.F2LAlgs[226]);
                case 35:
                    Tools.RotateCube(cube, 4, 215);
                    return Tools.YdPerm(Constants.F2LAlgs[215]);
                case 6:
                    Tools.RotateCube(cube, 4, 216);
                    return Tools.YdPerm(Constants.F2LAlgs[216]);
                case 47:
                    Tools.RotateCube(cube, 4, 217);
                    return Tools.YdPerm(Constants.F2LAlgs[217]);
                case 2:
                    Tools.RotateCube(cube, 4, 230);
                    return Tools.YdPerm(Constants.F2LAlgs[230]);
                case 38:
                    Tools.RotateCube(cube, 4, 231);
                    return Tools.YdPerm(Constants.F2LAlgs[231]);
                case 9:
                    Tools.RotateCube(cube, 4, 232);
                    return Tools.YdPerm(Constants.F2LAlgs[232]);
                case 11:
                    Tools.RotateCube(cube, 4, 233);
                    return Tools.YdPerm(Constants.F2LAlgs[233]);
                case 36:
                    Tools.RotateCube(cube, 4, 234);
                    return Tools.YdPerm(Constants.F2LAlgs[234]);
                case 18:
                    Tools.RotateCube(cube, 4, 235);
                    return Tools.YdPerm(Constants.F2LAlgs[235]);
                case 20:
                    Tools.RotateCube(cube, 4, 236);
                    return Tools.YdPerm(Constants.F2LAlgs[236]);
                case 42:
                    Tools.RotateCube(cube, 4, 237);
                    return Tools.YdPerm(Constants.F2LAlgs[237]);
                case 27:
                    Tools.RotateCube(cube, 4, 238);
                    return Tools.YdPerm(Constants.F2LAlgs[238]);
                case 29:
                    Tools.RotateCube(cube, 4, 227);
                    return Tools.YdPerm(Constants.F2LAlgs[227]);
                case 44:
                    Tools.RotateCube(cube, 4, 228);
                    return Tools.YdPerm(Constants.F2LAlgs[228]);
                case 0:
                    Tools.RotateCube(cube, 4, 229);
                    return Tools.YdPerm(Constants.F2LAlgs[229]);
                }
                break;
            }
            return string.Empty;
        }

        private static string F2L_BR(char[] cube){
            switch(ecc1){
            case 5:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 3, 101);
                    return Tools.Y2Perm(Constants.F2LAlgs[101]);
                case 15:
                    Tools.RotateCube(cube, 3, 102);
                    return Tools.Y2Perm(Constants.F2LAlgs[102]);
                case 53:
                    Tools.RotateCube(cube, 3, 103);
                    return Tools.Y2Perm(Constants.F2LAlgs[103]);
                case 17:
                    Tools.RotateCube(cube, 3, 104);
                    return Tools.Y2Perm(Constants.F2LAlgs[104]);
                case 24:
                    Tools.RotateCube(cube, 3, 105);
                    return Tools.Y2Perm(Constants.F2LAlgs[105]);
                case 51:
                    Tools.RotateCube(cube, 3, 106);
                    return Tools.Y2Perm(Constants.F2LAlgs[106]);
                case 26:
                    Tools.RotateCube(cube, 3, 95);
                    return Tools.Y2Perm(Constants.F2LAlgs[95]);
                case 33:
                    Tools.RotateCube(cube, 3, 96);
                    return Tools.Y2Perm(Constants.F2LAlgs[96]);
                case 45:
                    Tools.RotateCube(cube, 3, 97);
                    return Tools.Y2Perm(Constants.F2LAlgs[97]);
                case 35:
                    Tools.RotateCube(cube, 3, 98);
                    return Tools.Y2Perm(Constants.F2LAlgs[98]);
                case 6:
                    Tools.RotateCube(cube, 3, 99);
                    return Tools.Y2Perm(Constants.F2LAlgs[99]);
                case 47:
                    Tools.RotateCube(cube, 3, 100);
                    return Tools.Y2Perm(Constants.F2LAlgs[100]);
                case 2:
                    Tools.RotateCube(cube, 3, 113);
                    return Tools.Y2Perm(Constants.F2LAlgs[113]);
                case 38:
                    Tools.RotateCube(cube, 3, 114);
                    return Tools.Y2Perm(Constants.F2LAlgs[114]);
                case 9:
                    Tools.RotateCube(cube, 3, 115);
                    return Tools.Y2Perm(Constants.F2LAlgs[115]);
                case 11:
                    Tools.RotateCube(cube, 3, 116);
                    return Tools.Y2Perm(Constants.F2LAlgs[116]);
                case 36:
                    Tools.RotateCube(cube, 3, 117);
                    return Tools.Y2Perm(Constants.F2LAlgs[117]);
                case 18:
                    Tools.RotateCube(cube, 3, 118);
                    return Tools.Y2Perm(Constants.F2LAlgs[118]);
                case 20:
                    Tools.RotateCube(cube, 3, 107);
                    return Tools.Y2Perm(Constants.F2LAlgs[107]);
                case 42:
                    Tools.RotateCube(cube, 3, 108);
                    return Tools.Y2Perm(Constants.F2LAlgs[108]);
                case 27:
                    Tools.RotateCube(cube, 3, 109);
                    return Tools.Y2Perm(Constants.F2LAlgs[109]);
                case 29:
                    Tools.RotateCube(cube, 3, 110);
                    return Tools.Y2Perm(Constants.F2LAlgs[110]);
                case 44:
                    Tools.RotateCube(cube, 3, 111);
                    return Tools.Y2Perm(Constants.F2LAlgs[111]);
                case 0:
                    Tools.RotateCube(cube, 3, 112);
                    return Tools.Y2Perm(Constants.F2LAlgs[112]);
                }
                break;
            case 12:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 3, 125);
                    return Tools.Y2Perm(Constants.F2LAlgs[125]);
                case 15:
                    Tools.RotateCube(cube, 3, 126);
                    return Tools.Y2Perm(Constants.F2LAlgs[126]);
                case 53:
                    Tools.RotateCube(cube, 3, 127);
                    return Tools.Y2Perm(Constants.F2LAlgs[127]);
                case 17:
                    Tools.RotateCube(cube, 3, 128);
                    return Tools.Y2Perm(Constants.F2LAlgs[128]);
                case 24:
                    Tools.RotateCube(cube, 3, 129);
                    return Tools.Y2Perm(Constants.F2LAlgs[129]);
                case 51:
                    Tools.RotateCube(cube, 3, 130);
                    return Tools.Y2Perm(Constants.F2LAlgs[130]);
                case 26:
                    Tools.RotateCube(cube, 3, 119);
                    return Tools.Y2Perm(Constants.F2LAlgs[119]);
                case 33:
                    Tools.RotateCube(cube, 3, 120);
                    return Tools.Y2Perm(Constants.F2LAlgs[120]);
                case 45:
                    Tools.RotateCube(cube, 3, 121);
                    return Tools.Y2Perm(Constants.F2LAlgs[121]);
                case 35:
                    Tools.RotateCube(cube, 3, 122);
                    return Tools.Y2Perm(Constants.F2LAlgs[122]);
                case 6:
                    Tools.RotateCube(cube, 3, 123);
                    return Tools.Y2Perm(Constants.F2LAlgs[123]);
                case 47:
                    Tools.RotateCube(cube, 3, 124);
                    return Tools.Y2Perm(Constants.F2LAlgs[124]);
                case 2:
                    Tools.RotateCube(cube, 3, 137);
                    return Tools.Y2Perm(Constants.F2LAlgs[137]);
                case 38:
                    Tools.RotateCube(cube, 3, 138);
                    return Tools.Y2Perm(Constants.F2LAlgs[138]);
                case 9:
                    Tools.RotateCube(cube, 3, 139);
                    return Tools.Y2Perm(Constants.F2LAlgs[139]);
                case 11:
                    Tools.RotateCube(cube, 3, 140);
                    return Tools.Y2Perm(Constants.F2LAlgs[140]);
                case 36:
                    Tools.RotateCube(cube, 3, 141);
                    return Tools.Y2Perm(Constants.F2LAlgs[141]);
                case 18:
                    Tools.RotateCube(cube, 3, 142);
                    return Tools.Y2Perm(Constants.F2LAlgs[142]);
                case 20:
                    Tools.RotateCube(cube, 3, 131);
                    return Tools.Y2Perm(Constants.F2LAlgs[131]);
                case 42:
                    Tools.RotateCube(cube, 3, 132);
                    return Tools.Y2Perm(Constants.F2LAlgs[132]);
                case 27:
                    Tools.RotateCube(cube, 3, 133);
                    return Tools.Y2Perm(Constants.F2LAlgs[133]);
                case 29:
                    Tools.RotateCube(cube, 3, 134);
                    return Tools.Y2Perm(Constants.F2LAlgs[134]);
                case 44:
                    Tools.RotateCube(cube, 3, 135);
                    return Tools.Y2Perm(Constants.F2LAlgs[135]);
                case 0:
                    Tools.RotateCube(cube, 3, 136);
                    return Tools.Y2Perm(Constants.F2LAlgs[136]);
                }
                break;
            case 14:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 3, 149);
                    return Tools.Y2Perm(Constants.F2LAlgs[149]);
                case 15:
                    Tools.RotateCube(cube, 3, 150);
                    return Tools.Y2Perm(Constants.F2LAlgs[150]);
                case 53:
                    Tools.RotateCube(cube, 3, 151);
                    return Tools.Y2Perm(Constants.F2LAlgs[151]);
                case 17:
                    Tools.RotateCube(cube, 3, 152);
                    return Tools.Y2Perm(Constants.F2LAlgs[152]);
                case 24:
                    Tools.RotateCube(cube, 3, 153);
                    return Tools.Y2Perm(Constants.F2LAlgs[153]);
                case 51:
                    Tools.RotateCube(cube, 3, 154);
                    return Tools.Y2Perm(Constants.F2LAlgs[154]);
                case 26:
                    Tools.RotateCube(cube, 3, 143);
                    return Tools.Y2Perm(Constants.F2LAlgs[143]);
                case 33:
                    Tools.RotateCube(cube, 3, 144);
                    return Tools.Y2Perm(Constants.F2LAlgs[144]);
                case 45:
                    Tools.RotateCube(cube, 3, 145);
                    return Tools.Y2Perm(Constants.F2LAlgs[145]);
                case 35:
                    Tools.RotateCube(cube, 3, 146);
                    return Tools.Y2Perm(Constants.F2LAlgs[146]);
                case 6:
                    Tools.RotateCube(cube, 3, 147);
                    return Tools.Y2Perm(Constants.F2LAlgs[147]);
                case 47:
                    Tools.RotateCube(cube, 3, 148);
                    return Tools.Y2Perm(Constants.F2LAlgs[148]);
                case 2:
                    Tools.RotateCube(cube, 3, 161);
                    return Tools.Y2Perm(Constants.F2LAlgs[161]);
                case 38:
                    Tools.RotateCube(cube, 3, 162);
                    return Tools.Y2Perm(Constants.F2LAlgs[162]);
                case 9:
                    Tools.RotateCube(cube, 3, 163);
                    return Tools.Y2Perm(Constants.F2LAlgs[163]);
                case 11:
                    Tools.RotateCube(cube, 3, 164);
                    return Tools.Y2Perm(Constants.F2LAlgs[164]);
                case 36:
                    Tools.RotateCube(cube, 3, 165);
                    return Tools.Y2Perm(Constants.F2LAlgs[165]);
                case 18:
                    Tools.RotateCube(cube, 3, 166);
                    return Tools.Y2Perm(Constants.F2LAlgs[166]);
                case 20:
                    Tools.RotateCube(cube, 3, 155);
                    return Tools.Y2Perm(Constants.F2LAlgs[155]);
                case 42:
                    Tools.RotateCube(cube, 3, 156);
                    return Tools.Y2Perm(Constants.F2LAlgs[156]);
                case 27:
                    Tools.RotateCube(cube, 3, 157);
                    return Tools.Y2Perm(Constants.F2LAlgs[157]);
                case 29:
                    Tools.RotateCube(cube, 3, 158);
                    return Tools.Y2Perm(Constants.F2LAlgs[158]);
                case 44:
                    Tools.RotateCube(cube, 3, 159);
                    return Tools.Y2Perm(Constants.F2LAlgs[159]);
                case 0:
                    Tools.RotateCube(cube, 3, 160);
                    return Tools.Y2Perm(Constants.F2LAlgs[160]);
                }
                break;
            case 21:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 3, 173);
                    return Tools.Y2Perm(Constants.F2LAlgs[173]);
                case 15:
                    Tools.RotateCube(cube, 3, 174);
                    return Tools.Y2Perm(Constants.F2LAlgs[174]);
                case 53:
                    Tools.RotateCube(cube, 3, 175);
                    return Tools.Y2Perm(Constants.F2LAlgs[175]);
                case 17:
                    Tools.RotateCube(cube, 3, 176);
                    return Tools.Y2Perm(Constants.F2LAlgs[176]);
                case 24:
                    Tools.RotateCube(cube, 3, 177);
                    return Tools.Y2Perm(Constants.F2LAlgs[177]);
                case 51:
                    Tools.RotateCube(cube, 3, 178);
                    return Tools.Y2Perm(Constants.F2LAlgs[178]);
                case 26:
                    Tools.RotateCube(cube, 3, 167);
                    return Tools.Y2Perm(Constants.F2LAlgs[167]);
                case 33:
                    Tools.RotateCube(cube, 3, 168);
                    return Tools.Y2Perm(Constants.F2LAlgs[168]);
                case 45:
                    Tools.RotateCube(cube, 3, 169);
                    return Tools.Y2Perm(Constants.F2LAlgs[169]);
                case 35:
                    Tools.RotateCube(cube, 3, 170);
                    return Tools.Y2Perm(Constants.F2LAlgs[170]);
                case 6:
                    Tools.RotateCube(cube, 3, 171);
                    return Tools.Y2Perm(Constants.F2LAlgs[171]);
                case 47:
                    Tools.RotateCube(cube, 3, 172);
                    return Tools.Y2Perm(Constants.F2LAlgs[172]);
                case 2:
                    Tools.RotateCube(cube, 3, 185);
                    return Tools.Y2Perm(Constants.F2LAlgs[185]);
                case 38:
                    Tools.RotateCube(cube, 3, 186);
                    return Tools.Y2Perm(Constants.F2LAlgs[186]);
                case 9:
                    Tools.RotateCube(cube, 3, 187);
                    return Tools.Y2Perm(Constants.F2LAlgs[187]);
                case 11:
                    Tools.RotateCube(cube, 3, 188);
                    return Tools.Y2Perm(Constants.F2LAlgs[188]);
                case 36:
                    Tools.RotateCube(cube, 3, 189);
                    return Tools.Y2Perm(Constants.F2LAlgs[189]);
                case 18:
                    Tools.RotateCube(cube, 3, 190);
                    return Tools.Y2Perm(Constants.F2LAlgs[190]);
                case 20:
                    Tools.RotateCube(cube, 3, 179);
                    return Tools.Y2Perm(Constants.F2LAlgs[179]);
                case 42:
                    Tools.RotateCube(cube, 3, 180);
                    return Tools.Y2Perm(Constants.F2LAlgs[180]);
                case 27:
                    Tools.RotateCube(cube, 3, 181);
                    return Tools.Y2Perm(Constants.F2LAlgs[181]);
                case 29:
                    Tools.RotateCube(cube, 3, 182);
                    return Tools.Y2Perm(Constants.F2LAlgs[182]);
                case 44:
                    Tools.RotateCube(cube, 3, 183);
                    return Tools.Y2Perm(Constants.F2LAlgs[183]);
                case 0:
                    Tools.RotateCube(cube, 3, 184);
                    return Tools.Y2Perm(Constants.F2LAlgs[184]);
                }
                break;
            case 23:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 3, 5);
                    return Tools.Y2Perm(Constants.F2LAlgs[5]);
                case 15:
                    Tools.RotateCube(cube, 3, 6);
                    return Tools.Y2Perm(Constants.F2LAlgs[6]);
                case 53:
                    Tools.RotateCube(cube, 3, 7);
                    return Tools.Y2Perm(Constants.F2LAlgs[7]);
                case 17:
                    Tools.RotateCube(cube, 3, 8);
                    return Tools.Y2Perm(Constants.F2LAlgs[8]);
                case 24:
                    Tools.RotateCube(cube, 3, 9);
                    return Tools.Y2Perm(Constants.F2LAlgs[9]);
                case 51:
                    Tools.RotateCube(cube, 3, 10);
                    return Tools.Y2Perm(Constants.F2LAlgs[10]);
                case 33:
                    Tools.RotateCube(cube, 3, 0);
                    return Tools.Y2Perm(Constants.F2LAlgs[0]);
                case 45:
                    Tools.RotateCube(cube, 3, 1);
                    return Tools.Y2Perm(Constants.F2LAlgs[1]);
                case 35:
                    Tools.RotateCube(cube, 3, 2);
                    return Tools.Y2Perm(Constants.F2LAlgs[2]);
                case 6:
                    Tools.RotateCube(cube, 3, 3);
                    return Tools.Y2Perm(Constants.F2LAlgs[3]);
                case 47:
                    Tools.RotateCube(cube, 3, 4);
                    return Tools.Y2Perm(Constants.F2LAlgs[4]);
                case 2:
                    Tools.RotateCube(cube, 3, 17);
                    return Tools.Y2Perm(Constants.F2LAlgs[17]);
                case 38:
                    Tools.RotateCube(cube, 3, 18);
                    return Tools.Y2Perm(Constants.F2LAlgs[18]);
                case 9:
                    Tools.RotateCube(cube, 3, 19);
                    return Tools.Y2Perm(Constants.F2LAlgs[19]);
                case 11:
                    Tools.RotateCube(cube, 3, 20);
                    return Tools.Y2Perm(Constants.F2LAlgs[20]);
                case 36:
                    Tools.RotateCube(cube, 3, 21);
                    return Tools.Y2Perm(Constants.F2LAlgs[21]);
                case 18:
                    Tools.RotateCube(cube, 3, 22);
                    return Tools.Y2Perm(Constants.F2LAlgs[22]);
                case 20:
                    Tools.RotateCube(cube, 3, 11);
                    return Tools.Y2Perm(Constants.F2LAlgs[11]);
                case 42:
                    Tools.RotateCube(cube, 3, 12);
                    return Tools.Y2Perm(Constants.F2LAlgs[12]);
                case 27:
                    Tools.RotateCube(cube, 3, 13);
                    return Tools.Y2Perm(Constants.F2LAlgs[13]);
                case 29:
                    Tools.RotateCube(cube, 3, 14);
                    return Tools.Y2Perm(Constants.F2LAlgs[14]);
                case 44:
                    Tools.RotateCube(cube, 3, 15);
                    return Tools.Y2Perm(Constants.F2LAlgs[15]);
                case 0:
                    Tools.RotateCube(cube, 3, 16);
                    return Tools.Y2Perm(Constants.F2LAlgs[16]);
                }
                break;
            case 30:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 3, 29);
                    return Tools.Y2Perm(Constants.F2LAlgs[29]);
                case 15:
                    Tools.RotateCube(cube, 3, 30);
                    return Tools.Y2Perm(Constants.F2LAlgs[30]);
                case 53:
                    Tools.RotateCube(cube, 3, 31);
                    return Tools.Y2Perm(Constants.F2LAlgs[31]);
                case 17:
                    Tools.RotateCube(cube, 3, 32);
                    return Tools.Y2Perm(Constants.F2LAlgs[32]);
                case 24:
                    Tools.RotateCube(cube, 3, 33);
                    return Tools.Y2Perm(Constants.F2LAlgs[33]);
                case 51:
                    Tools.RotateCube(cube, 3, 34);
                    return Tools.Y2Perm(Constants.F2LAlgs[34]);
                case 26:
                    Tools.RotateCube(cube, 3, 23);
                    return Tools.Y2Perm(Constants.F2LAlgs[23]);
                case 33:
                    Tools.RotateCube(cube, 3, 24);
                    return Tools.Y2Perm(Constants.F2LAlgs[24]);
                case 45:
                    Tools.RotateCube(cube, 3, 25);
                    return Tools.Y2Perm(Constants.F2LAlgs[25]);
                case 35:
                    Tools.RotateCube(cube, 3, 26);
                    return Tools.Y2Perm(Constants.F2LAlgs[26]);
                case 6:
                    Tools.RotateCube(cube, 3, 27);
                    return Tools.Y2Perm(Constants.F2LAlgs[27]);
                case 47:
                    Tools.RotateCube(cube, 3, 28);
                    return Tools.Y2Perm(Constants.F2LAlgs[28]);
                case 2:
                    Tools.RotateCube(cube, 3, 41);
                    return Tools.Y2Perm(Constants.F2LAlgs[41]);
                case 38:
                    Tools.RotateCube(cube, 3, 42);
                    return Tools.Y2Perm(Constants.F2LAlgs[42]);
                case 9:
                    Tools.RotateCube(cube, 3, 43);
                    return Tools.Y2Perm(Constants.F2LAlgs[43]);
                case 11:
                    Tools.RotateCube(cube, 3, 44);
                    return Tools.Y2Perm(Constants.F2LAlgs[44]);
                case 36:
                    Tools.RotateCube(cube, 3, 45);
                    return Tools.Y2Perm(Constants.F2LAlgs[45]);
                case 18:
                    Tools.RotateCube(cube, 3, 46);
                    return Tools.Y2Perm(Constants.F2LAlgs[46]);
                case 20:
                    Tools.RotateCube(cube, 3, 35);
                    return Tools.Y2Perm(Constants.F2LAlgs[35]);
                case 42:
                    Tools.RotateCube(cube, 3, 36);
                    return Tools.Y2Perm(Constants.F2LAlgs[36]);
                case 27:
                    Tools.RotateCube(cube, 3, 37);
                    return Tools.Y2Perm(Constants.F2LAlgs[37]);
                case 29:
                    Tools.RotateCube(cube, 3, 38);
                    return Tools.Y2Perm(Constants.F2LAlgs[38]);
                case 44:
                    Tools.RotateCube(cube, 3, 39);
                    return Tools.Y2Perm(Constants.F2LAlgs[39]);
                case 0:
                    Tools.RotateCube(cube, 3, 40);
                    return Tools.Y2Perm(Constants.F2LAlgs[40]);
                }
                break;
            case 32:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 3, 53);
                    return Tools.Y2Perm(Constants.F2LAlgs[53]);
                case 15:
                    Tools.RotateCube(cube, 3, 54);
                    return Tools.Y2Perm(Constants.F2LAlgs[54]);
                case 53:
                    Tools.RotateCube(cube, 3, 55);
                    return Tools.Y2Perm(Constants.F2LAlgs[55]);
                case 17:
                    Tools.RotateCube(cube, 3, 56);
                    return Tools.Y2Perm(Constants.F2LAlgs[56]);
                case 24:
                    Tools.RotateCube(cube, 3, 57);
                    return Tools.Y2Perm(Constants.F2LAlgs[57]);
                case 51:
                    Tools.RotateCube(cube, 3, 58);
                    return Tools.Y2Perm(Constants.F2LAlgs[58]);
                case 26:
                    Tools.RotateCube(cube, 3, 47);
                    return Tools.Y2Perm(Constants.F2LAlgs[47]);
                case 33:
                    Tools.RotateCube(cube, 3, 48);
                    return Tools.Y2Perm(Constants.F2LAlgs[48]);
                case 45:
                    Tools.RotateCube(cube, 3, 49);
                    return Tools.Y2Perm(Constants.F2LAlgs[49]);
                case 35:
                    Tools.RotateCube(cube, 3, 50);
                    return Tools.Y2Perm(Constants.F2LAlgs[50]);
                case 6:
                    Tools.RotateCube(cube, 3, 51);
                    return Tools.Y2Perm(Constants.F2LAlgs[51]);
                case 47:
                    Tools.RotateCube(cube, 3, 52);
                    return Tools.Y2Perm(Constants.F2LAlgs[52]);
                case 2:
                    Tools.RotateCube(cube, 3, 65);
                    return Tools.Y2Perm(Constants.F2LAlgs[65]);
                case 38:
                    Tools.RotateCube(cube, 3, 66);
                    return Tools.Y2Perm(Constants.F2LAlgs[66]);
                case 9:
                    Tools.RotateCube(cube, 3, 67);
                    return Tools.Y2Perm(Constants.F2LAlgs[67]);
                case 11:
                    Tools.RotateCube(cube, 3, 68);
                    return Tools.Y2Perm(Constants.F2LAlgs[68]);
                case 36:
                    Tools.RotateCube(cube, 3, 69);
                    return Tools.Y2Perm(Constants.F2LAlgs[69]);
                case 18:
                    Tools.RotateCube(cube, 3, 70);
                    return Tools.Y2Perm(Constants.F2LAlgs[70]);
                case 20:
                    Tools.RotateCube(cube, 3, 59);
                    return Tools.Y2Perm(Constants.F2LAlgs[59]);
                case 42:
                    Tools.RotateCube(cube, 3, 60);
                    return Tools.Y2Perm(Constants.F2LAlgs[60]);
                case 27:
                    Tools.RotateCube(cube, 3, 61);
                    return Tools.Y2Perm(Constants.F2LAlgs[61]);
                case 29:
                    Tools.RotateCube(cube, 3, 62);
                    return Tools.Y2Perm(Constants.F2LAlgs[62]);
                case 44:
                    Tools.RotateCube(cube, 3, 63);
                    return Tools.Y2Perm(Constants.F2LAlgs[63]);
                case 0:
                    Tools.RotateCube(cube, 3, 64);
                    return Tools.Y2Perm(Constants.F2LAlgs[64]);
                }
                break;
            case 3:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 3, 77);
                    return Tools.Y2Perm(Constants.F2LAlgs[77]);
                case 15:
                    Tools.RotateCube(cube, 3, 78);
                    return Tools.Y2Perm(Constants.F2LAlgs[78]);
                case 53:
                    Tools.RotateCube(cube, 3, 79);
                    return Tools.Y2Perm(Constants.F2LAlgs[79]);
                case 17:
                    Tools.RotateCube(cube, 3, 80);
                    return Tools.Y2Perm(Constants.F2LAlgs[80]);
                case 24:
                    Tools.RotateCube(cube, 3, 81);
                    return Tools.Y2Perm(Constants.F2LAlgs[81]);
                case 51:
                    Tools.RotateCube(cube, 3, 82);
                    return Tools.Y2Perm(Constants.F2LAlgs[82]);
                case 26:
                    Tools.RotateCube(cube, 3, 71);
                    return Tools.Y2Perm(Constants.F2LAlgs[71]);
                case 33:
                    Tools.RotateCube(cube, 3, 72);
                    return Tools.Y2Perm(Constants.F2LAlgs[72]);
                case 45:
                    Tools.RotateCube(cube, 3, 73);
                    return Tools.Y2Perm(Constants.F2LAlgs[73]);
                case 35:
                    Tools.RotateCube(cube, 3, 74);
                    return Tools.Y2Perm(Constants.F2LAlgs[74]);
                case 6:
                    Tools.RotateCube(cube, 3, 75);
                    return Tools.Y2Perm(Constants.F2LAlgs[75]);
                case 47:
                    Tools.RotateCube(cube, 3, 76);
                    return Tools.Y2Perm(Constants.F2LAlgs[76]);
                case 2:
                    Tools.RotateCube(cube, 3, 89);
                    return Tools.Y2Perm(Constants.F2LAlgs[89]);
                case 38:
                    Tools.RotateCube(cube, 3, 90);
                    return Tools.Y2Perm(Constants.F2LAlgs[90]);
                case 9:
                    Tools.RotateCube(cube, 3, 91);
                    return Tools.Y2Perm(Constants.F2LAlgs[91]);
                case 11:
                    Tools.RotateCube(cube, 3, 92);
                    return Tools.Y2Perm(Constants.F2LAlgs[92]);
                case 36:
                    Tools.RotateCube(cube, 3, 93);
                    return Tools.Y2Perm(Constants.F2LAlgs[93]);
                case 18:
                    Tools.RotateCube(cube, 3, 94);
                    return Tools.Y2Perm(Constants.F2LAlgs[94]);
                case 20:
                    Tools.RotateCube(cube, 3, 83);
                    return Tools.Y2Perm(Constants.F2LAlgs[83]);
                case 42:
                    Tools.RotateCube(cube, 3, 84);
                    return Tools.Y2Perm(Constants.F2LAlgs[84]);
                case 27:
                    Tools.RotateCube(cube, 3, 85);
                    return Tools.Y2Perm(Constants.F2LAlgs[85]);
                case 29:
                    Tools.RotateCube(cube, 3, 86);
                    return Tools.Y2Perm(Constants.F2LAlgs[86]);
                case 44:
                    Tools.RotateCube(cube, 3, 87);
                    return Tools.Y2Perm(Constants.F2LAlgs[87]);
                case 0:
                    Tools.RotateCube(cube, 3, 88);
                    return Tools.Y2Perm(Constants.F2LAlgs[88]);
                }
                break;
            case 1:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 3, 293);
                    return Tools.Y2Perm(Constants.F2LAlgs[293]);
                case 15:
                    Tools.RotateCube(cube, 3, 294);
                    return Tools.Y2Perm(Constants.F2LAlgs[294]);
                case 53:
                    Tools.RotateCube(cube, 3, 295);
                    return Tools.Y2Perm(Constants.F2LAlgs[295]);
                case 17:
                    Tools.RotateCube(cube, 3, 296);
                    return Tools.Y2Perm(Constants.F2LAlgs[296]);
                case 24:
                    Tools.RotateCube(cube, 3, 297);
                    return Tools.Y2Perm(Constants.F2LAlgs[297]);
                case 51:
                    Tools.RotateCube(cube, 3, 298);
                    return Tools.Y2Perm(Constants.F2LAlgs[298]);
                case 26:
                    Tools.RotateCube(cube, 3, 287);
                    return Tools.Y2Perm(Constants.F2LAlgs[287]);
                case 33:
                    Tools.RotateCube(cube, 3, 288);
                    return Tools.Y2Perm(Constants.F2LAlgs[288]);
                case 45:
                    Tools.RotateCube(cube, 3, 289);
                    return Tools.Y2Perm(Constants.F2LAlgs[289]);
                case 35:
                    Tools.RotateCube(cube, 3, 290);
                    return Tools.Y2Perm(Constants.F2LAlgs[290]);
                case 6:
                    Tools.RotateCube(cube, 3, 291);
                    return Tools.Y2Perm(Constants.F2LAlgs[291]);
                case 47:
                    Tools.RotateCube(cube, 3, 292);
                    return Tools.Y2Perm(Constants.F2LAlgs[292]);
                case 2:
                    Tools.RotateCube(cube, 3, 305);
                    return Tools.Y2Perm(Constants.F2LAlgs[305]);
                case 38:
                    Tools.RotateCube(cube, 3, 306);
                    return Tools.Y2Perm(Constants.F2LAlgs[306]);
                case 9:
                    Tools.RotateCube(cube, 3, 307);
                    return Tools.Y2Perm(Constants.F2LAlgs[307]);
                case 11:
                    Tools.RotateCube(cube, 3, 308);
                    return Tools.Y2Perm(Constants.F2LAlgs[308]);
                case 36:
                    Tools.RotateCube(cube, 3, 309);
                    return Tools.Y2Perm(Constants.F2LAlgs[309]);
                case 18:
                    Tools.RotateCube(cube, 3, 310);
                    return Tools.Y2Perm(Constants.F2LAlgs[310]);
                case 20:
                    Tools.RotateCube(cube, 3, 299);
                    return Tools.Y2Perm(Constants.F2LAlgs[299]);
                case 42:
                    Tools.RotateCube(cube, 3, 300);
                    return Tools.Y2Perm(Constants.F2LAlgs[300]);
                case 27:
                    Tools.RotateCube(cube, 3, 301);
                    return Tools.Y2Perm(Constants.F2LAlgs[301]);
                case 29:
                    Tools.RotateCube(cube, 3, 302);
                    return Tools.Y2Perm(Constants.F2LAlgs[302]);
                case 44:
                    Tools.RotateCube(cube, 3, 303);
                    return Tools.Y2Perm(Constants.F2LAlgs[303]);
                case 0:
                    Tools.RotateCube(cube, 3, 304);
                    return Tools.Y2Perm(Constants.F2LAlgs[304]);
                }
                break;
            case 41:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 3, 317);
                    return Tools.Y2Perm(Constants.F2LAlgs[317]);
                case 15:
                    Tools.RotateCube(cube, 3, 318);
                    return Tools.Y2Perm(Constants.F2LAlgs[318]);
                case 53:
                    Tools.RotateCube(cube, 3, 319);
                    return Tools.Y2Perm(Constants.F2LAlgs[319]);
                case 17:
                    Tools.RotateCube(cube, 3, 320);
                    return Tools.Y2Perm(Constants.F2LAlgs[320]);
                case 24:
                    Tools.RotateCube(cube, 3, 321);
                    return Tools.Y2Perm(Constants.F2LAlgs[321]);
                case 51:
                    Tools.RotateCube(cube, 3, 322);
                    return Tools.Y2Perm(Constants.F2LAlgs[322]);
                case 26:
                    Tools.RotateCube(cube, 3, 311);
                    return Tools.Y2Perm(Constants.F2LAlgs[311]);
                case 33:
                    Tools.RotateCube(cube, 3, 312);
                    return Tools.Y2Perm(Constants.F2LAlgs[312]);
                case 45:
                    Tools.RotateCube(cube, 3, 313);
                    return Tools.Y2Perm(Constants.F2LAlgs[313]);
                case 35:
                    Tools.RotateCube(cube, 3, 314);
                    return Tools.Y2Perm(Constants.F2LAlgs[314]);
                case 6:
                    Tools.RotateCube(cube, 3, 315);
                    return Tools.Y2Perm(Constants.F2LAlgs[315]);
                case 47:
                    Tools.RotateCube(cube, 3, 316);
                    return Tools.Y2Perm(Constants.F2LAlgs[316]);
                case 2:
                    Tools.RotateCube(cube, 3, 329);
                    return Tools.Y2Perm(Constants.F2LAlgs[329]);
                case 38:
                    Tools.RotateCube(cube, 3, 330);
                    return Tools.Y2Perm(Constants.F2LAlgs[330]);
                case 9:
                    Tools.RotateCube(cube, 3, 331);
                    return Tools.Y2Perm(Constants.F2LAlgs[331]);
                case 11:
                    Tools.RotateCube(cube, 3, 332);
                    return Tools.Y2Perm(Constants.F2LAlgs[332]);
                case 36:
                    Tools.RotateCube(cube, 3, 333);
                    return Tools.Y2Perm(Constants.F2LAlgs[333]);
                case 18:
                    Tools.RotateCube(cube, 3, 334);
                    return Tools.Y2Perm(Constants.F2LAlgs[334]);
                case 20:
                    Tools.RotateCube(cube, 3, 323);
                    return Tools.Y2Perm(Constants.F2LAlgs[323]);
                case 42:
                    Tools.RotateCube(cube, 3, 324);
                    return Tools.Y2Perm(Constants.F2LAlgs[324]);
                case 27:
                    Tools.RotateCube(cube, 3, 325);
                    return Tools.Y2Perm(Constants.F2LAlgs[325]);
                case 29:
                    Tools.RotateCube(cube, 3, 326);
                    return Tools.Y2Perm(Constants.F2LAlgs[326]);
                case 44:
                    Tools.RotateCube(cube, 3, 327);
                    return Tools.Y2Perm(Constants.F2LAlgs[327]);
                case 0:
                    Tools.RotateCube(cube, 3, 328);
                    return Tools.Y2Perm(Constants.F2LAlgs[328]);
                }
                break;
            case 10:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 3, 341);
                    return Tools.Y2Perm(Constants.F2LAlgs[341]);
                case 15:
                    Tools.RotateCube(cube, 3, 342);
                    return Tools.Y2Perm(Constants.F2LAlgs[342]);
                case 53:
                    Tools.RotateCube(cube, 3, 343);
                    return Tools.Y2Perm(Constants.F2LAlgs[343]);
                case 17:
                    Tools.RotateCube(cube, 3, 344);
                    return Tools.Y2Perm(Constants.F2LAlgs[344]);
                case 24:
                    Tools.RotateCube(cube, 3, 345);
                    return Tools.Y2Perm(Constants.F2LAlgs[345]);
                case 51:
                    Tools.RotateCube(cube, 3, 346);
                    return Tools.Y2Perm(Constants.F2LAlgs[346]);
                case 26:
                    Tools.RotateCube(cube, 3, 335);
                    return Tools.Y2Perm(Constants.F2LAlgs[335]);
                case 33:
                    Tools.RotateCube(cube, 3, 336);
                    return Tools.Y2Perm(Constants.F2LAlgs[336]);
                case 45:
                    Tools.RotateCube(cube, 3, 337);
                    return Tools.Y2Perm(Constants.F2LAlgs[337]);
                case 35:
                    Tools.RotateCube(cube, 3, 338);
                    return Tools.Y2Perm(Constants.F2LAlgs[338]);
                case 6:
                    Tools.RotateCube(cube, 3, 339);
                    return Tools.Y2Perm(Constants.F2LAlgs[339]);
                case 47:
                    Tools.RotateCube(cube, 3, 340);
                    return Tools.Y2Perm(Constants.F2LAlgs[340]);
                case 2:
                    Tools.RotateCube(cube, 3, 353);
                    return Tools.Y2Perm(Constants.F2LAlgs[353]);
                case 38:
                    Tools.RotateCube(cube, 3, 354);
                    return Tools.Y2Perm(Constants.F2LAlgs[354]);
                case 9:
                    Tools.RotateCube(cube, 3, 355);
                    return Tools.Y2Perm(Constants.F2LAlgs[355]);
                case 11:
                    Tools.RotateCube(cube, 3, 356);
                    return Tools.Y2Perm(Constants.F2LAlgs[356]);
                case 36:
                    Tools.RotateCube(cube, 3, 357);
                    return Tools.Y2Perm(Constants.F2LAlgs[357]);
                case 18:
                    Tools.RotateCube(cube, 3, 358);
                    return Tools.Y2Perm(Constants.F2LAlgs[358]);
                case 20:
                    Tools.RotateCube(cube, 3, 347);
                    return Tools.Y2Perm(Constants.F2LAlgs[347]);
                case 42:
                    Tools.RotateCube(cube, 3, 348);
                    return Tools.Y2Perm(Constants.F2LAlgs[348]);
                case 27:
                    Tools.RotateCube(cube, 3, 349);
                    return Tools.Y2Perm(Constants.F2LAlgs[349]);
                case 29:
                    Tools.RotateCube(cube, 3, 350);
                    return Tools.Y2Perm(Constants.F2LAlgs[350]);
                case 44:
                    Tools.RotateCube(cube, 3, 351);
                    return Tools.Y2Perm(Constants.F2LAlgs[351]);
                case 0:
                    Tools.RotateCube(cube, 3, 352);
                    return Tools.Y2Perm(Constants.F2LAlgs[352]);
                }
                break;
            case 37:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 3, 365);
                    return Tools.Y2Perm(Constants.F2LAlgs[365]);
                case 15:
                    Tools.RotateCube(cube, 3, 366);
                    return Tools.Y2Perm(Constants.F2LAlgs[366]);
                case 53:
                    Tools.RotateCube(cube, 3, 367);
                    return Tools.Y2Perm(Constants.F2LAlgs[367]);
                case 17:
                    Tools.RotateCube(cube, 3, 368);
                    return Tools.Y2Perm(Constants.F2LAlgs[368]);
                case 24:
                    Tools.RotateCube(cube, 3, 369);
                    return Tools.Y2Perm(Constants.F2LAlgs[369]);
                case 51:
                    Tools.RotateCube(cube, 3, 370);
                    return Tools.Y2Perm(Constants.F2LAlgs[370]);
                case 26:
                    Tools.RotateCube(cube, 3, 359);
                    return Tools.Y2Perm(Constants.F2LAlgs[359]);
                case 33:
                    Tools.RotateCube(cube, 3, 360);
                    return Tools.Y2Perm(Constants.F2LAlgs[360]);
                case 45:
                    Tools.RotateCube(cube, 3, 361);
                    return Tools.Y2Perm(Constants.F2LAlgs[361]);
                case 35:
                    Tools.RotateCube(cube, 3, 362);
                    return Tools.Y2Perm(Constants.F2LAlgs[362]);
                case 6:
                    Tools.RotateCube(cube, 3, 363);
                    return Tools.Y2Perm(Constants.F2LAlgs[363]);
                case 47:
                    Tools.RotateCube(cube, 3, 364);
                    return Tools.Y2Perm(Constants.F2LAlgs[364]);
                case 2:
                    Tools.RotateCube(cube, 3, 377);
                    return Tools.Y2Perm(Constants.F2LAlgs[377]);
                case 38:
                    Tools.RotateCube(cube, 3, 378);
                    return Tools.Y2Perm(Constants.F2LAlgs[378]);
                case 9:
                    Tools.RotateCube(cube, 3, 379);
                    return Tools.Y2Perm(Constants.F2LAlgs[379]);
                case 11:
                    Tools.RotateCube(cube, 3, 380);
                    return Tools.Y2Perm(Constants.F2LAlgs[380]);
                case 36:
                    Tools.RotateCube(cube, 3, 381);
                    return Tools.Y2Perm(Constants.F2LAlgs[381]);
                case 18:
                    Tools.RotateCube(cube, 3, 382);
                    return Tools.Y2Perm(Constants.F2LAlgs[382]);
                case 20:
                    Tools.RotateCube(cube, 3, 371);
                    return Tools.Y2Perm(Constants.F2LAlgs[371]);
                case 42:
                    Tools.RotateCube(cube, 3, 372);
                    return Tools.Y2Perm(Constants.F2LAlgs[372]);
                case 27:
                    Tools.RotateCube(cube, 3, 373);
                    return Tools.Y2Perm(Constants.F2LAlgs[373]);
                case 29:
                    Tools.RotateCube(cube, 3, 374);
                    return Tools.Y2Perm(Constants.F2LAlgs[374]);
                case 44:
                    Tools.RotateCube(cube, 3, 375);
                    return Tools.Y2Perm(Constants.F2LAlgs[375]);
                case 0:
                    Tools.RotateCube(cube, 3, 376);
                    return Tools.Y2Perm(Constants.F2LAlgs[376]);
                }
                break;
            case 19:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 3, 197);
                    return Tools.Y2Perm(Constants.F2LAlgs[197]);
                case 15:
                    Tools.RotateCube(cube, 3, 198);
                    return Tools.Y2Perm(Constants.F2LAlgs[198]);
                case 53:
                    Tools.RotateCube(cube, 3, 199);
                    return Tools.Y2Perm(Constants.F2LAlgs[199]);
                case 17:
                    Tools.RotateCube(cube, 3, 200);
                    return Tools.Y2Perm(Constants.F2LAlgs[200]);
                case 24:
                    Tools.RotateCube(cube, 3, 201);
                    return Tools.Y2Perm(Constants.F2LAlgs[201]);
                case 51:
                    Tools.RotateCube(cube, 3, 202);
                    return Tools.Y2Perm(Constants.F2LAlgs[202]);
                case 26:
                    Tools.RotateCube(cube, 3, 191);
                    return Tools.Y2Perm(Constants.F2LAlgs[191]);
                case 33:
                    Tools.RotateCube(cube, 3, 192);
                    return Tools.Y2Perm(Constants.F2LAlgs[192]);
                case 45:
                    Tools.RotateCube(cube, 3, 193);
                    return Tools.Y2Perm(Constants.F2LAlgs[193]);
                case 35:
                    Tools.RotateCube(cube, 3, 194);
                    return Tools.Y2Perm(Constants.F2LAlgs[194]);
                case 6:
                    Tools.RotateCube(cube, 3, 195);
                    return Tools.Y2Perm(Constants.F2LAlgs[195]);
                case 47:
                    Tools.RotateCube(cube, 3, 196);
                    return Tools.Y2Perm(Constants.F2LAlgs[196]);
                case 2:
                    Tools.RotateCube(cube, 3, 209);
                    return Tools.Y2Perm(Constants.F2LAlgs[209]);
                case 38:
                    Tools.RotateCube(cube, 3, 210);
                    return Tools.Y2Perm(Constants.F2LAlgs[210]);
                case 9:
                    Tools.RotateCube(cube, 3, 211);
                    return Tools.Y2Perm(Constants.F2LAlgs[211]);
                case 11:
                    Tools.RotateCube(cube, 3, 212);
                    return Tools.Y2Perm(Constants.F2LAlgs[212]);
                case 36:
                    Tools.RotateCube(cube, 3, 213);
                    return Tools.Y2Perm(Constants.F2LAlgs[213]);
                case 18:
                    Tools.RotateCube(cube, 3, 214);
                    return Tools.Y2Perm(Constants.F2LAlgs[214]);
                case 20:
                    Tools.RotateCube(cube, 3, 203);
                    return Tools.Y2Perm(Constants.F2LAlgs[203]);
                case 42:
                    Tools.RotateCube(cube, 3, 204);
                    return Tools.Y2Perm(Constants.F2LAlgs[204]);
                case 27:
                    Tools.RotateCube(cube, 3, 205);
                    return Tools.Y2Perm(Constants.F2LAlgs[205]);
                case 29:
                    Tools.RotateCube(cube, 3, 206);
                    return Tools.Y2Perm(Constants.F2LAlgs[206]);
                case 44:
                    Tools.RotateCube(cube, 3, 207);
                    return Tools.Y2Perm(Constants.F2LAlgs[207]);
                case 0:
                    Tools.RotateCube(cube, 3, 208);
                    return Tools.Y2Perm(Constants.F2LAlgs[208]);
                }
                break;
            case 39:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 3, 221);
                    return Tools.Y2Perm(Constants.F2LAlgs[221]);
                case 15:
                    Tools.RotateCube(cube, 3, 222);
                    return Tools.Y2Perm(Constants.F2LAlgs[222]);
                case 53:
                    Tools.RotateCube(cube, 3, 223);
                    return Tools.Y2Perm(Constants.F2LAlgs[223]);
                case 17:
                    Tools.RotateCube(cube, 3, 224);
                    return Tools.Y2Perm(Constants.F2LAlgs[224]);
                case 24:
                    Tools.RotateCube(cube, 3, 225);
                    return Tools.Y2Perm(Constants.F2LAlgs[225]);
                case 51:
                    Tools.RotateCube(cube, 3, 226);
                    return Tools.Y2Perm(Constants.F2LAlgs[226]);
                case 26:
                    Tools.RotateCube(cube, 3, 215);
                    return Tools.Y2Perm(Constants.F2LAlgs[215]);
                case 33:
                    Tools.RotateCube(cube, 3, 216);
                    return Tools.Y2Perm(Constants.F2LAlgs[216]);
                case 45:
                    Tools.RotateCube(cube, 3, 217);
                    return Tools.Y2Perm(Constants.F2LAlgs[217]);
                case 35:
                    Tools.RotateCube(cube, 3, 218);
                    return Tools.Y2Perm(Constants.F2LAlgs[218]);
                case 6:
                    Tools.RotateCube(cube, 3, 219);
                    return Tools.Y2Perm(Constants.F2LAlgs[219]);
                case 47:
                    Tools.RotateCube(cube, 3, 220);
                    return Tools.Y2Perm(Constants.F2LAlgs[220]);
                case 2:
                    Tools.RotateCube(cube, 3, 233);
                    return Tools.Y2Perm(Constants.F2LAlgs[233]);
                case 38:
                    Tools.RotateCube(cube, 3, 234);
                    return Tools.Y2Perm(Constants.F2LAlgs[234]);
                case 9:
                    Tools.RotateCube(cube, 3, 235);
                    return Tools.Y2Perm(Constants.F2LAlgs[235]);
                case 11:
                    Tools.RotateCube(cube, 3, 236);
                    return Tools.Y2Perm(Constants.F2LAlgs[236]);
                case 36:
                    Tools.RotateCube(cube, 3, 237);
                    return Tools.Y2Perm(Constants.F2LAlgs[237]);
                case 18:
                    Tools.RotateCube(cube, 3, 238);
                    return Tools.Y2Perm(Constants.F2LAlgs[238]);
                case 20:
                    Tools.RotateCube(cube, 3, 227);
                    return Tools.Y2Perm(Constants.F2LAlgs[227]);
                case 42:
                    Tools.RotateCube(cube, 3, 228);
                    return Tools.Y2Perm(Constants.F2LAlgs[228]);
                case 27:
                    Tools.RotateCube(cube, 3, 229);
                    return Tools.Y2Perm(Constants.F2LAlgs[229]);
                case 29:
                    Tools.RotateCube(cube, 3, 230);
                    return Tools.Y2Perm(Constants.F2LAlgs[230]);
                case 44:
                    Tools.RotateCube(cube, 3, 231);
                    return Tools.Y2Perm(Constants.F2LAlgs[231]);
                case 0:
                    Tools.RotateCube(cube, 3, 232);
                    return Tools.Y2Perm(Constants.F2LAlgs[232]);
                }
                break;
            case 28:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 3, 245);
                    return Tools.Y2Perm(Constants.F2LAlgs[245]);
                case 15:
                    Tools.RotateCube(cube, 3, 246);
                    return Tools.Y2Perm(Constants.F2LAlgs[246]);
                case 53:
                    Tools.RotateCube(cube, 3, 247);
                    return Tools.Y2Perm(Constants.F2LAlgs[247]);
                case 17:
                    Tools.RotateCube(cube, 3, 248);
                    return Tools.Y2Perm(Constants.F2LAlgs[248]);
                case 24:
                    Tools.RotateCube(cube, 3, 249);
                    return Tools.Y2Perm(Constants.F2LAlgs[249]);
                case 51:
                    Tools.RotateCube(cube, 3, 250);
                    return Tools.Y2Perm(Constants.F2LAlgs[250]);
                case 26:
                    Tools.RotateCube(cube, 3, 239);
                    return Tools.Y2Perm(Constants.F2LAlgs[239]);
                case 33:
                    Tools.RotateCube(cube, 3, 240);
                    return Tools.Y2Perm(Constants.F2LAlgs[240]);
                case 45:
                    Tools.RotateCube(cube, 3, 241);
                    return Tools.Y2Perm(Constants.F2LAlgs[241]);
                case 35:
                    Tools.RotateCube(cube, 3, 242);
                    return Tools.Y2Perm(Constants.F2LAlgs[242]);
                case 6:
                    Tools.RotateCube(cube, 3, 243);
                    return Tools.Y2Perm(Constants.F2LAlgs[243]);
                case 47:
                    Tools.RotateCube(cube, 3, 244);
                    return Tools.Y2Perm(Constants.F2LAlgs[244]);
                case 2:
                    Tools.RotateCube(cube, 3, 257);
                    return Tools.Y2Perm(Constants.F2LAlgs[257]);
                case 38:
                    Tools.RotateCube(cube, 3, 258);
                    return Tools.Y2Perm(Constants.F2LAlgs[258]);
                case 9:
                    Tools.RotateCube(cube, 3, 259);
                    return Tools.Y2Perm(Constants.F2LAlgs[259]);
                case 11:
                    Tools.RotateCube(cube, 3, 260);
                    return Tools.Y2Perm(Constants.F2LAlgs[260]);
                case 36:
                    Tools.RotateCube(cube, 3, 261);
                    return Tools.Y2Perm(Constants.F2LAlgs[261]);
                case 18:
                    Tools.RotateCube(cube, 3, 262);
                    return Tools.Y2Perm(Constants.F2LAlgs[262]);
                case 20:
                    Tools.RotateCube(cube, 3, 251);
                    return Tools.Y2Perm(Constants.F2LAlgs[251]);
                case 42:
                    Tools.RotateCube(cube, 3, 252);
                    return Tools.Y2Perm(Constants.F2LAlgs[252]);
                case 27:
                    Tools.RotateCube(cube, 3, 253);
                    return Tools.Y2Perm(Constants.F2LAlgs[253]);
                case 29:
                    Tools.RotateCube(cube, 3, 254);
                    return Tools.Y2Perm(Constants.F2LAlgs[254]);
                case 44:
                    Tools.RotateCube(cube, 3, 255);
                    return Tools.Y2Perm(Constants.F2LAlgs[255]);
                case 0:
                    Tools.RotateCube(cube, 3, 256);
                    return Tools.Y2Perm(Constants.F2LAlgs[256]);
                }
                break;
            case 43:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 3, 269);
                    return Tools.Y2Perm(Constants.F2LAlgs[269]);
                case 15:
                    Tools.RotateCube(cube, 3, 270);
                    return Tools.Y2Perm(Constants.F2LAlgs[270]);
                case 53:
                    Tools.RotateCube(cube, 3, 271);
                    return Tools.Y2Perm(Constants.F2LAlgs[271]);
                case 17:
                    Tools.RotateCube(cube, 3, 272);
                    return Tools.Y2Perm(Constants.F2LAlgs[272]);
                case 24:
                    Tools.RotateCube(cube, 3, 273);
                    return Tools.Y2Perm(Constants.F2LAlgs[273]);
                case 51:
                    Tools.RotateCube(cube, 3, 274);
                    return Tools.Y2Perm(Constants.F2LAlgs[274]);
                case 26:
                    Tools.RotateCube(cube, 3, 263);
                    return Tools.Y2Perm(Constants.F2LAlgs[263]);
                case 33:
                    Tools.RotateCube(cube, 3, 264);
                    return Tools.Y2Perm(Constants.F2LAlgs[264]);
                case 45:
                    Tools.RotateCube(cube, 3, 265);
                    return Tools.Y2Perm(Constants.F2LAlgs[265]);
                case 35:
                    Tools.RotateCube(cube, 3, 266);
                    return Tools.Y2Perm(Constants.F2LAlgs[266]);
                case 6:
                    Tools.RotateCube(cube, 3, 267);
                    return Tools.Y2Perm(Constants.F2LAlgs[267]);
                case 47:
                    Tools.RotateCube(cube, 3, 268);
                    return Tools.Y2Perm(Constants.F2LAlgs[268]);
                case 2:
                    Tools.RotateCube(cube, 3, 281);
                    return Tools.Y2Perm(Constants.F2LAlgs[281]);
                case 38:
                    Tools.RotateCube(cube, 3, 282);
                    return Tools.Y2Perm(Constants.F2LAlgs[282]);
                case 9:
                    Tools.RotateCube(cube, 3, 283);
                    return Tools.Y2Perm(Constants.F2LAlgs[283]);
                case 11:
                    Tools.RotateCube(cube, 3, 284);
                    return Tools.Y2Perm(Constants.F2LAlgs[284]);
                case 36:
                    Tools.RotateCube(cube, 3, 285);
                    return Tools.Y2Perm(Constants.F2LAlgs[285]);
                case 18:
                    Tools.RotateCube(cube, 3, 286);
                    return Tools.Y2Perm(Constants.F2LAlgs[286]);
                case 20:
                    Tools.RotateCube(cube, 3, 275);
                    return Tools.Y2Perm(Constants.F2LAlgs[275]);
                case 42:
                    Tools.RotateCube(cube, 3, 276);
                    return Tools.Y2Perm(Constants.F2LAlgs[276]);
                case 27:
                    Tools.RotateCube(cube, 3, 277);
                    return Tools.Y2Perm(Constants.F2LAlgs[277]);
                case 29:
                    Tools.RotateCube(cube, 3, 278);
                    return Tools.Y2Perm(Constants.F2LAlgs[278]);
                case 44:
                    Tools.RotateCube(cube, 3, 279);
                    return Tools.Y2Perm(Constants.F2LAlgs[279]);
                case 0:
                    Tools.RotateCube(cube, 3, 280);
                    return Tools.Y2Perm(Constants.F2LAlgs[280]);
                }
                break;
            }
            return string.Empty;
        }

        private static string F2L_OB(char[] cube){
            switch(ecc1){
            case 5:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 2, 152);
                    return Tools.YPerm(Constants.F2LAlgs[152]);
                case 15:
                    Tools.RotateCube(cube, 2, 153);
                    return Tools.YPerm(Constants.F2LAlgs[153]);
                case 53:
                    Tools.RotateCube(cube, 2, 154);
                    return Tools.YPerm(Constants.F2LAlgs[154]);
                case 17:
                    Tools.RotateCube(cube, 2, 143);
                    return Tools.YPerm(Constants.F2LAlgs[143]);
                case 24:
                    Tools.RotateCube(cube, 2, 144);
                    return Tools.YPerm(Constants.F2LAlgs[144]);
                case 51:
                    Tools.RotateCube(cube, 2, 145);
                    return Tools.YPerm(Constants.F2LAlgs[145]);
                case 26:
                    Tools.RotateCube(cube, 2, 146);
                    return Tools.YPerm(Constants.F2LAlgs[146]);
                case 33:
                    Tools.RotateCube(cube, 2, 147);
                    return Tools.YPerm(Constants.F2LAlgs[147]);
                case 45:
                    Tools.RotateCube(cube, 2, 148);
                    return Tools.YPerm(Constants.F2LAlgs[148]);
                case 35:
                    Tools.RotateCube(cube, 2, 149);
                    return Tools.YPerm(Constants.F2LAlgs[149]);
                case 6:
                    Tools.RotateCube(cube, 2, 150);
                    return Tools.YPerm(Constants.F2LAlgs[150]);
                case 47:
                    Tools.RotateCube(cube, 2, 151);
                    return Tools.YPerm(Constants.F2LAlgs[151]);
                case 2:
                    Tools.RotateCube(cube, 2, 164);
                    return Tools.YPerm(Constants.F2LAlgs[164]);
                case 38:
                    Tools.RotateCube(cube, 2, 165);
                    return Tools.YPerm(Constants.F2LAlgs[165]);
                case 9:
                    Tools.RotateCube(cube, 2, 166);
                    return Tools.YPerm(Constants.F2LAlgs[166]);
                case 11:
                    Tools.RotateCube(cube, 2, 155);
                    return Tools.YPerm(Constants.F2LAlgs[155]);
                case 36:
                    Tools.RotateCube(cube, 2, 156);
                    return Tools.YPerm(Constants.F2LAlgs[156]);
                case 18:
                    Tools.RotateCube(cube, 2, 157);
                    return Tools.YPerm(Constants.F2LAlgs[157]);
                case 20:
                    Tools.RotateCube(cube, 2, 158);
                    return Tools.YPerm(Constants.F2LAlgs[158]);
                case 42:
                    Tools.RotateCube(cube, 2, 159);
                    return Tools.YPerm(Constants.F2LAlgs[159]);
                case 27:
                    Tools.RotateCube(cube, 2, 160);
                    return Tools.YPerm(Constants.F2LAlgs[160]);
                case 29:
                    Tools.RotateCube(cube, 2, 161);
                    return Tools.YPerm(Constants.F2LAlgs[161]);
                case 44:
                    Tools.RotateCube(cube, 2, 162);
                    return Tools.YPerm(Constants.F2LAlgs[162]);
                case 0:
                    Tools.RotateCube(cube, 2, 163);
                    return Tools.YPerm(Constants.F2LAlgs[163]);
                }
                break;
            case 12:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 2, 176);
                    return Tools.YPerm(Constants.F2LAlgs[176]);
                case 15:
                    Tools.RotateCube(cube, 2, 177);
                    return Tools.YPerm(Constants.F2LAlgs[177]);
                case 53:
                    Tools.RotateCube(cube, 2, 178);
                    return Tools.YPerm(Constants.F2LAlgs[178]);
                case 17:
                    Tools.RotateCube(cube, 2, 167);
                    return Tools.YPerm(Constants.F2LAlgs[167]);
                case 24:
                    Tools.RotateCube(cube, 2, 168);
                    return Tools.YPerm(Constants.F2LAlgs[168]);
                case 51:
                    Tools.RotateCube(cube, 2, 169);
                    return Tools.YPerm(Constants.F2LAlgs[169]);
                case 26:
                    Tools.RotateCube(cube, 2, 170);
                    return Tools.YPerm(Constants.F2LAlgs[170]);
                case 33:
                    Tools.RotateCube(cube, 2, 171);
                    return Tools.YPerm(Constants.F2LAlgs[171]);
                case 45:
                    Tools.RotateCube(cube, 2, 172);
                    return Tools.YPerm(Constants.F2LAlgs[172]);
                case 35:
                    Tools.RotateCube(cube, 2, 173);
                    return Tools.YPerm(Constants.F2LAlgs[173]);
                case 6:
                    Tools.RotateCube(cube, 2, 174);
                    return Tools.YPerm(Constants.F2LAlgs[174]);
                case 47:
                    Tools.RotateCube(cube, 2, 175);
                    return Tools.YPerm(Constants.F2LAlgs[175]);
                case 2:
                    Tools.RotateCube(cube, 2, 188);
                    return Tools.YPerm(Constants.F2LAlgs[188]);
                case 38:
                    Tools.RotateCube(cube, 2, 189);
                    return Tools.YPerm(Constants.F2LAlgs[189]);
                case 9:
                    Tools.RotateCube(cube, 2, 190);
                    return Tools.YPerm(Constants.F2LAlgs[190]);
                case 11:
                    Tools.RotateCube(cube, 2, 179);
                    return Tools.YPerm(Constants.F2LAlgs[179]);
                case 36:
                    Tools.RotateCube(cube, 2, 180);
                    return Tools.YPerm(Constants.F2LAlgs[180]);
                case 18:
                    Tools.RotateCube(cube, 2, 181);
                    return Tools.YPerm(Constants.F2LAlgs[181]);
                case 20:
                    Tools.RotateCube(cube, 2, 182);
                    return Tools.YPerm(Constants.F2LAlgs[182]);
                case 42:
                    Tools.RotateCube(cube, 2, 183);
                    return Tools.YPerm(Constants.F2LAlgs[183]);
                case 27:
                    Tools.RotateCube(cube, 2, 184);
                    return Tools.YPerm(Constants.F2LAlgs[184]);
                case 29:
                    Tools.RotateCube(cube, 2, 185);
                    return Tools.YPerm(Constants.F2LAlgs[185]);
                case 44:
                    Tools.RotateCube(cube, 2, 186);
                    return Tools.YPerm(Constants.F2LAlgs[186]);
                case 0:
                    Tools.RotateCube(cube, 2, 187);
                    return Tools.YPerm(Constants.F2LAlgs[187]);
                }
                break;
            case 14:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 2, 8);
                    return Tools.YPerm(Constants.F2LAlgs[8]);
                case 15:
                    Tools.RotateCube(cube, 2, 9);
                    return Tools.YPerm(Constants.F2LAlgs[9]);
                case 53:
                    Tools.RotateCube(cube, 2, 10);
                    return Tools.YPerm(Constants.F2LAlgs[10]);
                case 24:
                    Tools.RotateCube(cube, 2, 0);
                    return Tools.YPerm(Constants.F2LAlgs[0]);
                case 51:
                    Tools.RotateCube(cube, 2, 1);
                    return Tools.YPerm(Constants.F2LAlgs[1]);
                case 26:
                    Tools.RotateCube(cube, 2, 2);
                    return Tools.YPerm(Constants.F2LAlgs[2]);
                case 33:
                    Tools.RotateCube(cube, 2, 3);
                    return Tools.YPerm(Constants.F2LAlgs[3]);
                case 45:
                    Tools.RotateCube(cube, 2, 4);
                    return Tools.YPerm(Constants.F2LAlgs[4]);
                case 35:
                    Tools.RotateCube(cube, 2, 5);
                    return Tools.YPerm(Constants.F2LAlgs[5]);
                case 6:
                    Tools.RotateCube(cube, 2, 6);
                    return Tools.YPerm(Constants.F2LAlgs[6]);
                case 47:
                    Tools.RotateCube(cube, 2, 7);
                    return Tools.YPerm(Constants.F2LAlgs[7]);
                case 2:
                    Tools.RotateCube(cube, 2, 20);
                    return Tools.YPerm(Constants.F2LAlgs[20]);
                case 38:
                    Tools.RotateCube(cube, 2, 21);
                    return Tools.YPerm(Constants.F2LAlgs[21]);
                case 9:
                    Tools.RotateCube(cube, 2, 22);
                    return Tools.YPerm(Constants.F2LAlgs[22]);
                case 11:
                    Tools.RotateCube(cube, 2, 11);
                    return Tools.YPerm(Constants.F2LAlgs[11]);
                case 36:
                    Tools.RotateCube(cube, 2, 12);
                    return Tools.YPerm(Constants.F2LAlgs[12]);
                case 18:
                    Tools.RotateCube(cube, 2, 13);
                    return Tools.YPerm(Constants.F2LAlgs[13]);
                case 20:
                    Tools.RotateCube(cube, 2, 14);
                    return Tools.YPerm(Constants.F2LAlgs[14]);
                case 42:
                    Tools.RotateCube(cube, 2, 15);
                    return Tools.YPerm(Constants.F2LAlgs[15]);
                case 27:
                    Tools.RotateCube(cube, 2, 16);
                    return Tools.YPerm(Constants.F2LAlgs[16]);
                case 29:
                    Tools.RotateCube(cube, 2, 17);
                    return Tools.YPerm(Constants.F2LAlgs[17]);
                case 44:
                    Tools.RotateCube(cube, 2, 18);
                    return Tools.YPerm(Constants.F2LAlgs[18]);
                case 0:
                    Tools.RotateCube(cube, 2, 19);
                    return Tools.YPerm(Constants.F2LAlgs[19]);
                }
                break;
            case 21:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 2, 32);
                    return Tools.YPerm(Constants.F2LAlgs[32]);
                case 15:
                    Tools.RotateCube(cube, 2, 33);
                    return Tools.YPerm(Constants.F2LAlgs[33]);
                case 53:
                    Tools.RotateCube(cube, 2, 34);
                    return Tools.YPerm(Constants.F2LAlgs[34]);
                case 17:
                    Tools.RotateCube(cube, 2, 23);
                    return Tools.YPerm(Constants.F2LAlgs[23]);
                case 24:
                    Tools.RotateCube(cube, 2, 24);
                    return Tools.YPerm(Constants.F2LAlgs[24]);
                case 51:
                    Tools.RotateCube(cube, 2, 25);
                    return Tools.YPerm(Constants.F2LAlgs[25]);
                case 26:
                    Tools.RotateCube(cube, 2, 26);
                    return Tools.YPerm(Constants.F2LAlgs[26]);
                case 33:
                    Tools.RotateCube(cube, 2, 27);
                    return Tools.YPerm(Constants.F2LAlgs[27]);
                case 45:
                    Tools.RotateCube(cube, 2, 28);
                    return Tools.YPerm(Constants.F2LAlgs[28]);
                case 35:
                    Tools.RotateCube(cube, 2, 29);
                    return Tools.YPerm(Constants.F2LAlgs[29]);
                case 6:
                    Tools.RotateCube(cube, 2, 30);
                    return Tools.YPerm(Constants.F2LAlgs[30]);
                case 47:
                    Tools.RotateCube(cube, 2, 31);
                    return Tools.YPerm(Constants.F2LAlgs[31]);
                case 2:
                    Tools.RotateCube(cube, 2, 44);
                    return Tools.YPerm(Constants.F2LAlgs[44]);
                case 38:
                    Tools.RotateCube(cube, 2, 45);
                    return Tools.YPerm(Constants.F2LAlgs[45]);
                case 9:
                    Tools.RotateCube(cube, 2, 46);
                    return Tools.YPerm(Constants.F2LAlgs[46]);
                case 11:
                    Tools.RotateCube(cube, 2, 35);
                    return Tools.YPerm(Constants.F2LAlgs[35]);
                case 36:
                    Tools.RotateCube(cube, 2, 36);
                    return Tools.YPerm(Constants.F2LAlgs[36]);
                case 18:
                    Tools.RotateCube(cube, 2, 37);
                    return Tools.YPerm(Constants.F2LAlgs[37]);
                case 20:
                    Tools.RotateCube(cube, 2, 38);
                    return Tools.YPerm(Constants.F2LAlgs[38]);
                case 42:
                    Tools.RotateCube(cube, 2, 39);
                    return Tools.YPerm(Constants.F2LAlgs[39]);
                case 27:
                    Tools.RotateCube(cube, 2, 40);
                    return Tools.YPerm(Constants.F2LAlgs[40]);
                case 29:
                    Tools.RotateCube(cube, 2, 41);
                    return Tools.YPerm(Constants.F2LAlgs[41]);
                case 44:
                    Tools.RotateCube(cube, 2, 42);
                    return Tools.YPerm(Constants.F2LAlgs[42]);
                case 0:
                    Tools.RotateCube(cube, 2, 43);
                    return Tools.YPerm(Constants.F2LAlgs[43]);
                }
                break;
            case 23:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 2, 56);
                    return Tools.YPerm(Constants.F2LAlgs[56]);
                case 15:
                    Tools.RotateCube(cube, 2, 57);
                    return Tools.YPerm(Constants.F2LAlgs[57]);
                case 53:
                    Tools.RotateCube(cube, 2, 58);
                    return Tools.YPerm(Constants.F2LAlgs[58]);
                case 17:
                    Tools.RotateCube(cube, 2, 47);
                    return Tools.YPerm(Constants.F2LAlgs[47]);
                case 24:
                    Tools.RotateCube(cube, 2, 48);
                    return Tools.YPerm(Constants.F2LAlgs[48]);
                case 51:
                    Tools.RotateCube(cube, 2, 49);
                    return Tools.YPerm(Constants.F2LAlgs[49]);
                case 26:
                    Tools.RotateCube(cube, 2, 50);
                    return Tools.YPerm(Constants.F2LAlgs[50]);
                case 33:
                    Tools.RotateCube(cube, 2, 51);
                    return Tools.YPerm(Constants.F2LAlgs[51]);
                case 45:
                    Tools.RotateCube(cube, 2, 52);
                    return Tools.YPerm(Constants.F2LAlgs[52]);
                case 35:
                    Tools.RotateCube(cube, 2, 53);
                    return Tools.YPerm(Constants.F2LAlgs[53]);
                case 6:
                    Tools.RotateCube(cube, 2, 54);
                    return Tools.YPerm(Constants.F2LAlgs[54]);
                case 47:
                    Tools.RotateCube(cube, 2, 55);
                    return Tools.YPerm(Constants.F2LAlgs[55]);
                case 2:
                    Tools.RotateCube(cube, 2, 68);
                    return Tools.YPerm(Constants.F2LAlgs[68]);
                case 38:
                    Tools.RotateCube(cube, 2, 69);
                    return Tools.YPerm(Constants.F2LAlgs[69]);
                case 9:
                    Tools.RotateCube(cube, 2, 70);
                    return Tools.YPerm(Constants.F2LAlgs[70]);
                case 11:
                    Tools.RotateCube(cube, 2, 59);
                    return Tools.YPerm(Constants.F2LAlgs[59]);
                case 36:
                    Tools.RotateCube(cube, 2, 60);
                    return Tools.YPerm(Constants.F2LAlgs[60]);
                case 18:
                    Tools.RotateCube(cube, 2, 61);
                    return Tools.YPerm(Constants.F2LAlgs[61]);
                case 20:
                    Tools.RotateCube(cube, 2, 62);
                    return Tools.YPerm(Constants.F2LAlgs[62]);
                case 42:
                    Tools.RotateCube(cube, 2, 63);
                    return Tools.YPerm(Constants.F2LAlgs[63]);
                case 27:
                    Tools.RotateCube(cube, 2, 64);
                    return Tools.YPerm(Constants.F2LAlgs[64]);
                case 29:
                    Tools.RotateCube(cube, 2, 65);
                    return Tools.YPerm(Constants.F2LAlgs[65]);
                case 44:
                    Tools.RotateCube(cube, 2, 66);
                    return Tools.YPerm(Constants.F2LAlgs[66]);
                case 0:
                    Tools.RotateCube(cube, 2, 67);
                    return Tools.YPerm(Constants.F2LAlgs[67]);
                }
                break;
            case 30:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 2, 80);
                    return Tools.YPerm(Constants.F2LAlgs[80]);
                case 15:
                    Tools.RotateCube(cube, 2, 81);
                    return Tools.YPerm(Constants.F2LAlgs[81]);
                case 53:
                    Tools.RotateCube(cube, 2, 82);
                    return Tools.YPerm(Constants.F2LAlgs[82]);
                case 17:
                    Tools.RotateCube(cube, 2, 71);
                    return Tools.YPerm(Constants.F2LAlgs[71]);
                case 24:
                    Tools.RotateCube(cube, 2, 72);
                    return Tools.YPerm(Constants.F2LAlgs[72]);
                case 51:
                    Tools.RotateCube(cube, 2, 73);
                    return Tools.YPerm(Constants.F2LAlgs[73]);
                case 26:
                    Tools.RotateCube(cube, 2, 74);
                    return Tools.YPerm(Constants.F2LAlgs[74]);
                case 33:
                    Tools.RotateCube(cube, 2, 75);
                    return Tools.YPerm(Constants.F2LAlgs[75]);
                case 45:
                    Tools.RotateCube(cube, 2, 76);
                    return Tools.YPerm(Constants.F2LAlgs[76]);
                case 35:
                    Tools.RotateCube(cube, 2, 77);
                    return Tools.YPerm(Constants.F2LAlgs[77]);
                case 6:
                    Tools.RotateCube(cube, 2, 78);
                    return Tools.YPerm(Constants.F2LAlgs[78]);
                case 47:
                    Tools.RotateCube(cube, 2, 79);
                    return Tools.YPerm(Constants.F2LAlgs[79]);
                case 2:
                    Tools.RotateCube(cube, 2, 92);
                    return Tools.YPerm(Constants.F2LAlgs[92]);
                case 38:
                    Tools.RotateCube(cube, 2, 93);
                    return Tools.YPerm(Constants.F2LAlgs[93]);
                case 9:
                    Tools.RotateCube(cube, 2, 94);
                    return Tools.YPerm(Constants.F2LAlgs[94]);
                case 11:
                    Tools.RotateCube(cube, 2, 83);
                    return Tools.YPerm(Constants.F2LAlgs[83]);
                case 36:
                    Tools.RotateCube(cube, 2, 84);
                    return Tools.YPerm(Constants.F2LAlgs[84]);
                case 18:
                    Tools.RotateCube(cube, 2, 85);
                    return Tools.YPerm(Constants.F2LAlgs[85]);
                case 20:
                    Tools.RotateCube(cube, 2, 86);
                    return Tools.YPerm(Constants.F2LAlgs[86]);
                case 42:
                    Tools.RotateCube(cube, 2, 87);
                    return Tools.YPerm(Constants.F2LAlgs[87]);
                case 27:
                    Tools.RotateCube(cube, 2, 88);
                    return Tools.YPerm(Constants.F2LAlgs[88]);
                case 29:
                    Tools.RotateCube(cube, 2, 89);
                    return Tools.YPerm(Constants.F2LAlgs[89]);
                case 44:
                    Tools.RotateCube(cube, 2, 90);
                    return Tools.YPerm(Constants.F2LAlgs[90]);
                case 0:
                    Tools.RotateCube(cube, 2, 91);
                    return Tools.YPerm(Constants.F2LAlgs[91]);
                }
                break;
            case 32:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 2, 104);
                    return Tools.YPerm(Constants.F2LAlgs[104]);
                case 15:
                    Tools.RotateCube(cube, 2, 105);
                    return Tools.YPerm(Constants.F2LAlgs[105]);
                case 53:
                    Tools.RotateCube(cube, 2, 106);
                    return Tools.YPerm(Constants.F2LAlgs[106]);
                case 17:
                    Tools.RotateCube(cube, 2, 95);
                    return Tools.YPerm(Constants.F2LAlgs[95]);
                case 24:
                    Tools.RotateCube(cube, 2, 96);
                    return Tools.YPerm(Constants.F2LAlgs[96]);
                case 51:
                    Tools.RotateCube(cube, 2, 97);
                    return Tools.YPerm(Constants.F2LAlgs[97]);
                case 26:
                    Tools.RotateCube(cube, 2, 98);
                    return Tools.YPerm(Constants.F2LAlgs[98]);
                case 33:
                    Tools.RotateCube(cube, 2, 99);
                    return Tools.YPerm(Constants.F2LAlgs[99]);
                case 45:
                    Tools.RotateCube(cube, 2, 100);
                    return Tools.YPerm(Constants.F2LAlgs[100]);
                case 35:
                    Tools.RotateCube(cube, 2, 101);
                    return Tools.YPerm(Constants.F2LAlgs[101]);
                case 6:
                    Tools.RotateCube(cube, 2, 102);
                    return Tools.YPerm(Constants.F2LAlgs[102]);
                case 47:
                    Tools.RotateCube(cube, 2, 103);
                    return Tools.YPerm(Constants.F2LAlgs[103]);
                case 2:
                    Tools.RotateCube(cube, 2, 116);
                    return Tools.YPerm(Constants.F2LAlgs[116]);
                case 38:
                    Tools.RotateCube(cube, 2, 117);
                    return Tools.YPerm(Constants.F2LAlgs[117]);
                case 9:
                    Tools.RotateCube(cube, 2, 118);
                    return Tools.YPerm(Constants.F2LAlgs[118]);
                case 11:
                    Tools.RotateCube(cube, 2, 107);
                    return Tools.YPerm(Constants.F2LAlgs[107]);
                case 36:
                    Tools.RotateCube(cube, 2, 108);
                    return Tools.YPerm(Constants.F2LAlgs[108]);
                case 18:
                    Tools.RotateCube(cube, 2, 109);
                    return Tools.YPerm(Constants.F2LAlgs[109]);
                case 20:
                    Tools.RotateCube(cube, 2, 110);
                    return Tools.YPerm(Constants.F2LAlgs[110]);
                case 42:
                    Tools.RotateCube(cube, 2, 111);
                    return Tools.YPerm(Constants.F2LAlgs[111]);
                case 27:
                    Tools.RotateCube(cube, 2, 112);
                    return Tools.YPerm(Constants.F2LAlgs[112]);
                case 29:
                    Tools.RotateCube(cube, 2, 113);
                    return Tools.YPerm(Constants.F2LAlgs[113]);
                case 44:
                    Tools.RotateCube(cube, 2, 114);
                    return Tools.YPerm(Constants.F2LAlgs[114]);
                case 0:
                    Tools.RotateCube(cube, 2, 115);
                    return Tools.YPerm(Constants.F2LAlgs[115]);
                }
                break;
            case 3:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 2, 128);
                    return Tools.YPerm(Constants.F2LAlgs[128]);
                case 15:
                    Tools.RotateCube(cube, 2, 129);
                    return Tools.YPerm(Constants.F2LAlgs[129]);
                case 53:
                    Tools.RotateCube(cube, 2, 130);
                    return Tools.YPerm(Constants.F2LAlgs[130]);
                case 17:
                    Tools.RotateCube(cube, 2, 119);
                    return Tools.YPerm(Constants.F2LAlgs[119]);
                case 24:
                    Tools.RotateCube(cube, 2, 120);
                    return Tools.YPerm(Constants.F2LAlgs[120]);
                case 51:
                    Tools.RotateCube(cube, 2, 121);
                    return Tools.YPerm(Constants.F2LAlgs[121]);
                case 26:
                    Tools.RotateCube(cube, 2, 122);
                    return Tools.YPerm(Constants.F2LAlgs[122]);
                case 33:
                    Tools.RotateCube(cube, 2, 123);
                    return Tools.YPerm(Constants.F2LAlgs[123]);
                case 45:
                    Tools.RotateCube(cube, 2, 124);
                    return Tools.YPerm(Constants.F2LAlgs[124]);
                case 35:
                    Tools.RotateCube(cube, 2, 125);
                    return Tools.YPerm(Constants.F2LAlgs[125]);
                case 6:
                    Tools.RotateCube(cube, 2, 126);
                    return Tools.YPerm(Constants.F2LAlgs[126]);
                case 47:
                    Tools.RotateCube(cube, 2, 127);
                    return Tools.YPerm(Constants.F2LAlgs[127]);
                case 2:
                    Tools.RotateCube(cube, 2, 140);
                    return Tools.YPerm(Constants.F2LAlgs[140]);
                case 38:
                    Tools.RotateCube(cube, 2, 141);
                    return Tools.YPerm(Constants.F2LAlgs[141]);
                case 9:
                    Tools.RotateCube(cube, 2, 142);
                    return Tools.YPerm(Constants.F2LAlgs[142]);
                case 11:
                    Tools.RotateCube(cube, 2, 131);
                    return Tools.YPerm(Constants.F2LAlgs[131]);
                case 36:
                    Tools.RotateCube(cube, 2, 132);
                    return Tools.YPerm(Constants.F2LAlgs[132]);
                case 18:
                    Tools.RotateCube(cube, 2, 133);
                    return Tools.YPerm(Constants.F2LAlgs[133]);
                case 20:
                    Tools.RotateCube(cube, 2, 134);
                    return Tools.YPerm(Constants.F2LAlgs[134]);
                case 42:
                    Tools.RotateCube(cube, 2, 135);
                    return Tools.YPerm(Constants.F2LAlgs[135]);
                case 27:
                    Tools.RotateCube(cube, 2, 136);
                    return Tools.YPerm(Constants.F2LAlgs[136]);
                case 29:
                    Tools.RotateCube(cube, 2, 137);
                    return Tools.YPerm(Constants.F2LAlgs[137]);
                case 44:
                    Tools.RotateCube(cube, 2, 138);
                    return Tools.YPerm(Constants.F2LAlgs[138]);
                case 0:
                    Tools.RotateCube(cube, 2, 139);
                    return Tools.YPerm(Constants.F2LAlgs[139]);
                }
                break;
            case 1:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 2, 344);
                    return Tools.YPerm(Constants.F2LAlgs[344]);
                case 15:
                    Tools.RotateCube(cube, 2, 345);
                    return Tools.YPerm(Constants.F2LAlgs[345]);
                case 53:
                    Tools.RotateCube(cube, 2, 346);
                    return Tools.YPerm(Constants.F2LAlgs[346]);
                case 17:
                    Tools.RotateCube(cube, 2, 335);
                    return Tools.YPerm(Constants.F2LAlgs[335]);
                case 24:
                    Tools.RotateCube(cube, 2, 336);
                    return Tools.YPerm(Constants.F2LAlgs[336]);
                case 51:
                    Tools.RotateCube(cube, 2, 337);
                    return Tools.YPerm(Constants.F2LAlgs[337]);
                case 26:
                    Tools.RotateCube(cube, 2, 338);
                    return Tools.YPerm(Constants.F2LAlgs[338]);
                case 33:
                    Tools.RotateCube(cube, 2, 339);
                    return Tools.YPerm(Constants.F2LAlgs[339]);
                case 45:
                    Tools.RotateCube(cube, 2, 340);
                    return Tools.YPerm(Constants.F2LAlgs[340]);
                case 35:
                    Tools.RotateCube(cube, 2, 341);
                    return Tools.YPerm(Constants.F2LAlgs[341]);
                case 6:
                    Tools.RotateCube(cube, 2, 342);
                    return Tools.YPerm(Constants.F2LAlgs[342]);
                case 47:
                    Tools.RotateCube(cube, 2, 343);
                    return Tools.YPerm(Constants.F2LAlgs[343]);
                case 2:
                    Tools.RotateCube(cube, 2, 356);
                    return Tools.YPerm(Constants.F2LAlgs[356]);
                case 38:
                    Tools.RotateCube(cube, 2, 357);
                    return Tools.YPerm(Constants.F2LAlgs[357]);
                case 9:
                    Tools.RotateCube(cube, 2, 358);
                    return Tools.YPerm(Constants.F2LAlgs[358]);
                case 11:
                    Tools.RotateCube(cube, 2, 347);
                    return Tools.YPerm(Constants.F2LAlgs[347]);
                case 36:
                    Tools.RotateCube(cube, 2, 348);
                    return Tools.YPerm(Constants.F2LAlgs[348]);
                case 18:
                    Tools.RotateCube(cube, 2, 349);
                    return Tools.YPerm(Constants.F2LAlgs[349]);
                case 20:
                    Tools.RotateCube(cube, 2, 350);
                    return Tools.YPerm(Constants.F2LAlgs[350]);
                case 42:
                    Tools.RotateCube(cube, 2, 351);
                    return Tools.YPerm(Constants.F2LAlgs[351]);
                case 27:
                    Tools.RotateCube(cube, 2, 352);
                    return Tools.YPerm(Constants.F2LAlgs[352]);
                case 29:
                    Tools.RotateCube(cube, 2, 353);
                    return Tools.YPerm(Constants.F2LAlgs[353]);
                case 44:
                    Tools.RotateCube(cube, 2, 354);
                    return Tools.YPerm(Constants.F2LAlgs[354]);
                case 0:
                    Tools.RotateCube(cube, 2, 355);
                    return Tools.YPerm(Constants.F2LAlgs[355]);
                }
                break;
            case 41:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 2, 368);
                    return Tools.YPerm(Constants.F2LAlgs[368]);
                case 15:
                    Tools.RotateCube(cube, 2, 369);
                    return Tools.YPerm(Constants.F2LAlgs[369]);
                case 53:
                    Tools.RotateCube(cube, 2, 370);
                    return Tools.YPerm(Constants.F2LAlgs[370]);
                case 17:
                    Tools.RotateCube(cube, 2, 359);
                    return Tools.YPerm(Constants.F2LAlgs[359]);
                case 24:
                    Tools.RotateCube(cube, 2, 360);
                    return Tools.YPerm(Constants.F2LAlgs[360]);
                case 51:
                    Tools.RotateCube(cube, 2, 361);
                    return Tools.YPerm(Constants.F2LAlgs[361]);
                case 26:
                    Tools.RotateCube(cube, 2, 362);
                    return Tools.YPerm(Constants.F2LAlgs[362]);
                case 33:
                    Tools.RotateCube(cube, 2, 363);
                    return Tools.YPerm(Constants.F2LAlgs[363]);
                case 45:
                    Tools.RotateCube(cube, 2, 364);
                    return Tools.YPerm(Constants.F2LAlgs[364]);
                case 35:
                    Tools.RotateCube(cube, 2, 365);
                    return Tools.YPerm(Constants.F2LAlgs[365]);
                case 6:
                    Tools.RotateCube(cube, 2, 366);
                    return Tools.YPerm(Constants.F2LAlgs[366]);
                case 47:
                    Tools.RotateCube(cube, 2, 367);
                    return Tools.YPerm(Constants.F2LAlgs[367]);
                case 2:
                    Tools.RotateCube(cube, 2, 380);
                    return Tools.YPerm(Constants.F2LAlgs[380]);
                case 38:
                    Tools.RotateCube(cube, 2, 381);
                    return Tools.YPerm(Constants.F2LAlgs[381]);
                case 9:
                    Tools.RotateCube(cube, 2, 382);
                    return Tools.YPerm(Constants.F2LAlgs[382]);
                case 11:
                    Tools.RotateCube(cube, 2, 371);
                    return Tools.YPerm(Constants.F2LAlgs[371]);
                case 36:
                    Tools.RotateCube(cube, 2, 372);
                    return Tools.YPerm(Constants.F2LAlgs[372]);
                case 18:
                    Tools.RotateCube(cube, 2, 373);
                    return Tools.YPerm(Constants.F2LAlgs[373]);
                case 20:
                    Tools.RotateCube(cube, 2, 374);
                    return Tools.YPerm(Constants.F2LAlgs[374]);
                case 42:
                    Tools.RotateCube(cube, 2, 375);
                    return Tools.YPerm(Constants.F2LAlgs[375]);
                case 27:
                    Tools.RotateCube(cube, 2, 376);
                    return Tools.YPerm(Constants.F2LAlgs[376]);
                case 29:
                    Tools.RotateCube(cube, 2, 377);
                    return Tools.YPerm(Constants.F2LAlgs[377]);
                case 44:
                    Tools.RotateCube(cube, 2, 378);
                    return Tools.YPerm(Constants.F2LAlgs[378]);
                case 0:
                    Tools.RotateCube(cube, 2, 379);
                    return Tools.YPerm(Constants.F2LAlgs[379]);
                }
                break;
            case 10:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 2, 200);
                    return Tools.YPerm(Constants.F2LAlgs[200]);
                case 15:
                    Tools.RotateCube(cube, 2, 201);
                    return Tools.YPerm(Constants.F2LAlgs[201]);
                case 53:
                    Tools.RotateCube(cube, 2, 202);
                    return Tools.YPerm(Constants.F2LAlgs[202]);
                case 17:
                    Tools.RotateCube(cube, 2, 191);
                    return Tools.YPerm(Constants.F2LAlgs[191]);
                case 24:
                    Tools.RotateCube(cube, 2, 192);
                    return Tools.YPerm(Constants.F2LAlgs[192]);
                case 51:
                    Tools.RotateCube(cube, 2, 193);
                    return Tools.YPerm(Constants.F2LAlgs[193]);
                case 26:
                    Tools.RotateCube(cube, 2, 194);
                    return Tools.YPerm(Constants.F2LAlgs[194]);
                case 33:
                    Tools.RotateCube(cube, 2, 195);
                    return Tools.YPerm(Constants.F2LAlgs[195]);
                case 45:
                    Tools.RotateCube(cube, 2, 196);
                    return Tools.YPerm(Constants.F2LAlgs[196]);
                case 35:
                    Tools.RotateCube(cube, 2, 197);
                    return Tools.YPerm(Constants.F2LAlgs[197]);
                case 6:
                    Tools.RotateCube(cube, 2, 198);
                    return Tools.YPerm(Constants.F2LAlgs[198]);
                case 47:
                    Tools.RotateCube(cube, 2, 199);
                    return Tools.YPerm(Constants.F2LAlgs[199]);
                case 2:
                    Tools.RotateCube(cube, 2, 212);
                    return Tools.YPerm(Constants.F2LAlgs[212]);
                case 38:
                    Tools.RotateCube(cube, 2, 213);
                    return Tools.YPerm(Constants.F2LAlgs[213]);
                case 9:
                    Tools.RotateCube(cube, 2, 214);
                    return Tools.YPerm(Constants.F2LAlgs[214]);
                case 11:
                    Tools.RotateCube(cube, 2, 203);
                    return Tools.YPerm(Constants.F2LAlgs[203]);
                case 36:
                    Tools.RotateCube(cube, 2, 204);
                    return Tools.YPerm(Constants.F2LAlgs[204]);
                case 18:
                    Tools.RotateCube(cube, 2, 205);
                    return Tools.YPerm(Constants.F2LAlgs[205]);
                case 20:
                    Tools.RotateCube(cube, 2, 206);
                    return Tools.YPerm(Constants.F2LAlgs[206]);
                case 42:
                    Tools.RotateCube(cube, 2, 207);
                    return Tools.YPerm(Constants.F2LAlgs[207]);
                case 27:
                    Tools.RotateCube(cube, 2, 208);
                    return Tools.YPerm(Constants.F2LAlgs[208]);
                case 29:
                    Tools.RotateCube(cube, 2, 209);
                    return Tools.YPerm(Constants.F2LAlgs[209]);
                case 44:
                    Tools.RotateCube(cube, 2, 210);
                    return Tools.YPerm(Constants.F2LAlgs[210]);
                case 0:
                    Tools.RotateCube(cube, 2, 211);
                    return Tools.YPerm(Constants.F2LAlgs[211]);
                }
                break;
            case 37:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 2, 224);
                    return Tools.YPerm(Constants.F2LAlgs[224]);
                case 15:
                    Tools.RotateCube(cube, 2, 225);
                    return Tools.YPerm(Constants.F2LAlgs[225]);
                case 53:
                    Tools.RotateCube(cube, 2, 226);
                    return Tools.YPerm(Constants.F2LAlgs[226]);
                case 17:
                    Tools.RotateCube(cube, 2, 215);
                    return Tools.YPerm(Constants.F2LAlgs[215]);
                case 24:
                    Tools.RotateCube(cube, 2, 216);
                    return Tools.YPerm(Constants.F2LAlgs[216]);
                case 51:
                    Tools.RotateCube(cube, 2, 217);
                    return Tools.YPerm(Constants.F2LAlgs[217]);
                case 26:
                    Tools.RotateCube(cube, 2, 218);
                    return Tools.YPerm(Constants.F2LAlgs[218]);
                case 33:
                    Tools.RotateCube(cube, 2, 219);
                    return Tools.YPerm(Constants.F2LAlgs[219]);
                case 45:
                    Tools.RotateCube(cube, 2, 220);
                    return Tools.YPerm(Constants.F2LAlgs[220]);
                case 35:
                    Tools.RotateCube(cube, 2, 221);
                    return Tools.YPerm(Constants.F2LAlgs[221]);
                case 6:
                    Tools.RotateCube(cube, 2, 222);
                    return Tools.YPerm(Constants.F2LAlgs[222]);
                case 47:
                    Tools.RotateCube(cube, 2, 223);
                    return Tools.YPerm(Constants.F2LAlgs[223]);
                case 2:
                    Tools.RotateCube(cube, 2, 236);
                    return Tools.YPerm(Constants.F2LAlgs[236]);
                case 38:
                    Tools.RotateCube(cube, 2, 237);
                    return Tools.YPerm(Constants.F2LAlgs[237]);
                case 9:
                    Tools.RotateCube(cube, 2, 238);
                    return Tools.YPerm(Constants.F2LAlgs[238]);
                case 11:
                    Tools.RotateCube(cube, 2, 227);
                    return Tools.YPerm(Constants.F2LAlgs[227]);
                case 36:
                    Tools.RotateCube(cube, 2, 228);
                    return Tools.YPerm(Constants.F2LAlgs[228]);
                case 18:
                    Tools.RotateCube(cube, 2, 229);
                    return Tools.YPerm(Constants.F2LAlgs[229]);
                case 20:
                    Tools.RotateCube(cube, 2, 230);
                    return Tools.YPerm(Constants.F2LAlgs[230]);
                case 42:
                    Tools.RotateCube(cube, 2, 231);
                    return Tools.YPerm(Constants.F2LAlgs[231]);
                case 27:
                    Tools.RotateCube(cube, 2, 232);
                    return Tools.YPerm(Constants.F2LAlgs[232]);
                case 29:
                    Tools.RotateCube(cube, 2, 233);
                    return Tools.YPerm(Constants.F2LAlgs[233]);
                case 44:
                    Tools.RotateCube(cube, 2, 234);
                    return Tools.YPerm(Constants.F2LAlgs[234]);
                case 0:
                    Tools.RotateCube(cube, 2, 235);
                    return Tools.YPerm(Constants.F2LAlgs[235]);
                }
                break;
            case 19:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 2, 248);
                    return Tools.YPerm(Constants.F2LAlgs[248]);
                case 15:
                    Tools.RotateCube(cube, 2, 249);
                    return Tools.YPerm(Constants.F2LAlgs[249]);
                case 53:
                    Tools.RotateCube(cube, 2, 250);
                    return Tools.YPerm(Constants.F2LAlgs[250]);
                case 17:
                    Tools.RotateCube(cube, 2, 239);
                    return Tools.YPerm(Constants.F2LAlgs[239]);
                case 24:
                    Tools.RotateCube(cube, 2, 240);
                    return Tools.YPerm(Constants.F2LAlgs[240]);
                case 51:
                    Tools.RotateCube(cube, 2, 241);
                    return Tools.YPerm(Constants.F2LAlgs[241]);
                case 26:
                    Tools.RotateCube(cube, 2, 242);
                    return Tools.YPerm(Constants.F2LAlgs[242]);
                case 33:
                    Tools.RotateCube(cube, 2, 243);
                    return Tools.YPerm(Constants.F2LAlgs[243]);
                case 45:
                    Tools.RotateCube(cube, 2, 244);
                    return Tools.YPerm(Constants.F2LAlgs[244]);
                case 35:
                    Tools.RotateCube(cube, 2, 245);
                    return Tools.YPerm(Constants.F2LAlgs[245]);
                case 6:
                    Tools.RotateCube(cube, 2, 246);
                    return Tools.YPerm(Constants.F2LAlgs[246]);
                case 47:
                    Tools.RotateCube(cube, 2, 247);
                    return Tools.YPerm(Constants.F2LAlgs[247]);
                case 2:
                    Tools.RotateCube(cube, 2, 260);
                    return Tools.YPerm(Constants.F2LAlgs[260]);
                case 38:
                    Tools.RotateCube(cube, 2, 261);
                    return Tools.YPerm(Constants.F2LAlgs[261]);
                case 9:
                    Tools.RotateCube(cube, 2, 262);
                    return Tools.YPerm(Constants.F2LAlgs[262]);
                case 11:
                    Tools.RotateCube(cube, 2, 251);
                    return Tools.YPerm(Constants.F2LAlgs[251]);
                case 36:
                    Tools.RotateCube(cube, 2, 252);
                    return Tools.YPerm(Constants.F2LAlgs[252]);
                case 18:
                    Tools.RotateCube(cube, 2, 253);
                    return Tools.YPerm(Constants.F2LAlgs[253]);
                case 20:
                    Tools.RotateCube(cube, 2, 254);
                    return Tools.YPerm(Constants.F2LAlgs[254]);
                case 42:
                    Tools.RotateCube(cube, 2, 255);
                    return Tools.YPerm(Constants.F2LAlgs[255]);
                case 27:
                    Tools.RotateCube(cube, 2, 256);
                    return Tools.YPerm(Constants.F2LAlgs[256]);
                case 29:
                    Tools.RotateCube(cube, 2, 257);
                    return Tools.YPerm(Constants.F2LAlgs[257]);
                case 44:
                    Tools.RotateCube(cube, 2, 258);
                    return Tools.YPerm(Constants.F2LAlgs[258]);
                case 0:
                    Tools.RotateCube(cube, 2, 259);
                    return Tools.YPerm(Constants.F2LAlgs[259]);
                }
                break;
            case 39:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 2, 272);
                    return Tools.YPerm(Constants.F2LAlgs[272]);
                case 15:
                    Tools.RotateCube(cube, 2, 273);
                    return Tools.YPerm(Constants.F2LAlgs[273]);
                case 53:
                    Tools.RotateCube(cube, 2, 274);
                    return Tools.YPerm(Constants.F2LAlgs[274]);
                case 17:
                    Tools.RotateCube(cube, 2, 263);
                    return Tools.YPerm(Constants.F2LAlgs[263]);
                case 24:
                    Tools.RotateCube(cube, 2, 264);
                    return Tools.YPerm(Constants.F2LAlgs[264]);
                case 51:
                    Tools.RotateCube(cube, 2, 265);
                    return Tools.YPerm(Constants.F2LAlgs[265]);
                case 26:
                    Tools.RotateCube(cube, 2, 266);
                    return Tools.YPerm(Constants.F2LAlgs[266]);
                case 33:
                    Tools.RotateCube(cube, 2, 267);
                    return Tools.YPerm(Constants.F2LAlgs[267]);
                case 45:
                    Tools.RotateCube(cube, 2, 268);
                    return Tools.YPerm(Constants.F2LAlgs[268]);
                case 35:
                    Tools.RotateCube(cube, 2, 269);
                    return Tools.YPerm(Constants.F2LAlgs[269]);
                case 6:
                    Tools.RotateCube(cube, 2, 270);
                    return Tools.YPerm(Constants.F2LAlgs[270]);
                case 47:
                    Tools.RotateCube(cube, 2, 271);
                    return Tools.YPerm(Constants.F2LAlgs[271]);
                case 2:
                    Tools.RotateCube(cube, 2, 284);
                    return Tools.YPerm(Constants.F2LAlgs[284]);
                case 38:
                    Tools.RotateCube(cube, 2, 285);
                    return Tools.YPerm(Constants.F2LAlgs[285]);
                case 9:
                    Tools.RotateCube(cube, 2, 286);
                    return Tools.YPerm(Constants.F2LAlgs[286]);
                case 11:
                    Tools.RotateCube(cube, 2, 275);
                    return Tools.YPerm(Constants.F2LAlgs[275]);
                case 36:
                    Tools.RotateCube(cube, 2, 276);
                    return Tools.YPerm(Constants.F2LAlgs[276]);
                case 18:
                    Tools.RotateCube(cube, 2, 277);
                    return Tools.YPerm(Constants.F2LAlgs[277]);
                case 20:
                    Tools.RotateCube(cube, 2, 278);
                    return Tools.YPerm(Constants.F2LAlgs[278]);
                case 42:
                    Tools.RotateCube(cube, 2, 279);
                    return Tools.YPerm(Constants.F2LAlgs[279]);
                case 27:
                    Tools.RotateCube(cube, 2, 280);
                    return Tools.YPerm(Constants.F2LAlgs[280]);
                case 29:
                    Tools.RotateCube(cube, 2, 281);
                    return Tools.YPerm(Constants.F2LAlgs[281]);
                case 44:
                    Tools.RotateCube(cube, 2, 282);
                    return Tools.YPerm(Constants.F2LAlgs[282]);
                case 0:
                    Tools.RotateCube(cube, 2, 283);
                    return Tools.YPerm(Constants.F2LAlgs[283]);
                }
                break;
            case 28:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 2, 296);
                    return Tools.YPerm(Constants.F2LAlgs[296]);
                case 15:
                    Tools.RotateCube(cube, 2, 297);
                    return Tools.YPerm(Constants.F2LAlgs[297]);
                case 53:
                    Tools.RotateCube(cube, 2, 298);
                    return Tools.YPerm(Constants.F2LAlgs[298]);
                case 17:
                    Tools.RotateCube(cube, 2, 287);
                    return Tools.YPerm(Constants.F2LAlgs[287]);
                case 24:
                    Tools.RotateCube(cube, 2, 288);
                    return Tools.YPerm(Constants.F2LAlgs[288]);
                case 51:
                    Tools.RotateCube(cube, 2, 289);
                    return Tools.YPerm(Constants.F2LAlgs[289]);
                case 26:
                    Tools.RotateCube(cube, 2, 290);
                    return Tools.YPerm(Constants.F2LAlgs[290]);
                case 33:
                    Tools.RotateCube(cube, 2, 291);
                    return Tools.YPerm(Constants.F2LAlgs[291]);
                case 45:
                    Tools.RotateCube(cube, 2, 292);
                    return Tools.YPerm(Constants.F2LAlgs[292]);
                case 35:
                    Tools.RotateCube(cube, 2, 293);
                    return Tools.YPerm(Constants.F2LAlgs[293]);
                case 6:
                    Tools.RotateCube(cube, 2, 294);
                    return Tools.YPerm(Constants.F2LAlgs[294]);
                case 47:
                    Tools.RotateCube(cube, 2, 295);
                    return Tools.YPerm(Constants.F2LAlgs[295]);
                case 2:
                    Tools.RotateCube(cube, 2, 308);
                    return Tools.YPerm(Constants.F2LAlgs[308]);
                case 38:
                    Tools.RotateCube(cube, 2, 309);
                    return Tools.YPerm(Constants.F2LAlgs[309]);
                case 9:
                    Tools.RotateCube(cube, 2, 310);
                    return Tools.YPerm(Constants.F2LAlgs[310]);
                case 11:
                    Tools.RotateCube(cube, 2, 299);
                    return Tools.YPerm(Constants.F2LAlgs[299]);
                case 36:
                    Tools.RotateCube(cube, 2, 300);
                    return Tools.YPerm(Constants.F2LAlgs[300]);
                case 18:
                    Tools.RotateCube(cube, 2, 301);
                    return Tools.YPerm(Constants.F2LAlgs[301]);
                case 20:
                    Tools.RotateCube(cube, 2, 302);
                    return Tools.YPerm(Constants.F2LAlgs[302]);
                case 42:
                    Tools.RotateCube(cube, 2, 303);
                    return Tools.YPerm(Constants.F2LAlgs[303]);
                case 27:
                    Tools.RotateCube(cube, 2, 304);
                    return Tools.YPerm(Constants.F2LAlgs[304]);
                case 29:
                    Tools.RotateCube(cube, 2, 305);
                    return Tools.YPerm(Constants.F2LAlgs[305]);
                case 44:
                    Tools.RotateCube(cube, 2, 306);
                    return Tools.YPerm(Constants.F2LAlgs[306]);
                case 0:
                    Tools.RotateCube(cube, 2, 307);
                    return Tools.YPerm(Constants.F2LAlgs[307]);
                }
                break;
            case 43:
                switch(cc1){
                case 8:
                    Tools.RotateCube(cube, 2, 320);
                    return Tools.YPerm(Constants.F2LAlgs[320]);
                case 15:
                    Tools.RotateCube(cube, 2, 321);
                    return Tools.YPerm(Constants.F2LAlgs[321]);
                case 53:
                    Tools.RotateCube(cube, 2, 322);
                    return Tools.YPerm(Constants.F2LAlgs[322]);
                case 17:
                    Tools.RotateCube(cube, 2, 311);
                    return Tools.YPerm(Constants.F2LAlgs[311]);
                case 24:
                    Tools.RotateCube(cube, 2, 312);
                    return Tools.YPerm(Constants.F2LAlgs[312]);
                case 51:
                    Tools.RotateCube(cube, 2, 313);
                    return Tools.YPerm(Constants.F2LAlgs[313]);
                case 26:
                    Tools.RotateCube(cube, 2, 314);
                    return Tools.YPerm(Constants.F2LAlgs[314]);
                case 33:
                    Tools.RotateCube(cube, 2, 315);
                    return Tools.YPerm(Constants.F2LAlgs[315]);
                case 45:
                    Tools.RotateCube(cube, 2, 316);
                    return Tools.YPerm(Constants.F2LAlgs[316]);
                case 35:
                    Tools.RotateCube(cube, 2, 317);
                    return Tools.YPerm(Constants.F2LAlgs[317]);
                case 6:
                    Tools.RotateCube(cube, 2, 318);
                    return Tools.YPerm(Constants.F2LAlgs[318]);
                case 47:
                    Tools.RotateCube(cube, 2, 319);
                    return Tools.YPerm(Constants.F2LAlgs[319]);
                case 2:
                    Tools.RotateCube(cube, 2, 332);
                    return Tools.YPerm(Constants.F2LAlgs[332]);
                case 38:
                    Tools.RotateCube(cube, 2, 333);
                    return Tools.YPerm(Constants.F2LAlgs[333]);
                case 9:
                    Tools.RotateCube(cube, 2, 334);
                    return Tools.YPerm(Constants.F2LAlgs[334]);
                case 11:
                    Tools.RotateCube(cube, 2, 323);
                    return Tools.YPerm(Constants.F2LAlgs[323]);
                case 36:
                    Tools.RotateCube(cube, 2, 324);
                    return Tools.YPerm(Constants.F2LAlgs[324]);
                case 18:
                    Tools.RotateCube(cube, 2, 325);
                    return Tools.YPerm(Constants.F2LAlgs[325]);
                case 20:
                    Tools.RotateCube(cube, 2, 326);
                    return Tools.YPerm(Constants.F2LAlgs[326]);
                case 42:
                    Tools.RotateCube(cube, 2, 327);
                    return Tools.YPerm(Constants.F2LAlgs[327]);
                case 27:
                    Tools.RotateCube(cube, 2, 328);
                    return Tools.YPerm(Constants.F2LAlgs[328]);
                case 29:
                    Tools.RotateCube(cube, 2, 329);
                    return Tools.YPerm(Constants.F2LAlgs[329]);
                case 44:
                    Tools.RotateCube(cube, 2, 330);
                    return Tools.YPerm(Constants.F2LAlgs[330]);
                case 0:
                    Tools.RotateCube(cube, 2, 331);
                    return Tools.YPerm(Constants.F2LAlgs[331]);
                }
                break;
            }
            return string.Empty;
        }

        private static void AssignCorner(int p){
            switch(p){
            case 0:
                cc1 = 29;
                cc2 = 44;
                break;
            case 2:
                cc1 = 9;
                cc2 = 38;
                break;
            case 6:
                cc1 = 35;
                cc2 = 47;
                break;
            case 8:
                cc1 = 15;
                cc2 = 53;
                break;
            case 9:
                cc1 = 2;
                cc2 = 38;
                break;
            case 11:
                cc1 = 36;
                cc2 = 18;
                break;
            case 15:
                cc1 = 8;
                cc2 = 53;
                break;
            case 17:
                cc1 = 24;
                cc2 = 51;
                break;
            case 18:
                cc1 = 36;
                cc2 = 11;
                break;
            case 20:
                cc1 = 42;
                cc2 = 27;
                break;
            case 24:
                cc1 = 17;
                cc2 = 51;
                break;
            case 26:
                cc1 = 33;
                cc2 = 45;
                break;
            case 27:
                cc1 = 20;
                cc2 = 42;
                break;
            case 29:
                cc1 = 0;
                cc2 = 44;
                break;
            case 33:
                cc1 = 26;
                cc2 = 45;
                break;
            case 35:
                cc1 = 6;
                cc2 = 47;
                break;
            case 36:
                cc1 = 18;
                cc2 = 11;
                break;
            case 38:
                cc1 = 2;
                cc2 = 9;
                break;
            case 42:
                cc1 = 20;
                cc2 = 27;
                break;
            case 44:
                cc1 = 29;
                cc2 = 0;
                break;
            case 45:
                cc1 = 26;
                cc2 = 33;
                break;
            case 47:
                cc1 = 35;
                cc2 = 6;
                break;
            case 51:
                cc1 = 24;
                cc2 = 17;
                break;
            case 53:
                cc1 = 8;
                cc2 = 15;
                break;
            }
        }
    }
}
