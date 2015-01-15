using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01._2.PrintAMatrix_b
{
    class Program
    {
        static void Main()
        {
             Console.WriteLine("Enter number of rows and columns:");
            int rows = int.Parse(Console.ReadLine());
            int cows = rows;
            int num = 1;
            int[,] matrix = new int[rows, cows];
            for (int i = 1; i <= cows; i++)
            {
                if ((i % 2) == 0)
                {
                    for (int j = (rows - 1); j >= 0; j--)
                    {
                        matrix[j, (i-1)] = num;
                        num++;
                    }
                }
                else
                {
                    for (int j = 0; j < rows; j++)
                    {
                        matrix[j, (i-1)] = num;
                        num++;
                    }
                }
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cows; j++)
                {
                    Console.Write("{0,4}", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
