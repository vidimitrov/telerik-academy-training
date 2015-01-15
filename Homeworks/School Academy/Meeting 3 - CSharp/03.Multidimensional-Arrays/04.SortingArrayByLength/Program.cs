using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SortingArrayByLength
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("How many words will you enter:");
            int arrLen = int.Parse(Console.ReadLine());
            char[][] words = new char[arrLen][];
            List<char> letters = new List<char>();
            int maxLen = 0;
            int maxInd = 0;
            for (int i = 0; i < arrLen; i++)
            {
                Console.WriteLine("Enter word:");
                string word = Console.ReadLine();
                foreach(char item in word)
                {
                    letters.Add(item);
                }
                words[i] = letters.ToArray();
                if(letters.Count > maxLen)
                {
                    maxLen = letters.Count;
                    maxInd = i;
                }
                letters.Clear();
            }
            Array.Sort(words, (x, y) => x.Length.CompareTo(y.Length));
            Console.WriteLine("");
            Console.WriteLine("The words you entered, but sorted:");
            Console.WriteLine("");
            foreach  (char[] item in words)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("");
        }
    }
}
