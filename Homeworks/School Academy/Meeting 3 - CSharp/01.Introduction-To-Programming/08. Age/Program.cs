using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Age
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Your age: ");
            int age = int.Parse(Console.ReadLine());
            int ageAfter = age + 10;
            Console.WriteLine("After 10 years you will be {0} years old!", ageAfter);
        }
    }
}
