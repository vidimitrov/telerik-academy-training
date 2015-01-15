using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.RemovingElements
{
    class Program
    {
        static void Main()
        {
            List<int> sequence = new List<int> {5, 4, 7, 5, 8, 9, 11,3,10,9};
            int count = sequence.Count;
            for (int i = 0; i < count; i++)
            {
                if (i == 0)
                {
                    if (sequence[i] < sequence[i + 1])
                    {
                        sequence.RemoveAt(i);
                        i--;
                    }
                    else
                    {
                        continue;
                    }
                }
                if(i == (count - 1))
                {
                    if (sequence[i] < sequence[i - 1])
                    {
                        sequence.RemoveAt(i);
                    }
                    break;
                }
                if ((sequence[i] < sequence[i - 1]) || (sequence[i] < sequence[i + 1]))
                {
                    sequence.RemoveAt(i);
                    i--;
                }
                
                count = sequence.Count;
            }
            foreach (int item in sequence)
            {
                Console.WriteLine(item);
            }
        }
    }
}
