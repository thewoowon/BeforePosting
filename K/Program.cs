using System;
using System.Collections.Generic;
using System.Linq;

namespace K
{
 

    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();

            int[] a = { 1, 5, 2, 6, 3, 7, 4 };
            int[,] b = { { 2, 5, 3 }, { 4, 4, 1 }, { 1, 7, 3 } };

            solution.solution(a,b);
            
        }

        public partial class Solution
        {
            public int[] solution(int[] array, int[,] commands)
            {
                int count = commands.GetLength(0);
                int[] answer = new int[count];

                for (int i = 0; i < count; i++)
                {
                    var temp = new ArraySegment<int>(array, commands[i,0]-1, commands[i,1] - commands[i,0] + 1);
                    List<int> tempList = new List<int>(temp.ToArray());

                    tempList.Sort();

                    answer[i] = tempList[commands[i, 2] - 1];
                }

                return answer;
            }
        }
    }
}
