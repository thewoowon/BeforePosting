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

                int nowBig = calsTemp[0];
                int count = 1;

                for (int i = 1; i < calsTemp.ToArray().Length; i++)
                {
                    if (nowBig >= calsTemp[i])
                    {
                        count++;
                    }
                    else
                    {
                        answer.Add(count);
                        nowBig = calsTemp[i];
                        count = 1;
                    }

                    if (i == calsTemp.ToArray().Length-1)
                    {
                        answer.Add(count);
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
