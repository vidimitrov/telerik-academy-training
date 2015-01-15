using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.IsYearLeap
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter some year to see is it leap:");
            int year = int.Parse(Console.ReadLine());
            bool isLeap = DateTime.IsLeapYear(year);
            if (isLeap)
            {
                Console.WriteLine("The year is leap!");
            }
            else
            {
                Console.WriteLine("The year isn't leap!");
            }
        }
    }
}
