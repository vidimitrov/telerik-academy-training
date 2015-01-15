using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Letters
{
    class Program
    {
        static void Main()
        {
            char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k',
            'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            Console.WriteLine("Type a word:");
            string str = Console.ReadLine();
            List<char> sep = new List<char>();
            foreach (char i in str)
            {
                sep.Add(i);
            }

            for(int i=0; i < sep.Count; i++)
            {
                for(int j = 0; j < alphabet.Length; j++)
                {
                    if(sep[i] == alphabet[j])
                    {
                        Console.Write(j + " ");
                    }
                }
            }
            Console.WriteLine("");
        }
    }
}
