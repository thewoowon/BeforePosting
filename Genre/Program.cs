using System;
using System.Collections.Generic;

namespace Genre
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            string[] a = { "classic", "pop", "classic", "classic", "pop" };
            int[] b = { 500, 600, 150, 800, 2500 };


            solution.solution(a, b);
        }

        public partial class Solution
        {
            public int[] solution(string[] genres, int[] plays)
            {
                int[] answer = new int[] { };
                List<int> clonePlays = new List<int>(plays);
                Dictionary<int, int> dic1 = new Dictionary<int, int>();
                Dictionary<int, string> dic2 = new Dictionary<int, string>();

                for (int i = 0; i < genres.Length; i++)
                {
                    dic1.Add(plays[i], i);
                    dic2.Add(i, genres[i]);
                }

                

                clonePlays.Sort();
                clonePlays.Reverse();
                for (int i = 0; i < clonePlays.Count; i++)
                {

                    //가장 앞에 있는 것은 가장 먼저 나와야 한다.
                    var index = dic1[clonePlays[i]];
                    var genre = dic2[index];


                }

                //주입완료

                

                
                


                



                return answer;
            }
        }
    }
}
