using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SumAndAverageOfElements
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
            while(true)
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
            int sum = 0;
            foreach (int number in sequence)
            {
                sum += number;
            }

            double average = sum / sequence.Count;
            Console.WriteLine("The sum is: {0}\nThe average is: {1}",sum, average);
        }
    }
}
