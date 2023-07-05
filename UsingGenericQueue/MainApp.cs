using System;
using System.Collections.Generic;

namespace UsingGenericQueue
{
    class MainApp
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();

            for (int i = 1; i < 6; i++)
            {
                queue.Enqueue(i);
            }

            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }
        }
    }
}
