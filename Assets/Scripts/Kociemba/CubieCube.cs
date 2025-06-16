using System;

namespace KociembaSolver{

    public class CubieCube{

        public Corner[] cp = new Corner[8]{
            Corner.URF,
            Corner.UFL,
            Corner.ULB,
            Corner.UBR,
            Corner.DFR,
            Corner.DLF,
            Corner.DBL,
            Corner.DRB
        };

        public byte[] co = new byte[8];

        public Edge[] ep = new Edge[12]{
            Edge.UR,
            Edge.UF,
            Edge.UL,
            Edge.UB,
            Edge.DR,
            Edge.DF,
            Edge.DL,
            Edge.DB,
            Edge.FR,
            Edge.FL,
            Edge.BL,
            Edge.BR
        };

        public byte[] eo = new byte[12];

        private static Corner[] cpU = new Corner[8]{
            Corner.UBR,
            Corner.URF,
            Corner.UFL,
            Corner.ULB,
            Corner.DFR,
            Corner.DLF,
            Corner.DBL,
            Corner.DRB
        };

        private static byte[] coU = new byte[8];

        private static Edge[] epU = new Edge[12]{
            Edge.UB,
            Edge.UR,
            Edge.UF,
            Edge.UL,
            Edge.DR,
            Edge.DF,
            Edge.DL,
            Edge.DB,
            Edge.FR,
            Edge.FL,
            Edge.BL,
            Edge.BR
        };

        private static byte[] eoU = new byte[12];

        private static Corner[] cpR = new Corner[8]{
            Corner.DFR,
            Corner.UFL,
            Corner.ULB,
            Corner.URF,
            Corner.DRB,
            Corner.DLF,
            Corner.DBL,
            Corner.UBR
        };

        private static byte[] coR = new byte[8] { 2, 0, 0, 1, 1, 0, 0, 2 };

        private static Edge[] epR = new Edge[12]{
            Edge.FR,
            Edge.UF,
            Edge.UL,
            Edge.UB,
            Edge.BR,
            Edge.DF,
            Edge.DL,
            Edge.DB,
            Edge.DR,
            Edge.FL,
            Edge.BL,
            Edge.UR
        };

        private static byte[] eoR = new byte[12];

        private static Corner[] cpF = new Corner[8]{
            Corner.UFL,
            Corner.DLF,
            Corner.ULB,
            Corner.UBR,
            Corner.URF,
            Corner.DFR,
            Corner.DBL,
            Corner.DRB
        };

        private static byte[] coF = new byte[8] { 1, 2, 0, 0, 2, 1, 0, 0 };

        private static Edge[] epF = new Edge[12]{
            Edge.UR,
            Edge.FL,
            Edge.UL,
            Edge.UB,
            Edge.DR,
            Edge.FR,
            Edge.DL,
            Edge.DB,
            Edge.UF,
            Edge.DF,
            Edge.BL,
            Edge.BR
        };

        private static byte[] eoF = new byte[12]{
            0, 1, 0, 0, 0, 1, 0, 0, 1, 1,
            0, 0
        };

        private static Corner[] cpD = new Corner[8]{
            Corner.URF,
            Corner.UFL,
            Corner.ULB,
            Corner.UBR,
            Corner.DLF,
            Corner.DBL,
            Corner.DRB,
            Corner.DFR
        };

        private static byte[] coD = new byte[8];

        private static Edge[] epD = new Edge[12]{
            Edge.UR,
            Edge.UF,
            Edge.UL,
            Edge.UB,
            Edge.DF,
            Edge.DL,
            Edge.DB,
            Edge.DR,
            Edge.FR,
            Edge.FL,
            Edge.BL,
            Edge.BR
        };

        private static byte[] eoD = new byte[12];

        private static Corner[] cpL = new Corner[8]{
            Corner.URF,
            Corner.ULB,
            Corner.DBL,
            Corner.UBR,
            Corner.DFR,
            Corner.UFL,
            Corner.DLF,
            Corner.DRB
        };

        private static byte[] coL = new byte[8] { 0, 1, 2, 0, 0, 2, 1, 0 };

        private static Edge[] epL = new Edge[12]{
            Edge.UR,
            Edge.UF,
            Edge.BL,
            Edge.UB,
            Edge.DR,
            Edge.DF,
            Edge.FL,
            Edge.DB,
            Edge.FR,
            Edge.UL,
            Edge.DL,
            Edge.BR
        };

        private static byte[] eoL = new byte[12];

        private static Corner[] cpB = new Corner[8]{
            Corner.URF,
            Corner.UFL,
            Corner.UBR,
            Corner.DRB,
            Corner.DFR,
            Corner.DLF,
            Corner.ULB,
            Corner.DBL
        };

        private static byte[] coB = new byte[8] { 0, 0, 1, 2, 0, 0, 2, 1 };

        private static Edge[] epB = new Edge[12]{
            Edge.UR,
            Edge.UF,
            Edge.UL,
            Edge.BR,
            Edge.DR,
            Edge.DF,
            Edge.DL,
            Edge.BL,
            Edge.FR,
            Edge.FL,
            Edge.UB,
            Edge.DB
        };

        private static byte[] eoB = new byte[12]{
            0, 0, 0, 1, 0, 0, 0, 1, 0, 0,
            1, 1
        };

        public static CubieCube[] moveCube = new CubieCube[6]{
            SetMoveU(),
            SetMoveR(),
            SetMoveF(),
            SetMoveD(),
            SetMoveL(),
            SetMoveB()
        };

        private static CubieCube SetMoveU(){
            CubieCube move = new CubieCube();
            move.cp = cpU;
            move.co = coU;
            move.ep = epU;
            move.eo = eoU;
            return move;
        }

        private static CubieCube SetMoveR(){
            CubieCube move = new CubieCube();
            move.cp = cpR;
            move.co = coR;
            move.ep = epR;
            move.eo = eoR;
            return move;
        }

        private static CubieCube SetMoveF(){
            CubieCube move = new CubieCube();
            move.cp = cpF;
            move.co = coF;
            move.ep = epF;
            move.eo = eoF;
            return move;
        }

        private static CubieCube SetMoveD(){
            CubieCube move = new CubieCube();
            move.cp = cpD;
            move.co = coD;
            move.ep = epD;
            move.eo = eoD;
            return move;
        }

        private static CubieCube SetMoveL(){
            CubieCube move = new CubieCube();
            move.cp = cpL;
            move.co = coL;
            move.ep = epL;
            move.eo = eoL;
            return move;
        }

        private static CubieCube SetMoveB(){
            CubieCube move = new CubieCube();
            move.cp = cpB;
            move.co = coB;
            move.ep = epB;
            move.eo = eoB;
            return move;
        }

        public CubieCube(){
        }

        public CubieCube(Corner[] cp, byte[] co, Edge[] ep, byte[] eo){
            for(int j = 0; j < 8; j++){
                this.cp[j] = cp[j];
                this.co[j] = co[j];
            }
            for(int i = 0; i < 12; i++){
                this.ep[i] = ep[i];
                this.eo[i] = eo[i];
            }
        }

        private static int Cnk(int n, int k){
            if(n < k){
                return 0;
            }
            if(k > n / 2){
                k = n - k;
            }
            int s = 1;
            int i = n;
            int j = 1;
            while(i != n - k){
                s *= i;
                s /= j;
                i--;
                j++;
            }
            return s;
        }

        private static void RotateLeft(Corner[] arr, int l, int r){
            Corner temp = arr[l];
            for(int i = l; i < r; i++){
                arr[i] = arr[i + 1];
            }
            arr[r] = temp;
        }

        private static void RotateRight(Corner[] arr, int l, int r){
            Corner temp = arr[r];
            for(int i = r; i > l; i--){
                arr[i] = arr[i - 1];
            }
            arr[l] = temp;
        }

        private static void RotateLeft(Edge[] arr, int l, int r){
            Edge temp = arr[l];
            for(int i = l; i < r; i++){
                arr[i] = arr[i + 1];
            }
            arr[r] = temp;
        }

        private static void RotateRight(Edge[] arr, int l, int r){
            Edge temp = arr[r];
            for(int i = r; i > l; i--){
                arr[i] = arr[i - 1];
            }
            arr[l] = temp;
        }

        public FaceCube ToFaceCube(){
            FaceCube fcRet = new FaceCube();
            Corner[] array = (Corner[])Enum.GetValues(typeof(Corner));
            foreach(Corner c in array){
                int i = (int)c;
                int k = (int)cp[i];
                byte ori = co[i];
                for(int m = 0; m < 3; m++){
                    fcRet.f[(int)FaceCube.cornerFacelet[i][(m + ori) % 3]] = FaceCube.cornerColor[k][m];
                }
            }
            Edge[] array2 = (Edge[])Enum.GetValues(typeof(Edge));
            foreach(Edge e in array2){
                int j = (int)e;
                int l = (int)ep[j];
                byte ori2 = eo[j];
                for(int n = 0; n < 2; n++){
                    fcRet.f[(int)FaceCube.edgeFacelet[j][(n + ori2) % 2]] = FaceCube.edgeColor[l][n];
                }
            }
            return fcRet;
        }

        public void CornerMultiply(CubieCube b){
            Corner[] cPerm = new Corner[8];
            byte[] cOri = new byte[8];
            Corner[] array = (Corner[])Enum.GetValues(typeof(Corner));
            foreach(Corner corn in array){
                cPerm[(int)corn] = cp[(int)b.cp[(int)corn]];
                byte oriA = co[(int)b.cp[(int)corn]];
                byte oriB = b.co[(int)corn];
                byte ori = 0;
                if(oriA < 3 && oriB < 3){
                    ori = (byte)(oriA + oriB);
                    if(ori >= 3){
                        ori = (byte)(ori - 3);
                    }
                }
                else if(oriA < 3 && oriB >= 3){
                    ori = (byte)(oriA + oriB);
                    if(ori >= 6){
                        ori = (byte)(ori - 3);
                    }
                }
                else if(oriA >= 3 && oriB < 3){
                    ori = (byte)(oriA - oriB);
                    if(ori < 3){
                        ori = (byte)(ori + 3);
                    }
                }
                else if(oriA >= 3 && oriB >= 3){
                    ori = (byte)(oriA - oriB);
                    if(ori < 0){
                        ori = (byte)(ori + 3);
                    }
                }
                cOri[(int)corn] = ori;
            }
            Corner[] array2 = (Corner[])Enum.GetValues(typeof(Corner));
            foreach(Corner c in array2){
                cp[(int)c] = cPerm[(int)c];
                co[(int)c] = cOri[(int)c];
            }
        }

        public void EdgeMultiply(CubieCube b){
            Edge[] ePerm = new Edge[12];
            byte[] eOri = new byte[12];
            Edge[] array = (Edge[])Enum.GetValues(typeof(Edge));
            foreach(Edge edge in array){
                ePerm[(int)edge] = ep[(int)b.ep[(int)edge]];
                eOri[(int)edge] = (byte)((b.eo[(int)edge] + eo[(int)b.ep[(int)edge]]) % 2);
            }
            Edge[] array2 = (Edge[])Enum.GetValues(typeof(Edge));
            foreach(Edge e in array2){
                ep[(int)e] = ePerm[(int)e];
                eo[(int)e] = eOri[(int)e];
            }
        }

        private void Multiply(CubieCube b){
            CornerMultiply(b);
        }

        private void InvCubieCube(CubieCube c){
            Edge[] array = (Edge[])Enum.GetValues(typeof(Edge));
            foreach(Edge edge in array){
                c.ep[(int)ep[(int)edge]] = edge;
            }
            Edge[] array2 = (Edge[])Enum.GetValues(typeof(Edge));
            foreach(Edge edge2 in array2){
                c.eo[(int)edge2] = eo[(int)c.ep[(int)edge2]];
            }
            Corner[] array3 = (Corner[])Enum.GetValues(typeof(Corner));
            foreach(Corner corn in array3){
                c.cp[(int)cp[(int)corn]] = corn;
            }
            Corner[] array4 = (Corner[])Enum.GetValues(typeof(Corner));
            foreach(Corner corn2 in array4){
                byte ori = co[(int)c.cp[(int)corn2]];
                if(ori >= 3){
                    c.co[(int)corn2] = ori;
                    continue;
                }
                c.co[(int)corn2] = (byte)(-ori);
                if(c.co[(int)corn2] < 0){
                    c.co[(int)corn2] += 3;
                }
            }
        }

        public short GetTwist(){
            short ret = 0;
            for(int i = 0; i < 7; i++){
                ret = (short)(3 * ret + co[i]);
            }
            return ret;
        }

        public void SetTwist(short twist){
            int twistParity = 0;
            for(int i = 6; i >= 0; i--){
                int num = twistParity;
                byte b;
                co[i] = (b = (byte)(twist % 3));
                twistParity = num + b;
                twist = (short)(twist / 3);
            }
            co[7] = (byte)((3 - twistParity % 3) % 3);
        }

        public short GetFlip(){
            short ret = 0;
            for(int i = 0; i < 11; i++){
                ret = (short)(2 * ret + eo[i]);
            }
            return ret;
        }

        public void SetFlip(short flip){
            int flipParity = 0;
            for(int i = 10; i >= 0; i--){
                int num = flipParity;
                byte b;
                eo[i] = (b = (byte)(flip % 2));
                flipParity = num + b;
                flip = (short)(flip / 2);
            }
            eo[11] = (byte)((2 - flipParity % 2) % 2);
        }

        public short CornerParity(){
            int s = 0;
            for(int i = 7; i >= 1; i--){
                for(int j = i - 1; j >= 0; j--){
                    if(cp[j] > cp[i]){
                        s++;
                    }
                }
            }
            return (short)(s % 2);
        }

        public short EdgeParity(){
            int s = 0;
            for(int i = 11; i >= 1; i--){
                for(int j = i - 1; j >= 0; j--){
                    if(ep[j] > ep[i]){
                        s++;
                    }
                }
            }
            return (short)(s % 2);
        }

        public short GetFRtoBR(){
            int a = 0;
            int x = 0;
            Edge[] edge4 = new Edge[4];
            for(int i = 11; i >= 0; i--){
                if(Edge.FR <= ep[i] && ep[i] <= Edge.BR){
                    a += Cnk(11 - i, x + 1);
                    edge4[3 - x++] = ep[i];
                }
            }
            int b = 0;
            for(int j = 3; j > 0; j--){
                int k = 0;
                while(edge4[j] != (Edge)(j + 8)){
                    RotateLeft(edge4, 0, j);
                    k++;
                }
                b = (j + 1) * b + k;
            }
            return (short)(24 * a + b);
        }

        public void SetFRtoBR(short idx){
            Edge[] sliceEdge = new Edge[4]{
                Edge.FR,
                Edge.FL,
                Edge.BL,
                Edge.BR
            };
            Edge[] otherEdge = new Edge[8]{
                Edge.UR,
                Edge.UF,
                Edge.UL,
                Edge.UB,
                Edge.DR,
                Edge.DF,
                Edge.DL,
                Edge.DB
            };
            int b = idx % 24;
            int a = idx / 24;
            Edge[] array = (Edge[])Enum.GetValues(typeof(Edge));
            foreach(Edge e in array){
                ep[(int)e] = Edge.DB;
            }
            for(int k = 1; k < 4; k++){
                int l = b % (k + 1);
                b /= k + 1;
                while(l-- > 0){
                    RotateRight(sliceEdge, 0, k);
                }
            }
            int x = 3;
            for(int j = 0; j <= 11; j++){
                if(a - Cnk(11 - j, x + 1) >= 0){
                    ep[j] = sliceEdge[3 - x];
                    a -= Cnk(11 - j, x-- + 1);
                }
            }
            x = 0;
            for(int i = 0; i <= 11; i++){
                if(ep[i] == Edge.DB){
                    ep[i] = otherEdge[x++];
                }
            }
        }

        public short GetURFtoDLF(){
            int a = 0;
            int x = 0;
            Corner[] corner6 = new Corner[6];
            for(int j = 0; j <= 7; j++){
                if(cp[j] <= Corner.DLF){
                    a += Cnk(j, x + 1);
                    corner6[x++] = cp[j];
                }
            }
            int b = 0;
            for(int i = 5; i > 0; i--){
                int k = 0;
                while(corner6[i] != (Corner)i){
                    RotateLeft(corner6, 0, i);
                    k++;
                }
                b = (i + 1) * b + k;
            }
            return (short)(720 * a + b);
        }

        public void SetURFtoDLF(short idx){
            Corner[] corner6 = new Corner[6]{
                Corner.URF,
                Corner.UFL,
                Corner.ULB,
                Corner.UBR,
                Corner.DFR,
                Corner.DLF
            };
            Corner[] otherCorner = new Corner[2]{
                Corner.DBL,
                Corner.DRB
            };
            int b = idx % 720;
            int a = idx / 720;
            Corner[] array = (Corner[])Enum.GetValues(typeof(Corner));
            foreach(Corner c in array){
                cp[(int)c] = Corner.DRB;
            }
            for(int k = 1; k < 6; k++){
                int l = b % (k + 1);
                b /= k + 1;
                while(l-- > 0){
                    RotateRight(corner6, 0, k);
                }
            }
            int x = 5;
            for(int j = 7; j >= 0; j--){
                if(a - Cnk(j, x + 1) >= 0){
                    cp[j] = corner6[x];
                    a -= Cnk(j, x-- + 1);
                }
            }
            x = 0;
            for(int i = 0; i <= 7; i++){
                if(cp[i] == Corner.DRB){
                    cp[i] = otherCorner[x++];
                }
            }
        }

        public int GetURtoDF(){
            int a = 0;
            int x = 0;
            Edge[] edge6 = new Edge[6];
            for(int j = 0; j <= 11; j++){
                if(ep[j] <= Edge.DF){
                    a += Cnk(j, x + 1);
                    edge6[x++] = ep[j];
                }
            }
            int b = 0;
            for(int i = 5; i > 0; i--){
                int k = 0;
                while(edge6[i] != (Edge)i){
                    RotateLeft(edge6, 0, i);
                    k++;
                }
                b = (i + 1) * b + k;
            }
            return 720 * a + b;
        }

        public void SetURtoDF(int idx){
            Edge[] edge6 = new Edge[6]{
                Edge.UR,
                Edge.UF,
                Edge.UL,
                Edge.UB,
                Edge.DR,
                Edge.DF
            };
            Edge[] otherEdge = new Edge[6]{
                Edge.DL,
                Edge.DB,
                Edge.FR,
                Edge.FL,
                Edge.BL,
                Edge.BR
            };
            int b = idx % 720;
            int a = idx / 720;
            Edge[] array = (Edge[])Enum.GetValues(typeof(Edge));
            foreach(Edge e in array){
                ep[(int)e] = Edge.BR;
            }
            for(int k = 1; k < 6; k++){
                int l = b % (k + 1);
                b /= k + 1;
                while(l-- > 0){
                    RotateRight(edge6, 0, k);
                }
            }
            int x = 5;
            for(int j = 11; j >= 0; j--){
                if(a - Cnk(j, x + 1) >= 0){
                    ep[j] = edge6[x];
                    a -= Cnk(j, x-- + 1);
                }
            }
            x = 0;
            for(int i = 0; i <= 11; i++){
                if(ep[i] == Edge.BR){
                    ep[i] = otherEdge[x++];
                }
            }
        }

        public static int GetURtoDF(short idx1, short idx2){
            CubieCube a = new CubieCube();
            CubieCube b = new CubieCube();
            a.SetURtoUL(idx1);
            b.SetUBtoDF(idx2);
            for(int i = 0; i < 8; i++){
                if(a.ep[i] != Edge.BR){
                    if(b.ep[i] != Edge.BR){
                        return -1;
                    }
                    b.ep[i] = a.ep[i];
                }
            }
            return b.GetURtoDF();
        }

        public short GetURtoUL(){
            int a = 0;
            int x = 0;
            Edge[] edge3 = new Edge[3];
            for(int j = 0; j <= 11; j++){
                if(ep[j] <= Edge.UL){
                    a += Cnk(j, x + 1);
                    edge3[x++] = ep[j];
                }
            }
            int b = 0;
            for(int i = 2; i > 0; i--){
                int k = 0;
                while(edge3[i] != (Edge)i){
                    RotateLeft(edge3, 0, i);
                    k++;
                }
                b = (i + 1) * b + k;
            }
            return (short)(6 * a + b);
        }

        public void SetURtoUL(short idx){
            Edge[] edge3 = new Edge[3]{
                Edge.UR,
                Edge.UF,
                Edge.UL
            };
            int b = idx % 6;
            int a = idx / 6;
            Edge[] array = (Edge[])Enum.GetValues(typeof(Edge));
            foreach(Edge e in array){
                ep[(int)e] = Edge.BR;
            }
            for(int j = 1; j < 3; j++){
                int k = b % (j + 1);
                b /= j + 1;
                while(k-- > 0){
                    RotateRight(edge3, 0, j);
                }
            }
            int x = 2;
            for(int i = 11; i >= 0; i--){
                if(a - Cnk(i, x + 1) >= 0){
                    ep[i] = edge3[x];
                    a -= Cnk(i, x-- + 1);
                }
            }
        }

        public short GetUBtoDF(){
            int a = 0;
            int x = 0;
            Edge[] edge3 = new Edge[3];
            for(int j = 0; j <= 11; j++){
                if(Edge.UB <= ep[j] && ep[j] <= Edge.DF){
                    a += Cnk(j, x + 1);
                    edge3[x++] = ep[j];
                }
            }
            int b = 0;
            for(int i = 2; i > 0; i--){
                int k = 0;
                while(edge3[i] != (Edge)(3 + i)){
                    RotateLeft(edge3, 0, i);
                    k++;
                }
                b = (i + 1) * b + k;
            }
            return (short)(6 * a + b);
        }

        public void SetUBtoDF(short idx){
            Edge[] edge3 = new Edge[3]{
                Edge.UB,
                Edge.DR,
                Edge.DF
            };
            int b = idx % 6;
            int a = idx / 6;
            Edge[] array = (Edge[])Enum.GetValues(typeof(Edge));
            foreach(Edge e in array){
                ep[(int)e] = Edge.BR;
            }
            for(int j = 1; j < 3; j++){
                int k = b % (j + 1);
                b /= j + 1;
                while(k-- > 0){
                    RotateRight(edge3, 0, j);
                }
            }
            int x = 2;
            for(int i = 11; i >= 0; i--){
                if(a - Cnk(i, x + 1) >= 0){
                    ep[i] = edge3[x];
                    a -= Cnk(i, x-- + 1);
                }
            }
        }

        private int GetURFtoDLB(){
            Corner[] perm = new Corner[8];
            int b = 0;
            for(int i = 0; i < 8; i++){
                perm[i] = cp[i];
            }
            for(int j = 7; j > 0; j--){
                int k = 0;
                while(perm[j] != (Corner)j){
                    RotateLeft(perm, 0, j);
                    k++;
                }
                b = (j + 1) * b + k;
            }
            return b;
        }

        public void SetURFtoDLB(int idx){
            Corner[] perm = new Corner[8]{
                Corner.URF,
                Corner.UFL,
                Corner.ULB,
                Corner.UBR,
                Corner.DFR,
                Corner.DLF,
                Corner.DBL,
                Corner.DRB
            };
            for(int j = 1; j < 8; j++){
                int k = idx % (j + 1);
                idx /= j + 1;
                while(k-- > 0){
                    RotateRight(perm, 0, j);
                }
            }
            int x = 7;
            for(int i = 7; i >= 0; i--){
                cp[i] = perm[x--];
            }
        }

        private int GetURtoBR(){
            Edge[] perm = new Edge[12];
            int b = 0;
            for(int i = 0; i < 12; i++){
                perm[i] = ep[i];
            }
            for(int j = 11; j > 0; j--){
                int k = 0;
                while(perm[j] != (Edge)j){
                    RotateLeft(perm, 0, j);
                    k++;
                }
                b = (j + 1) * b + k;
            }
            return b;
        }

        public void SetURtoBR(int idx){
            Edge[] perm = new Edge[12]{
                Edge.UR,
                Edge.UF,
                Edge.UL,
                Edge.UB,
                Edge.DR,
                Edge.DF,
                Edge.DL,
                Edge.DB,
                Edge.FR,
                Edge.FL,
                Edge.BL,
                Edge.BR
            };
            for(int j = 1; j < 12; j++){
                int k = idx % (j + 1);
                idx /= j + 1;
                while(k-- > 0){
                    RotateRight(perm, 0, j);
                }
            }
            int x = 11;
            for(int i = 11; i >= 0; i--){
                ep[i] = perm[x--];
            }
        }

        public int Verify(){
            int sum = 0;
            int[] edgeCount = new int[12];
            Edge[] array = (Edge[])Enum.GetValues(typeof(Edge));
            foreach(Edge e in array){
                edgeCount[(int)ep[(int)e]]++;
            }
            for(int i = 0; i < 12; i++){
                if(edgeCount[i] != 1){
                    return -2;
                }
            }
            for(int j = 0; j < 12; j++){
                sum += eo[j];
            }
            if(sum % 2 != 0){
                return -3;
            }
            int[] cornerCount = new int[8];
            Corner[] array2 = (Corner[])Enum.GetValues(typeof(Corner));
            foreach(Corner c in array2){
                cornerCount[(int)cp[(int)c]]++;
            }
            for(int l = 0; l < 8; l++){
                if(cornerCount[l] != 1){
                    return -4;
                }
            }
            sum = 0;
            for(int k = 0; k < 8; k++){
                sum += co[k];
            }
            if(sum % 3 != 0){
                return -5;
            }
            if((EdgeParity() ^ CornerParity()) != 0){
                return -6;
            }
            return 0;
        }
    }

}