using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.CompareTwoArrays
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter arrays length:");
            int length = int.Parse(Console.ReadLine());
            int[] firstArray = new int[length];
            int[] secondArray = new int[length];
            Console.WriteLine("Enter first array values:");
            for (int i = 0; i < length; i++)
            {
                firstArray[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Enter second array values:");
            for (int i = 0; i < length; i++)
            {
                secondArray[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (firstArray[i] == secondArray[j])
                    {
                        Console.WriteLine("arr1[{0}]--({1}) = arr2[{2}]--({3})", i, firstArray[i], j, secondArray[j]);
                    }
                    else{
                        if(firstArray[i] > secondArray[j])
                        {
                             Console.WriteLine("arr1[{0}]--({1}) > arr2[{2}]--({3})", i, firstArray[i], j, secondArray[j]);
                        }
                        else
                        {
                            Console.WriteLine("arr1[{0}]--({1}) < arr2[{2}]--({3})", i, firstArray[i], j, secondArray[j]);
                        }
                    }
                    
                }
            }
        }
    }
}
