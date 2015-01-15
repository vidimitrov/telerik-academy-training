namespace Company.SampleDataGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Company.Data;

    internal class DepartmentsDataGenerator: DataGenerator, IDataGenerator
    {
        public DepartmentsDataGenerator(IRandomDataGenerator randomDataGenerator,
            CompanyEntities companyEntities, int countOfGeneratedObjects)
            :base(randomDataGenerator, companyEntities, countOfGeneratedObjects)
        {

        }

        public override void Generate()
        {
            Console.WriteLine("Generating departments...");

            for (int i = 0; i < this.Count; i++)
            {
                var department = new Department
                {
                    Name = this.Random.GetRandomStringWithRandomLength(10, 50)
                };

                this.Database.Departments.Add(department);

                if (i % 100 == 0)
                {
                    Console.Write(".");
                    this.Database.SaveChanges();
                }
            }

            Console.WriteLine("\nDepartments generated");
            Console.WriteLine();
        }
    }
}
