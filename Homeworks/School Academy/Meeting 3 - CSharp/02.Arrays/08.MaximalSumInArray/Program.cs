using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.MaximalSumInArray
{
    class Program
    {
        static void Main()
        {
            int[] array = {2,3,-6,-1,2,-1,6,4,-8,8};
            int sum = array[0];
            int lastSum = sum;
            List<int> biggestSumNumbers = new List<int>();
            biggestSumNumbers.Add(array[0]);
            for (int i = 1; i < array.Length; i++)
            {
                sum += array[i];
                if (sum == 0)
                {
                    biggestSumNumbers.Clear();
                    biggestSumNumbers.Add(array[i]);
                    sum = array[i];
                }
                else
                {
                    if ((sum >= lastSum) || (sum > 0))
                    {
                        biggestSumNumbers.Add(array[i]);
                    }
                    else
                    {                     
                        biggestSumNumbers.Clear();
                        biggestSumNumbers.Add(array[i]);
                    }
                }
                lastSum = sum;
            }
        }
    }
}
