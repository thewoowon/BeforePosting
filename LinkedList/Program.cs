using System;
using System.Collections.Generic;
using System.Linq;

namespace LinkedList
{

    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> list = new LinkedList<string>();
            list.AddLast("Apple");
            list.AddLast("Banana");
            list.AddLast("Lemon");

            LinkedListNode<string> node = list.Find("Banana");
            LinkedListNode<string> newNode = new LinkedListNode<string>("Grape");

            list.AddAfter(node, newNode);

            string[] listArray = new string[100];

            list.CopyTo(listArray, 0);

            for (int i = 0; i < 10; i++)
            {
                Console.Write(listArray[i]);
                Console.Write(i == 9 ? "\n" : ", ");
            }

            Console.WriteLine();

            list.ToList<string>().ForEach(p => Console.WriteLine(p));

            Console.WriteLine();

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
