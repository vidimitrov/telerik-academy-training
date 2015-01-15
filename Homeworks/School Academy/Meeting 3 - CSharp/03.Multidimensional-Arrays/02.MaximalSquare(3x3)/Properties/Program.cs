using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.MaximalSquare_3x3_
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter number of rows:");
            int rows = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter number of cows:");
            int cows = int.Parse(Console.ReadLine());
            int[,] matrix = new int[rows, cows];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cows; j++)
                {
                    Console.Write("matrix[{0}][{1}] = ", i, j);
                    matrix[i, j] = int.Parse(Console.ReadLine());
                    Console.WriteLine("");
                }
            }
            Console.WriteLine("In matrix:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cows; j++)
                {
                    Console.Write("{0,4} ", matrix[i, j]);
                }
                Console.WriteLine("");
            }
            int bestSum = int.MinValue;
            int cowMem = 0;
            int rowMem = 0;
            for (int i = 0; i < (rows - 2); i++)
            {
                for (int j = 0; j < (cows - 2); j++)
                {
                    int sum = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2] +
                        matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2];
                    if (sum > bestSum)
                    {
                        bestSum = sum;
                        cowMem = j;
                        rowMem = i;
                    }
                }
            }
            Console.WriteLine("Maximal sum in square 3x3 is:{0}", bestSum);
            for (int i = rowMem; i < (rowMem + 3); i++)
            {
                for (int j = cowMem; j < (cowMem + 3); j++)
                {
                    Console.Write("{0,4} ", matrix[i, j]);
                }
                Console.WriteLine("");
            }
        }
    }
}
