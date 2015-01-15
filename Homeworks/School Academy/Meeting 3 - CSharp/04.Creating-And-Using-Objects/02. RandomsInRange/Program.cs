using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.RandomsInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Console.WriteLine("Random numbers in range[100, 200]:");
            for (int i = 0; i < 10; i++)
            {
                Console.Write("{0} ", rnd.Next(100,200));
            }
            Console.WriteLine("");
        }
    }
}
