using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.LargestNumberUsingBinarySearch__
{
    class Program
    {
        static void Main()
        {
            Console.Write("N = ");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("array[{0}] = ", i);
                arr[i] = int.Parse(Console.ReadLine());
                Console.WriteLine("");
            }
            Console.Write("K = ");
            int K = int.Parse(Console.ReadLine());
            Array.Sort(arr);
            int largest = Array.BinarySearch(arr, K);
            if (arr[0] > K)
            {
                Console.WriteLine("There isn't a number <= {0}",K);
                return;
            } 
            if (largest < 0)
            {
                for (int i = 1; i < K; i++)
                {
                    largest = Array.BinarySearch(arr, K - i);
                    if (largest >= 0)
                    {
                        Console.WriteLine("The largest number <= {0} is {1} and exists at postion {2}", K, K - i, largest);
                        break;
                    }
                }   
            }
            else
            {
                Console.WriteLine("The number {0} exists at postion {1}", K, largest);
            }
        }
    }
}
