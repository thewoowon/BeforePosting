using System;
using System.Collections.Generic;

namespace ProgressList.cs
{
    class Program
    {

        public partial class solutional
        {
            public int[] solution(int[] progresses, int[] speeds)
            {
                List<int> calsTemp = new List<int>();
                List<int> answer = new List<int>();



                for (int i = 0; i < progresses.Length; i++)
                {
                    int left = (100 - progresses[i]) % speeds[i];

                    if (string.IsNullOrEmpty(left.ToString()))
                    {
                        calsTemp.Add(((100 - progresses[i]) / speeds[i]) + 1);
                    }
                    else
                    {
                        calsTemp.Add(((100 - progresses[i]) / speeds[i]));
                    }
                }

                

                return answer.ToArray();
            }
        }

        static void Main(string[] args)
        {
            solutional solution = new solutional();

            int[] p = { 95,90,99,99,80,99 };
            int[] s = { 1,1,1,1,1,1};

            int[] answer = solution.solution(p,s);

            foreach (var item in answer)
            {
                Console.WriteLine(item);
            }
        }
    }
}
