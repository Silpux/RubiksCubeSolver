using System;
using System.Collections;

namespace KociembaSolver{

    public class FaceCube{
        public CubeColor[] f = new CubeColor[54];

        public static Facelet[][] cornerFacelet = new Facelet[8][]{
            new Facelet[3]{
                Facelet.U9,
                Facelet.R1,
                Facelet.F3
            },
            new Facelet[3]{
                Facelet.U7,
                Facelet.F1,
                Facelet.L3
            },
            new Facelet[3]{
                Facelet.U1,
                Facelet.L1,
                Facelet.B3
            },
            new Facelet[3]{
                Facelet.U3,
                Facelet.B1,
                Facelet.R3
            },
            new Facelet[3]{
                Facelet.D3,
                Facelet.F9,
                Facelet.R7
            },
            new Facelet[3]{
                Facelet.D1,
                Facelet.L9,
                Facelet.F7
            },
            new Facelet[3]{
                Facelet.D7,
                Facelet.B9,
                Facelet.L7
            },
            new Facelet[3]{
                Facelet.D9,
                Facelet.R9,
                Facelet.B7
            }
        };

        public static Facelet[][] edgeFacelet = new Facelet[12][]{
            new Facelet[2]{
                Facelet.U6,
                Facelet.R2
            },
            new Facelet[2]{
                Facelet.U8,
                Facelet.F2
            },
            new Facelet[2]{
                Facelet.U4,
                Facelet.L2
            },
            new Facelet[2]{
                Facelet.U2,
                Facelet.B2
            },
            new Facelet[2]{
                Facelet.D6,
                Facelet.R8
            },
            new Facelet[2]{
                Facelet.D2,
                Facelet.F8
            },
            new Facelet[2]{
                Facelet.D4,
                Facelet.L8
            },
            new Facelet[2]{
                Facelet.D8,
                Facelet.B8
            },
            new Facelet[2]{
                Facelet.F6,
                Facelet.R4
            },
            new Facelet[2]{
                Facelet.F4,
                Facelet.L6
            },
            new Facelet[2]{
                Facelet.B6,
                Facelet.L4
            },
            new Facelet[2]{
                Facelet.B4,
                Facelet.R6
            }
        };

        public static CubeColor[][] cornerColor = new CubeColor[8][]{
            new CubeColor[3]{
                CubeColor.U,
                CubeColor.R,
                CubeColor.F
            },
            new CubeColor[3]{
                CubeColor.U,
                CubeColor.F,
                CubeColor.L
            },
            new CubeColor[3]{
                CubeColor.U,
                CubeColor.L,
                CubeColor.B
            },
            new CubeColor[3]{
                CubeColor.U,
                CubeColor.B,
                CubeColor.R
            },
            new CubeColor[3]{
                CubeColor.D,
                CubeColor.F,
                CubeColor.R
            },
            new CubeColor[3]{
                CubeColor.D,
                CubeColor.L,
                CubeColor.F
            },
            new CubeColor[3]{
                CubeColor.D,
                CubeColor.B,
                CubeColor.L
            },
            new CubeColor[3]{
                CubeColor.D,
                CubeColor.R,
                CubeColor.B
            }
        };

        public static CubeColor[][] edgeColor = new CubeColor[12][]{
            new CubeColor[2]{
                CubeColor.U,
                CubeColor.R
            },
            new CubeColor[2]{
                CubeColor.U,
                CubeColor.F
            },
            new CubeColor[2]{
                CubeColor.U,
                CubeColor.L
            },
            new CubeColor[2]{
                CubeColor.U,
                CubeColor.B
            },
            new CubeColor[2]{
                CubeColor.D,
                CubeColor.R
            },
            new CubeColor[2]{
                CubeColor.D,
                CubeColor.F
            },
            new CubeColor[2]{
                CubeColor.D,
                CubeColor.L
            },
            new CubeColor[2]{
                CubeColor.D,
                CubeColor.B
            },
            new CubeColor[2]{
                CubeColor.F,
                CubeColor.R
            },
            new CubeColor[2]{
                CubeColor.F,
                CubeColor.L
            },
            new CubeColor[2]{
                CubeColor.B,
                CubeColor.L
            },
            new CubeColor[2]{
                CubeColor.B,
                CubeColor.R
            }
        };

        public FaceCube(){
            string s = "UUUUUUUUURRRRRRRRRFFFFFFFFFDDDDDDDDDLLLLLLLLLBBBBBBBBB";
            for(int i = 0; i < 54; i++){
                CubeColor col = Enum.Parse<CubeColor>(s[i].ToString());
                f[i] = col;
            }
        }

        public FaceCube(string cubeString){
            for(int i = 0; i < cubeString.Length; i++){
                CubeColor col = Enum.Parse<CubeColor>(cubeString[i].ToString());
                f[i] = col;
            }
        }

        public string ToFcString(){
            string s = "";
            for(int i = 0; i < 54; i++){
                s += f[i];
            }
            return s;
        }

        public CubieCube ToCubieCube(){
            CubieCube ccRet = new();
            for(int i = 0; i < 8; i++){
                ccRet.cp[i] = Corner.URF;
            }
            for(int k = 0; k < 12; k++){
                ccRet.ep[k] = Edge.UR;
            }
            Corner[] array = (Corner[])Enum.GetValues(typeof(Corner));
            foreach(Corner j in array){
                byte ori = 0;
                while(ori < 3 && f[(int)cornerFacelet[(int)j][ori]] != 0 && f[(int)cornerFacelet[(int)j][ori]] != CubeColor.D){
                    ori = (byte)(ori + 1);
                }
                CubeColor col1 = f[(int)cornerFacelet[(int)j][(ori + 1) % 3]];
                CubeColor col2 = f[(int)cornerFacelet[(int)j][(ori + 2) % 3]];
                Corner[] array2 = (Corner[])Enum.GetValues(typeof(Corner));
                foreach(Corner m in array2){
                    if(col1 == cornerColor[(int)m][1] && col2 == cornerColor[(int)m][2]){
                        ccRet.cp[(int)j] = m;
                        ccRet.co[(int)j] = (byte)(ori % 3);
                        break;
                    }
                }
            }
            Edge[] array3 = (Edge[])Enum.GetValues(typeof(Edge));
            foreach(Edge l in array3){
                Edge[] array4 = (Edge[])Enum.GetValues(typeof(Edge));
                foreach(Edge n in array4){
                    if(f[(int)edgeFacelet[(int)l][0]] == edgeColor[(int)n][0] && f[(int)edgeFacelet[(int)l][1]] == edgeColor[(int)n][1]){
                        ccRet.ep[(int)l] = n;
                        ccRet.eo[(int)l] = 0;
                        break;
                    }
                    if(f[(int)edgeFacelet[(int)l][0]] == edgeColor[(int)n][1] && f[(int)edgeFacelet[(int)l][1]] == edgeColor[(int)n][0]){
                        ccRet.ep[(int)l] = n;
                        ccRet.eo[(int)l] = 1;
                        break;
                    }
                }
            }
            return ccRet;
        }
    }
}
