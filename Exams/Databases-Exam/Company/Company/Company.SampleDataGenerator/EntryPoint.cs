namespace Company.SampleDataGenerator
{
    using Company.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class EntryPoint
    {
        private static void Main()
        {
            var random = RandomDataGenerator.Instance;
            var db = new CompanyEntities();
            db.Configuration.AutoDetectChangesEnabled = false;

            var listOfGenerators = new List<IDataGenerator>
            {
                new DepartmentsDataGenerator(random, db, 100),
                new EmployeeDataGenerator(random, db, 5000),
                new ProjectsDataGenerator(random, db, 1000),
                new ReportsDataGenerator(random, db, 250000)
            };

            foreach (var generator in listOfGenerators)
            {
                generator.Generate();
                db.SaveChanges();
            }
        }
    }
}
