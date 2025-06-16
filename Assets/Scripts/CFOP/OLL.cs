using System;

namespace CFOPSolver{

    internal static class OLL{
        public static string Solve(char[] cube){

            int[] yellowPostionsAtOLL = new int[20];
            int c = 0;
            for(int i = 0; i < 20; i++){
                if(cube[Constants.YellowEdges[i]] == 'U'){
                    yellowPostionsAtOLL[c++] = Constants.YellowEdges[i];
                }
            }
            if(c != 8){
                throw new ArgumentException("OLL: Couldn't find 8 pieces of last layer color");
            }
            else if(cube[36] != 'U' || cube[37] != 'U' || cube[38] != 'U' || cube[39] != 'U' || cube[41] != 'U' || cube[42] != 'U' || cube[43] != 'U' || cube[44] != 'U'){
                return MoveOLL(cube, yellowPostionsAtOLL);
            }
            return string.Empty;
        }

        private static string MoveOLL(char[] cube, int[] yellowPositions){
            for(int i = 0; i < 232; i++){
                if(i + 1 == 29 || i + 1 == 30 || i + 1 == 31 || i + 1 == 32){
                    continue;
                }
                int c = 0;
                for(int j = 0; j < 8; j++){
                    for(int k = 0; k < 8; k++){
                        if(Constants.OLLCapsules[i, j] == yellowPositions[k]){
                            c++;
                        }
                    }
                }
                if(c == 8){
                    switch((i + 1) % 4){
                    case 1:
                        Tools.RotateCube(cube, 7, i / 4);
                        return Constants.OLLAlgs[i / 4];
                    case 2:
                        Tools.RotateCube(cube, 8, i / 4);
                        return Tools.YPerm(Constants.OLLAlgs[i / 4]);
                    case 3:
                        Tools.RotateCube(cube, 9, i / 4);
                        return Tools.Y2Perm(Constants.OLLAlgs[i / 4]);
                    case 0:
                        Tools.RotateCube(cube, 6, i / 4);
                        return Tools.YdPerm(Constants.OLLAlgs[i / 4]);
                    }
                }
            }
            return string.Empty;
        }
    }
}
