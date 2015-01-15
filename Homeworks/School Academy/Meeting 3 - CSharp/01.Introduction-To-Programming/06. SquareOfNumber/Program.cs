using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.SquareOfNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 12345;
            double square = Math.Sqrt(number);
            Console.WriteLine("The square of number {0} is {1}", number, square);
        }
    }
}
