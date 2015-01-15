using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.SortingIntegers
{
    class Program
    {
        static void Main()
        {
            List<int> sequence = new List<int>();
            Console.WriteLine("Enter integers:");
            int temporary;
            string str;
            bool check;
            while (true)
            {
                str = Console.ReadLine();
                check = int.TryParse(str, out temporary);
                if (check)
                {
                    sequence.Add(temporary);
                }
                else
                {
                    break;
                }
            }
            sequence.Sort();
            Console.WriteLine("Sorted:");
            foreach (int number in sequence)
            {
                Console.Write("{0} ",number);
            }
            Console.WriteLine("");
        }
    }
}
