using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01._4.PrintAMatrix_d
{
    class Program
    {
        static void Main()
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            int temp = 1;
            int i = 1, j = n, row = 0, col = 0;
            int[,] array = new int[n, n];
            int temp2;
            if (n % 2 == 0)
            {
                temp2 = n / 2;
            }
            else
            {
                temp2 = (n / 2) + 1;
            }
            Console.WriteLine("Output:");
            array[row, col] = temp;
            while ((i <= temp2) && (j >= 0))
            {
                while (col < n - i)
                {
                    col++;
                    temp++;
                    array[row, col] = temp;
                    if (col == (n - i))
                    {
                        while (row < (n - i))
                        {
                            row++;
                            temp++;
                            array[row, col] = temp;
                            if (row == (n - i))
                            {
                                while (col > (n - j))
                                {
                                    col--;
                                    temp++;
                                    array[row, col] = temp;
                                    if (col == (n - j))
                                    {
                                        while (row > (n - (j - 1)))
                                        {
                                            row--;
                                            temp++;
                                            array[row, col] = temp;
                                        }
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                        break;
                    }
                }
                i++;
                j--;
            }
            for (int k = 0; k < array.GetLength(0); k++)
            {
                for (int l = 0; l < array.GetLength(1); l++)
                {
                    Console.Write("{0,-4}", array[k, l]);
                }
                Console.WriteLine();
            }
        }
    }
}
