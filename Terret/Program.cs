using System;
using System.Threading;


namespace Terret
{
    class Program
    {

        public partial class calc
        {
            public int getCaseNumberAndCase()
            {
                int caseNumber;

                while (true)
                {
                    string caseNumberStr = Console.ReadLine().Trim();
                    if (int.TryParse(caseNumberStr, out caseNumber))
                    {
                        return caseNumber;
                    }
                }
            }


            public int showResult(string[] strArray)
            {
                int result;
                int joX = int.Parse(strArray[0]);
                int joY = int.Parse(strArray[1]);
                int joR = int.Parse(strArray[2]);
                int baekX = int.Parse(strArray[3]);
                int baekY = int.Parse(strArray[4]);
                int baekR = int.Parse(strArray[5]);

                double distance = Math.Sqrt(Math.Pow(baekX - joX, 2) + Math.Pow(baekY - joY, 2));

                if (joX == baekX && joY == baekY)
                {
                    return result = -1;
                }

                if (distance < joR + baekR)
                {
                    return result = 2;
                }
                else if (distance == joR + baekR)
                {
                    return result = 1;
                }
                else
                {
                    return result = 0;
                }
            }

            public string[][] getLocationCases(int caseNumber)
            {
                string strArray;

                string[][] arrCase = new string[caseNumber][];



                for (int i = 0; i < caseNumber; i++)
                {
                    strArray = Console.ReadLine();

                    if (strArray.Split(' ').Length == 6)
                    {
                        arrCase[i] = strArray.Split(' ');       
                    }
                    else
                    {
                        
                        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                        Console.WriteLine("케이스를 잘못 입력하셨습니다. 공백으로 구분된 여섯개의 정보입니다.");
                        Thread.Sleep(2000);
                        i--;
                    }
                }

                return arrCase;

            }
        }

        static void Main(string[] args)
        {
            char[] charArray1 = {'a','b','c','d'};

            char[] charArray2 = new char[4];

            char[] charArray3;

            char[] charArray4 = new char[4];

            char[] charArray6 = new char[3];

            char[] charArray7 = new char[5];

            charArray3 = new char[7];


            //대표적인 속성
            //대표적인 메소드

            int charLength = charArray1.Length;

            charArray1.CopyTo(charArray4, 0);
            charArray1.CopyTo(charArray6, 0);
            charArray1.CopyTo(charArray7, 0);

            charArray1.CopyTo()

            object charArray5 = charArray1.Clone();

            Console.WriteLine("배열의 길이 => {0}", charLength);
            for (int i = 0; i < charLength; i++)
            {
                Console.Write(charArray1[i]);
                Console.Write(i == charLength-1 ? "\n" : ", "); 
            }

            for (int i = 0; i < charArray4.Length; i++)
            {
                Console.Write(charArray4[i]);
                Console.Write(charArray4[i] + i == charArray4.Length - 1 ? "" : ", ");
            }



            char[] TwoDimensionFirst = new char[10];

            char[] TwoDimensionSecond = new char[3];

            char[,] TwoDimention = new char[10, 3];
            
            char[,,] ThreeDimension = new char[10, 3, 7];

        }
    }
}
