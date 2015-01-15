using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.SplitStringIntoIntegers
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter a sequence of numbers divided by ' '(space):");
            string sequence = Console.ReadLine();
            string[] splittedInts = sequence.Split(new Char[] {' '});
            double sum = 0; 
            foreach (string integer in splittedInts)
            {
                sum += int.Parse(integer);
            }
            Console.WriteLine("The sum of these numbers is: {0}",sum);
        }
    }
}
