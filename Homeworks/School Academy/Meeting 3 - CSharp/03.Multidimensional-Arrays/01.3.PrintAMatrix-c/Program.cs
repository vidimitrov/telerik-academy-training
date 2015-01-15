using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.MatrixWithNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of rows and columns: ");
            int n = int.Parse(Console.ReadLine());
            int[,] array = new int[n, n];
            int countMax = n * n;
            for (int num = 1, row = n - 1, col = n - 1; num <= countMax; num++, row--)
            {
                array[row, col] = num;
                if ((col == n - 1) && row != 0)
                {
                    col = row - 1;
                    row = n;
                }
                else
                    if (row == 0)
                    {
                        row = col;
                        col = 0;
                    }
                    else
                    {
                        col++;
                    }
            }
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write("{0,4}", array[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
