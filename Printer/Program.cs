using System;
using System.Collections.Generic;

namespace Printer
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] p = {1,1,9,1,1,1};
            int l = 0;

            int answer = solution.solution(p, l);

            Console.WriteLine(answer);
        }

        public partial class Solution
        {
            public int solution(int[] priorities, int location)
            {

                Queue<int> prior = new Queue<int>(priorities);
                Queue<int> indexQueue = new Queue<int>();

                for (int i = 0; i < priorities.Length; i++)
                {
                    indexQueue.Enqueue(i); //인덱스를 저장하는 큐 초기화
                }


                while (true)
                {
                    int sw = 1;
                    int onStagePriority = prior.Dequeue();
                    int onStageIndex = indexQueue.Dequeue();

                    foreach (var item in prior)
                    {
                        if (onStagePriority < item)
                        {
                            sw = 0;
                            indexQueue.Enqueue(onStageIndex);
                            prior.Enqueue(onStagePriority);
                            break;
                        }
                    }

                    if (sw != 0)
                    {
                        if (location == onStageIndex)
                        {
                            return priorities.Length - prior.Count;
                        }
                    }
                }
            }
        }
    }
}
