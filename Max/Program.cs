using System;
using System.Text;

namespace Max
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public partial class Solution
        {
            public string solution(int[] numbers)
            {
                string answer = "";

                
                StringBuilder sb = new StringBuilder();

                
                Array.Sort(numbers, (x, y) =>
                string.Compare(y.ToString() + x.ToString(), x.ToString() + y.ToString()));

                
                for (int i = 0; i < numbers.Length; i++)
                {
                    sb.Append(numbers[i].ToString());
                }

                
                answer = sb.ToString();

               
                int count = 0;

                
                foreach (var zero in answer)
                {
                    if (zero == '0')
                        count++;
                }

                
                if (count == numbers.Length)
                    return "0";

                
                else
                    return answer;
            }
        }
    }
}
