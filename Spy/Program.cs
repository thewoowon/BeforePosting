using System;
using System.Collections.Generic;

namespace Spy
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            string[,] str = { { "yellow_hat", "headgear" }, { "blue_sunglasses", "eyewear" }, { "green_turban", "headgear" } };
            int answer =  solution.solution(str);

            Console.WriteLine(answer);
        }

        public partial class Solution
        {
            public int solution(string[,] clothes)
            {
                int answer = 1;

                Dictionary<string, int> dic = new Dictionary<string, int>();

                for (int i = 0; i < clothes.GetLength(0); i++)
                {
                    if (dic.ContainsKey(clothes[i,1]))
                    {
                        dic[clothes[i, 1]]++;
                    }
                    else
                    {
                        dic.Add(clothes[i, 1], 1);
                    }
                }
                foreach (var item in dic)
                {
                    answer *= (item.Value + 1);
                }

                //조합의 공식 -> 

                return answer - 1;
            }
        }
    }
}
