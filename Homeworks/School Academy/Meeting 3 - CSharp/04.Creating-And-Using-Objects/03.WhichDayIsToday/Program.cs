using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.WhichDayIsToday
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime now = DateTime.Now;
            string day;
            switch(now.DayOfWeek)
            {
                case DayOfWeek.Monday : day = "The day is Monday!"; break;
                case DayOfWeek.Tuesday: day = "The day is Tuesday!"; break;
                case DayOfWeek.Wednesday: day = "The day is Wednesday!"; break;
                case DayOfWeek.Thursday: day = "The day is Thursday!"; break;
                case DayOfWeek.Friday: day = "The day is Friday!"; break;
                case DayOfWeek.Saturday: day = "The day is Saturday!"; break;
                case DayOfWeek.Sunday: day = "The day is Sunday!"; break;
                default: day = "Error!"; break;
            }
            Console.WriteLine(day);
        }
    }
}
