using System;
using System.Collections.Generic;

namespace StockPrice
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] temp = {1, 2, 3, 2, 3 };

            solution.solution(temp);
        }

        public partial class Solution
        {
            public int[] solution(int[] prices)
            {
                int[] answer = new int[prices.Length];


                for (int i = 0; i < prices.Length; i++)
                {
                    int baseValue = prices[i];
                    int count = 0;

                    for (int j = i+1; j < prices.Length; j++)
                    {
                        count++;
                        if (prices[j]< baseValue)
                        {
                            break;
                        }
                    }
                    answer[i] = count;
                }

                return answer;
            }
        }
    }
}
