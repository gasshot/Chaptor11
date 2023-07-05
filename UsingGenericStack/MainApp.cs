using System;
using System.Collections.Generic;

namespace UsingGenericStack
{
    class MainApp
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            stack.Push(1); // 5
            stack.Push(2); // 4
            stack.Push(3); // 3
            stack.Push(4); // 2
            stack.Push(5); // 1

            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }
        }
    }
}
