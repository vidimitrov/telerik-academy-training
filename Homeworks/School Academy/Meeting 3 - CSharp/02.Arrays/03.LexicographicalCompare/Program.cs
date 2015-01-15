using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.LexicographicalCompare
{
    class Program
    {
        static void Main()
        {
            char[] firstArray = {'a', 'b', 'c', 'e'};
            char[] secondArray = {'a', 'b', 'c', 'd'};
            for (var i = 0; i < firstArray.Length; i++)
            {
				if(firstArray[i] == secondArray[i]){
                    if (i == firstArray.Length - 1)
                    {
                        Console.WriteLine("Char arrays are equal!");
					}
				}
				else{ 
                    if(firstArray[i] > secondArray[i])
                    {
                         Console.WriteLine("First char array is bigger");
					     break;
                    }
				    else
                    {
				    	Console.WriteLine("Second char array is bigger");
				    	break;
				    }
                }
			}
        }
    }
}
