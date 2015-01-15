using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ReversingIntegers
{
    class Program
    {
        static void Main()
        {
            Console.Write("N = ");
            int n = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            Console.WriteLine("Enter integers:");
            for (int i = 0; i < n; i++)
            {
                stack.Push(int.Parse(Console.ReadLine()));
            }
            Console.WriteLine("Reversed:");
            for (int i = 0; i < n; i++)
            {
                Console.Write("{0} ", stack.Pop());
            }
            Console.WriteLine("");
        }
    }
}
