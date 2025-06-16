using System;

namespace CFOPSolver{

    internal static class Cross{
        public static string Solve(char[] cube){

            string solution = string.Empty;
            int i = 0;
            int c = 0;
            for(; i < 24; i++){
                if(cube[Constants.EdgePositions[i]] == 'D'){
                    c++;
                }
            }
            if(c != 4){
                throw new ArgumentException("Cross: Count of edge elements for cross is not 4!");
            }
            for(i = 0; i < 24; i++){
                if(cube[50] == 'D' && cube[7] == 'F'){
                    break;
                }
                if(cube[Constants.EdgePositions[i]] == 'D' && cube[Tools.ConjugateEdge(Constants.EdgePositions[i])] == 'F'){
                    solution += MoveCross(cube, 2, Constants.EdgePositions[i]);
                    break;
                }
            }
            for(i = 0; i < 24; i++){
                if(cube[52] == 'D' && cube[16] == 'R'){
                    break;
                }
                if(cube[Constants.EdgePositions[i]] == 'D' && cube[Tools.ConjugateEdge(Constants.EdgePositions[i])] == 'R'){
                    solution += MoveCross(cube, 12, Constants.EdgePositions[i]);
                    break;
                }
            }
            for(i = 0; i < 24; i++){
                if(cube[48] == 'D' && cube[25] == 'B'){
                    break;
                }
                if(cube[Constants.EdgePositions[i]] == 'D' && cube[Tools.ConjugateEdge(Constants.EdgePositions[i])] == 'B'){
                    solution += MoveCross(cube, 1, Constants.EdgePositions[i]);
                    break;
                }
            }
            for(i = 0; i < 24; i++){
                if(cube[46] == 'D' && cube[34] == 'L'){
                    break;
                }
                if(cube[Constants.EdgePositions[i]] == 'D' && cube[Tools.ConjugateEdge(Constants.EdgePositions[i])] == 'L'){
                    solution += MoveCross(cube, 4, Constants.EdgePositions[i]);
                    break;
                }
            }
            return solution;
        }

        private static string MoveCross(char[] cube, int Face, int WhiteEdge){
            switch(Face){
            case 2:
                switch(WhiteEdge){
                case 1:
                    Tools.RotateCube(cube, 1, 23);
                    return Constants.crossAlgs[23];
                case 41:
                    Tools.RotateCube(cube, 1, 24);
                    return Constants.crossAlgs[24];
                case 10:
                    Tools.RotateCube(cube, 1, 25);
                    return Constants.crossAlgs[25];
                case 37:
                    Tools.RotateCube(cube, 1, 26);
                    return Constants.crossAlgs[26];
                case 19:
                    Tools.RotateCube(cube, 1, 27);
                    return Constants.crossAlgs[27];
                case 39:
                    Tools.RotateCube(cube, 1, 28);
                    return Constants.crossAlgs[28];
                case 28:
                    Tools.RotateCube(cube, 1, 29);
                    return Constants.crossAlgs[29];
                case 43:
                    Tools.RotateCube(cube, 1, 30);
                    return Constants.crossAlgs[30];
                case 5:
                    Tools.RotateCube(cube, 1, 31);
                    return Constants.crossAlgs[31];
                case 12:
                    Tools.RotateCube(cube, 1, 32);
                    return Constants.crossAlgs[32];
                case 14:
                    Tools.RotateCube(cube, 1, 33);
                    return Constants.crossAlgs[33];
                case 21:
                    Tools.RotateCube(cube, 1, 34);
                    return Constants.crossAlgs[34];
                case 23:
                    Tools.RotateCube(cube, 1, 35);
                    return Constants.crossAlgs[35];
                case 30:
                    Tools.RotateCube(cube, 1, 36);
                    return Constants.crossAlgs[36];
                case 32:
                    Tools.RotateCube(cube, 1, 37);
                    return Constants.crossAlgs[37];
                case 3:
                    Tools.RotateCube(cube, 1, 38);
                    return Constants.crossAlgs[38];
                case 7:
                    Tools.RotateCube(cube, 1, 39);
                    return Constants.crossAlgs[39];
                case 16:
                    Tools.RotateCube(cube, 1, 40);
                    return Constants.crossAlgs[40];
                case 52:
                    Tools.RotateCube(cube, 1, 41);
                    return Constants.crossAlgs[41];
                case 25:
                    Tools.RotateCube(cube, 1, 42);
                    return Constants.crossAlgs[42];
                case 48:
                    Tools.RotateCube(cube, 1, 43);
                    return Constants.crossAlgs[43];
                case 34:
                    Tools.RotateCube(cube, 1, 44);
                    return Constants.crossAlgs[44];
                case 46:
                    Tools.RotateCube(cube, 1, 45);
                    return Constants.crossAlgs[45];
                }
                break;
            case 12:
                switch(WhiteEdge){
                case 1:
                    Tools.RotateCube(cube, 1, 0);
                    return Constants.crossAlgs[0];
                case 41:
                    Tools.RotateCube(cube, 1, 1);
                    return Constants.crossAlgs[1];
                case 10:
                    Tools.RotateCube(cube, 1, 2);
                    return Constants.crossAlgs[2];
                case 37:
                    Tools.RotateCube(cube, 1, 3);
                    return Constants.crossAlgs[3];
                case 19:
                    Tools.RotateCube(cube, 1, 4);
                    return Constants.crossAlgs[4];
                case 39:
                    Tools.RotateCube(cube, 1, 5);
                    return Constants.crossAlgs[5];
                case 28:
                    Tools.RotateCube(cube, 1, 6);
                    return Constants.crossAlgs[6];
                case 43:
                    Tools.RotateCube(cube, 1, 7);
                    return Constants.crossAlgs[7];
                case 5:
                    Tools.RotateCube(cube, 1, 8);
                    return Constants.crossAlgs[8];
                case 12:
                    Tools.RotateCube(cube, 1, 9);
                    return Constants.crossAlgs[9];
                case 14:
                    Tools.RotateCube(cube, 1, 10);
                    return Constants.crossAlgs[10];
                case 21:
                    Tools.RotateCube(cube, 1, 11);
                    return Constants.crossAlgs[11];
                case 23:
                    Tools.RotateCube(cube, 1, 12);
                    return Constants.crossAlgs[12];
                case 30:
                    Tools.RotateCube(cube, 1, 13);
                    return Constants.crossAlgs[13];
                case 32:
                    Tools.RotateCube(cube, 1, 14);
                    return Constants.crossAlgs[14];
                case 3:
                    Tools.RotateCube(cube, 1, 15);
                    return Constants.crossAlgs[15];
                case 7:
                    Tools.RotateCube(cube, 1, 16);
                    return Constants.crossAlgs[16];
                case 50:
                    Tools.RotateCube(cube, 1, 17);
                    return Constants.crossAlgs[17];
                case 16:
                    Tools.RotateCube(cube, 1, 18);
                    return Constants.crossAlgs[18];
                case 25:
                    Tools.RotateCube(cube, 1, 19);
                    return Constants.crossAlgs[19];
                case 48:
                    Tools.RotateCube(cube, 1, 20);
                    return Constants.crossAlgs[20];
                case 34:
                    Tools.RotateCube(cube, 1, 21);
                    return Constants.crossAlgs[21];
                case 46:
                    Tools.RotateCube(cube, 1, 22);
                    return Constants.crossAlgs[22];
                }
                break;
            case 1:
                switch(WhiteEdge){
                case 1:
                    Tools.RotateCube(cube, 1, 46);
                    return Constants.crossAlgs[46];
                case 41:
                    Tools.RotateCube(cube, 1, 47);
                    return Constants.crossAlgs[47];
                case 10:
                    Tools.RotateCube(cube, 1, 48);
                    return Constants.crossAlgs[48];
                case 37:
                    Tools.RotateCube(cube, 1, 49);
                    return Constants.crossAlgs[49];
                case 19:
                    Tools.RotateCube(cube, 1, 50);
                    return Constants.crossAlgs[50];
                case 39:
                    Tools.RotateCube(cube, 1, 51);
                    return Constants.crossAlgs[51];
                case 28:
                    Tools.RotateCube(cube, 1, 52);
                    return Constants.crossAlgs[52];
                case 43:
                    Tools.RotateCube(cube, 1, 53);
                    return Constants.crossAlgs[53];
                case 5:
                    Tools.RotateCube(cube, 1, 54);
                    return Constants.crossAlgs[54];
                case 12:
                    Tools.RotateCube(cube, 1, 55);
                    return Constants.crossAlgs[55];
                case 14:
                    Tools.RotateCube(cube, 1, 56);
                    return Constants.crossAlgs[56];
                case 21:
                    Tools.RotateCube(cube, 1, 57);
                    return Constants.crossAlgs[57];
                case 23:
                    Tools.RotateCube(cube, 1, 58);
                    return Constants.crossAlgs[58];
                case 30:
                    Tools.RotateCube(cube, 1, 59);
                    return Constants.crossAlgs[59];
                case 32:
                    Tools.RotateCube(cube, 1, 60);
                    return Constants.crossAlgs[60];
                case 3:
                    Tools.RotateCube(cube, 1, 61);
                    return Constants.crossAlgs[61];
                case 7:
                    Tools.RotateCube(cube, 1, 62);
                    return Constants.crossAlgs[62];
                case 50:
                    Tools.RotateCube(cube, 1, 63);
                    return Constants.crossAlgs[63];
                case 16:
                    Tools.RotateCube(cube, 1, 64);
                    return Constants.crossAlgs[64];
                case 52:
                    Tools.RotateCube(cube, 1, 65);
                    return Constants.crossAlgs[65];
                case 25:
                    Tools.RotateCube(cube, 1, 66);
                    return Constants.crossAlgs[66];
                case 34:
                    Tools.RotateCube(cube, 1, 67);
                    return Constants.crossAlgs[67];
                case 46:
                    Tools.RotateCube(cube, 1, 68);
                    return Constants.crossAlgs[68];
                }
                break;
            case 4:
                switch(WhiteEdge){
                case 1:
                    Tools.RotateCube(cube, 1, 69);
                    return Constants.crossAlgs[69];
                case 41:
                    Tools.RotateCube(cube, 1, 70);
                    return Constants.crossAlgs[70];
                case 10:
                    Tools.RotateCube(cube, 1, 71);
                    return Constants.crossAlgs[71];
                case 37:
                    Tools.RotateCube(cube, 1, 72);
                    return Constants.crossAlgs[72];
                case 19:
                    Tools.RotateCube(cube, 1, 73);
                    return Constants.crossAlgs[73];
                case 39:
                    Tools.RotateCube(cube, 1, 74);
                    return Constants.crossAlgs[74];
                case 28:
                    Tools.RotateCube(cube, 1, 75);
                    return Constants.crossAlgs[75];
                case 43:
                    Tools.RotateCube(cube, 1, 76);
                    return Constants.crossAlgs[76];
                case 5:
                    Tools.RotateCube(cube, 1, 77);
                    return Constants.crossAlgs[77];
                case 12:
                    Tools.RotateCube(cube, 1, 78);
                    return Constants.crossAlgs[78];
                case 14:
                    Tools.RotateCube(cube, 1, 79);
                    return Constants.crossAlgs[79];
                case 21:
                    Tools.RotateCube(cube, 1, 80);
                    return Constants.crossAlgs[80];
                case 23:
                    Tools.RotateCube(cube, 1, 81);
                    return Constants.crossAlgs[81];
                case 30:
                    Tools.RotateCube(cube, 1, 82);
                    return Constants.crossAlgs[82];
                case 32:
                    Tools.RotateCube(cube, 1, 83);
                    return Constants.crossAlgs[83];
                case 3:
                    Tools.RotateCube(cube, 1, 84);
                    return Constants.crossAlgs[84];
                case 7:
                    Tools.RotateCube(cube, 1, 85);
                    return Constants.crossAlgs[85];
                case 50:
                    Tools.RotateCube(cube, 1, 86);
                    return Constants.crossAlgs[86];
                case 16:
                    Tools.RotateCube(cube, 1, 87);
                    return Constants.crossAlgs[87];
                case 52:
                    Tools.RotateCube(cube, 1, 88);
                    return Constants.crossAlgs[88];
                case 25:
                    Tools.RotateCube(cube, 1, 89);
                    return Constants.crossAlgs[89];
                case 48:
                    Tools.RotateCube(cube, 1, 90);
                    return Constants.crossAlgs[90];
                case 34:
                    Tools.RotateCube(cube, 1, 91);
                    return Constants.crossAlgs[91];
                }
                break;
            }

            return string.Empty;
        }
    }

}