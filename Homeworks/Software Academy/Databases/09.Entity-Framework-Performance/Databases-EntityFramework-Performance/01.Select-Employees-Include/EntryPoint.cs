namespace _01.Select_Employees_Include
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    class EntryPoint
    {
        public static void Main()
        {
            var db = new TelerikAcademyEntities();

            //=========================================================================================
            // 01. Using Entity Framework write a SQL query to select all employees from the Telerik Academy 
            //     database and later print their name, department and town. Try the both variants: with and 
            //     without .Include(…). Compare the number of executed SQL statements and the performance.
            //=========================================================================================

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            foreach (var emp in db.Employees)
            {
                Console.WriteLine("Name: {0}, Department {1}, Town {2}", emp.FirstName, emp.Department.Name, emp.Address.Town.Name);                
            }

            stopwatch.Stop();
            var withoutInclude = stopwatch.Elapsed;

            stopwatch.Reset();
            stopwatch.Start();
            foreach (var emp in db.Employees.Include("Address"))
            {
                Console.WriteLine("Name: {0}, Department {1}, Town {2}", emp.FirstName, emp.Department.Name, emp.Address.Town.Name);                
            }

            stopwatch.Stop();
            var withInclude = stopwatch.Elapsed;

            Console.WriteLine();
            Console.WriteLine("Without Include() - {0}", withoutInclude);
            Console.WriteLine("With Include() - {0}", withInclude);


            //=========================================================================================
            // 02. Using Entity Framework write a query that selects all employees from the Telerik Academy
            //     database, then invokes ToList(), then selects their addresses, then invokes ToList(), 
            //     then selects their towns, then invokes ToList() and finally checks whether the town 
            //     is "Sofia". Rewrite the same in more optimized way and compare the performance.
            //=========================================================================================

            //Unoptimized:

            stopwatch.Reset();
            stopwatch.Start();
            var unOptimizedEmployeesTowns = db.Employees.ToList()
                .Select(e => e.Address).ToList()
                .Select(a => a.Town).ToList()
                .Where(t => t.Name == "Sofia");

            stopwatch.Stop();
            var unoptimizedQueryTime = stopwatch.Elapsed;

            //Optimized

            stopwatch.Reset();
            stopwatch.Start();
            var optimizedEmployeesTowns = db.Employees
                .Include("Address")
                .Select(e => e.Address)
                .Where(a => a.Town.Name == "Sofia")
                .ToList();

            stopwatch.Stop();
            var optimizedQueryTime = stopwatch.Elapsed;

            Console.WriteLine();
            Console.WriteLine("Unoptimized query time: {0}", unoptimizedQueryTime);
            Console.WriteLine("Optimized query time: {0}", optimizedQueryTime);
        }
    }
}
