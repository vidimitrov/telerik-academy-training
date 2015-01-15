using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.MembersOfSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int member = 2;
            for (int i = 0; i < 10; i++)
            {
                if ((member % 2) == 0)
                {
                    Console.Write("{0} ", member);
                }
                else 
                {
                    Console.Write("{0} ", -member);
                }
                member++;
            }
            Console.WriteLine("");
        }

    }
}
