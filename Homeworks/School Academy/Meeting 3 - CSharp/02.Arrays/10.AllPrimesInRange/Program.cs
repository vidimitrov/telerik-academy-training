using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.AllPrimesInRange
{
    class Program
    {
        static void Main()
        {
            List<bool> numbers = new List<bool>();
            for (int i = 0; i < 10000000; i++)
            {
                numbers.Add(true);
            }
            List<int> primeNumbers = new List<int>();
            int divider = 2;
            double maxDivider;
            bool isPrime = true;
            Console.WriteLine("Please wait...");
            for (int i = 2; i < numbers.Count; i++)
            {
                if (numbers[i] == false)
                {
                    continue;
                }
                maxDivider = Math.Sqrt(i);
                while(isPrime && (divider <= maxDivider))
                {
                    if((i % divider) == 0)
                    {
                        isPrime = false;
                    }
                    divider++;
                }
                divider = 2;
                if (isPrime)
                {
                    for (int k = (2 * i); k < numbers.Count; k += i)
                    {
                        numbers[k] = false;
                    }

                }
                else
                {
                    numbers[i-2] = false;
                }
            }
            for(int i = 2; i < numbers.Count; i++)
            {
                if (numbers[i] == true)
                {
                    primeNumbers.Add(i);
                }
            }
            for (int i = 0; i < primeNumbers.Count; i++)
            {
                Console.WriteLine(primeNumbers[i]);
            }
        }
    }
}
