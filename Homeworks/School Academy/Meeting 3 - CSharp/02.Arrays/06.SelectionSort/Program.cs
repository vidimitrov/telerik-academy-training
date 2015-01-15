using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.SelectionSort
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter number of elements:");
            int elements = int.Parse(Console.ReadLine());
            List<int> array = new List<int>();
            Console.WriteLine("Enter the values of the array:");
            for (int i = 0; i < elements; i++)
            {
                array.Add(int.Parse(Console.ReadLine()));
            }
            int length = array.Count;
			List<int> sortedArray = new List<int>();
			int min;
			int swap;
            for (int i = 0; i < length; i++)
            {			
				min = array[0];
                for (int j = 0; j < array.Count; j++)
                {
					if(array[j] < min){
						min = array[j];
						swap = array[0];
						array[0] = array[j];
						array[j] = swap;
					}
				}
				array.RemoveAt(0);
				sortedArray.Insert(i, min);
			}
            Console.Write("[ ");
            for(int i = 0; i < length; i++) 
            {
                Console.Write(sortedArray[i] + ", ");
            }
            Console.WriteLine("]");
        }
    }
}
