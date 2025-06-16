using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CFOPSolver{

    internal static class CFOP{

        public static string Solution(string state){
            return Algorithms.RotateAlgorithm(Algorithms.Optimize(Solve(ConvertState(state))), 0, 0, 2);
        }

        private static char[] ConvertState(string state){

            StringBuilder sb = new StringBuilder(54);

            Dictionary<char, char> map = new Dictionary<char, char>{
                { 'U', 'D' }, { 'D', 'U' },
                { 'L', 'R' }, { 'R', 'L' },
                { 'F', 'F' }, { 'B', 'B' }
            };

            for(int i = 2;i>=0;i--){
                for(int j = 2;j>=0;j--){
                    sb.Append(map[state[18 + i * 3 + j]]);
                }
            }
            for(int i = 2;i>=0;i--){
                for(int j = 2;j>=0;j--){
                    sb.Append(map[state[36 + i * 3 + j]]);
                }
            }
            for(int i = 2;i>=0;i--){
                for(int j = 2;j>=0;j--){
                    sb.Append(map[state[45 + i * 3 + j]]);
                }
            }
            for(int i = 2;i>=0;i--){
                for(int j = 2;j>=0;j--){
                    sb.Append(map[state[9 + i * 3 + j]]);
                }
            }
            for(int i=0;i<3;i++){
                for(int j = 2;j>=0;j--){
                    sb.Append(map[state[27 + i + j * 3]]);
                }
            }
            for(int i = 2;i>=0;i--){
                for(int j = 0;j<3;j++){
                    sb.Append(map[state[i + j * 3]]);
                }
            }

            return sb.ToString().ToCharArray();
        }

        private static string Solve(char[] cube){

            string solution = Cross.Solve(cube);

            solution += F2L.Solve(cube);

            solution += OLL.Solve(cube);

            solution += PLL.Solve(cube);

            if(Enumerable.SequenceEqual(cube, Constants.SolvedCube)){
                solution = Algorithms.Optimize(solution);
            }
            else{
                solution = string.Empty;
            }

            return solution;
        }
    }
}