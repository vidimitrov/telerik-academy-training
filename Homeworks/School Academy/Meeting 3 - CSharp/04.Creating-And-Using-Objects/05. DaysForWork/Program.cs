using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.DaysForWork
{
    public class Days
    {
        public DateTime[] holidays = new DateTime[]{
        new DateTime(2012,01,01), new DateTime(2012,01,02), new DateTime(2012,03,03), new DateTime(2012,04,14),
        new DateTime(2012,04,13), new DateTime(2012,04,14), new DateTime(2012,04,15), new DateTime(2012,04,30),
        new DateTime(2012,05,01), new DateTime(2012,05,06), new DateTime(2012,05,24), new DateTime(2012,09,06),
        new DateTime(2012,09,22), new DateTime(2012,11,01), new DateTime(2012,12,24), new DateTime(2012,12,25),
        new DateTime(2012,12,31)};

        public int WorkingDaysBetween(DateTime start, DateTime end)
        {
            
            List<DateTime> workDays = new List<DateTime>();
            bool isWorkDay = true;
            while (start.Date != end.Date.AddDays(1))
            {
                if ((start.DayOfWeek != DayOfWeek.Saturday) &&
                (start.DayOfWeek != DayOfWeek.Sunday))
                {
                    foreach (DateTime holiday in holidays)
                    {
                        if ((start.Day == holiday.Day) && (start.Month == holiday.Month))
                        {
                            isWorkDay = false;
                        }
                    }
                    if (isWorkDay)
                    {
                        workDays.Add(start.Date);
                    }
                }
                
                start = start.AddDays(1);
                isWorkDay = true;
            }


            return workDays.Count;
        }
    }
    class Test
    {
        static void Main()
        {
            DateTime now = new DateTime(2012, 12, 20);
            DateTime date = new DateTime(2013, 01, 03);
            if (date.Date < now.Date)
            {
                Console.WriteLine("The date must be after today!");
                return;
            }
            
            Days wdb = new Days();
            int workDays = wdb.WorkingDaysBetween(now, date);

            Console.WriteLine("There are {0} workdays between [{1} , {2}]", workDays, now.Date, date.Date);
        }
    }
}
