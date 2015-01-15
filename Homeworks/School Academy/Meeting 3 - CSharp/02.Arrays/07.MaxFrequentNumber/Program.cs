using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.MostFrequentNumber
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter number of elements:");
            int elements = int.Parse(Console.ReadLine());
            int[] numArr = new int[elements];
            Console.WriteLine("Enter the values of the array:");
            for(int i = 0; i < elements; i++)
            {
                numArr[i] = int.Parse(Console.ReadLine());
            }
			int numLength = numArr.Length;
			List<int> position = new List<int>();
			List<int> valueArr = new List<int>();
			List<int> lengthArr = new List<int>();
			int temp;
			int count = 1;
			bool check = true;
			int numberOfSequences = 1;  
			for(int i = 0; i < numLength; i++){
				temp = numArr[i];
				check = true;
				for(int p = 0; p < position.Count; p++){
					if(position[p] == i){
						check = false;
					}
				}
				if(check){
					for(var j = i + 1; j < numLength; j++){
						if(temp == numArr[j]){
							count++;
							position.Add(j);
							temp = numArr[j];
							if(j == numLength - 1){
								valueArr.Add(temp);
								lengthArr.Add(count);
								count = 1;
							}
						}
						else if(j == numLength - 1){
							valueArr.Add(temp);
							lengthArr.Add(count);
							count = 1;
						}
					}
				}
			}
			var max = 1;
			for(int i = 0; i < lengthArr.Count; i++){
				if((lengthArr[i] == max) && (lengthArr[i] != 1)){
					numberOfSequences++;
				}
				else
				if(lengthArr[i] > max){
					max = lengthArr[i];
				}
			}
			if(numberOfSequences > 1){
			     Console.WriteLine("There are {0} most frequent elements!", numberOfSequences);
			}
			else{                                                                       
				int mostFrequentElement = valueArr[lengthArr.IndexOf(max)];
                Console.WriteLine("The most frequent element in the array is {0} and it occurs {1} times!", mostFrequentElement, max);
			}
		}
    }
}
