using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.IndexesMultipliedBy_5_
{
    class Program
    {
        static void Main()
        {
            int[] array = new int[20];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i * 5;
            }
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine("The value of element [{0}] is {1}", i,array[i]);   
            }
        }
    }
}
