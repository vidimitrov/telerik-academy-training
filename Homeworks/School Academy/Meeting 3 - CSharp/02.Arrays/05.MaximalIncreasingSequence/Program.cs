using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.MaximalIncreasingSequence
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter number of elements:");
            int elements = int.Parse(Console.ReadLine());
            int[] array = new int[elements];
            Console.WriteLine("Enter the values of the array:");
            for(int i = 0; i < elements; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }
            List<int> countArray = new List<int>();
            List<int> elementsArray = new List<int>();
            int count = 1;
            int tempElement = 0;
            int numberOfSequences = 1;
            int max = 1;
            for(int i = 0; i < elements; i++){
                if(array[i] + 1 == (array[i+1])){
                    count++;
                    tempElement = array[i] - (count-2);
                }
                else{
                    countArray.Add(count);
                    elementsArray.Add(tempElement);
                    tempElement = array[i+1];
                    count = 1;
                }
                if (i == (elements - 2))
                {
                    countArray.Add(count);
                    elementsArray.Add(tempElement);
                    break;
                }
            }
            for(int i = 0; i < countArray.Count; i++){
                if((countArray[i] == max) && (countArray[i] != 1)){
                    numberOfSequences++;
                }
                else
                if(countArray[i] > max){
                    max = countArray[i];
                }
            }
            if(numberOfSequences > 1){
                Console.WriteLine("There are {0} maximal sequnces",numberOfSequences);
            }                                                                           
            else{                                                                       
                int startIncreasingElement = elementsArray[countArray.IndexOf(max)];
                int[] sequence = new int[max];
                for(int i=1; i <= max; i++){
                    sequence[i-1] = startIncreasingElement + (i-1);
                }
                Console.Write("[ ");
                for (int i = 0; i < max; i++)
                {
                    Console.Write(sequence[i] + ", ");
                }
                Console.WriteLine("]");
            }
        }
    }
}
