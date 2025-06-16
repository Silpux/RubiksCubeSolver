using System;

namespace CFOPSolver{

    internal static class PLL{
        public static string Solve(char[] cube){
            string solution = string.Empty;
            int[,] yellowPositions = new int[4, 3];
            int c = 0;
            try{
                for(int i = 0, j = 0; i < 12; i++){
                    if(cube[Constants.YellowEdges[i]] == 'F'){
                        yellowPositions[0, j++] = Constants.YellowEdges[i];
                        c++;
                    }
                }
                for(int i = 0, j = 0; i < 12; i++){
                    if(cube[Constants.YellowEdges[i]] == 'R'){
                        yellowPositions[1, j++] = Constants.YellowEdges[i];
                        c++;
                    }
                }
                for(int i = 0, j = 0; i < 12; i++){
                    if(cube[Constants.YellowEdges[i]] == 'B'){
                        yellowPositions[2, j++] = Constants.YellowEdges[i];
                        c++;
                    }
                }
                for(int i = 0, j = 0; i < 12; i++){
                    if(cube[Constants.YellowEdges[i]] == 'L'){
                        yellowPositions[3, j++] = Constants.YellowEdges[i];
                        c++;
                    }
                }
            }
            catch(IndexOutOfRangeException){
                throw new ArgumentException("PLL: Cannot identify PLL case");
            }
            if(c != 12){
                throw new ArgumentException("PLL: The cube is not in valid state for PLL phase!");
            }
            if(cube[0] != 'F' || cube[1] != 'F' || cube[2] != 'F' || cube[9] != 'R' || cube[10] != 'R' || cube[11] != 'R' || cube[18] != 'B' || cube[19] != 'B' || cube[20] != 'B' || cube[27] != 'L' || cube[28] != 'L' || cube[29] != '\u0004'){
                solution += MovePLL(cube, yellowPositions);
            }

            switch(cube[1]){
            case 'L':
                solution += " U";
                Tools.RotateCube(cube, 0, 0);
                break;
            case 'R':
                solution += " U'";
                Tools.RotateCube(cube, 0, 1);
                break;
            case 'B':
                solution += " U2";
                Tools.RotateCube(cube, 0, 2);
                break;
            }

            return solution;
        }

        private static string MovePLL(char[] cube, int[,] yellowPositions){
            string solution = "";
            for(int i = 0; i < 88; i++){
                int j = 0;
                int c = 0;
                for(; j < 4; j++){
                    for(int k = 0; k < 4; k++){
                        int ac = 0;
                        for(int l = 0; l < 3; l++){
                            for(int m = 0; m < 3; m++){
                                if(Constants.PLLCapsules[i, j, l] == yellowPositions[k, m]){
                                    ac++;
                                }
                            }
                        }
                        if(ac == 3){
                            c++;
                        }
                    }
                    if(c == 4){
                        switch((i + 1) % 4){
                        case 1:
                            Tools.RotateCube(cube, 11, i / 4);
                            return " " + Constants.PLLAlgs[i / 4];
                        case 2:
                            Tools.RotateCube(cube, 12, i / 4);
                            return " U " + Constants.PLLAlgs[i / 4];
                        case 3:
                            Tools.RotateCube(cube, 13, i / 4);
                            return " U2 " + Constants.PLLAlgs[i / 4];
                        case 0:
                            Tools.RotateCube(cube, 10, i / 4);
                            return " U' " + Constants.PLLAlgs[i / 4];
                        }
                    }
                }
            }
            return solution;
        }
    }
}
