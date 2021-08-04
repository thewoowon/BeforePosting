using System;
using System.Collections.Generic;

namespace Truck
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();

            int a = 100;
            int b = 100;
            int[] c = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };

            int answer = solution.solution(a,b,c);

            Console.WriteLine(answer);
        }


        public partial class Solution
        {
            public int solution(int bridge_length, int weight, int[] truck_weights)
            {
                int second = 0;
                Queue<int> trucks = new Queue<int>(truck_weights);
                Queue<int> buffer = new Queue<int>(bridge_length);

                while (trucks.Count > 0)
                {
                    int readyFor = trucks.Peek();

                    if (checkTotalWeight(buffer, weight, readyFor))
                    {
                        buffer.Dequeue();
                        buffer.Enqueue(trucks.Dequeue());
                    }
                    else
                    {
                        buffer.Dequeue();
                        buffer.Enqueue(0);

                        if (checkTotalWeight(buffer, weight, readyFor))
                        {
                            buffer.Dequeue();
                            buffer.Enqueue(trucks.Dequeue());
                        }
                    }

                    second++;
                }

                return second + bridge_length;
            }

            public bool checkTotalWeight(Queue<int> buffer,int limit,int next)
            {
                int totalWeight = 0;

                foreach (var item in buffer)
                {
                    totalWeight += item;
                }

                if (totalWeight + next <= limit)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
