namespace Company.SampleDataGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Company.Data;

    internal class ReportsDataGenerator: DataGenerator, IDataGenerator
    {
        public ReportsDataGenerator(IRandomDataGenerator randomDataGenerator,
            CompanyEntities companyEntities, int countOfGeneratedObject)
            :base(randomDataGenerator, companyEntities, countOfGeneratedObject)
        {

        }

        public override void Generate()
        {
            Console.WriteLine("Generating reports...");

            var employeeIds = this.Database.Employees
                .AsQueryable()
                .Select(e => e.Id)
                .ToList();

            for (int i = 0; i < this.Count; i++)
            {
                var report = new Report
                {
                    ReportingDate = this.Random.GetRandomDate(),
                    EmployeeId = employeeIds[this.Random.GetRandomNumber(0, employeeIds.Count - 1)]
                };

                this.Database.Reports.Add(report);

                if (i % 100 == 0)
                {
                    Console.Write(".");
                    this.Database.SaveChanges();
                }
            }

            Console.WriteLine("\nReports generated");
            Console.WriteLine();
        }
    }
}
