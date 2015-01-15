namespace Company.SampleDataGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Company.Data;

    internal class EmployeeDataGenerator: DataGenerator, IDataGenerator
    {
        public EmployeeDataGenerator(IRandomDataGenerator randomDataGenerator,
            CompanyEntities companyEntities, int countOfGeneratedObjects)
            :base(randomDataGenerator, companyEntities, countOfGeneratedObjects)
        { 
            
        }

        public override void Generate()
        {
            Console.WriteLine("Generating employees...");

            var departmentsIds = this.Database.Departments
                .AsQueryable()
                .Select(d => d.Id)
                .ToList();

            for (int i = 0; i < this.Count; i++)
            {
                var managerIds = this.Database.Employees
                .AsQueryable()
                .Where(e => e.ManagerId == null)
                .Select(m => m.Id)
                .ToList();

                var employee = new Employee
                {
                    FirstName = this.Random.GetRandomStringWithRandomLength(5, 20),
                    LastName = this.Random.GetRandomStringWithRandomLength(5, 20),
                    DepartmentId = departmentsIds[this.Random.GetRandomNumber(0, departmentsIds.Count - 1)]
                };

                var isManager = this.Random.GetRandomNumber(1, 100) > 95;

                if (isManager)
                {
                    employee.YearSalary = this.Random.GetRandomNumber(200000, 500000);
                    employee.ManagerId = null;
                }
                else
                {
                    employee.YearSalary = this.Random.GetRandomNumber(50000, 200000);
                    
                    if (managerIds.Count > 1)
                    {
                        employee.ManagerId = managerIds[this.Random.GetRandomNumber(0, managerIds.Count - 1)];
                    }
                    else
                    {
                        employee.ManagerId = null;
                    }
                }
                
                if (i % 100 == 0)
                {
                    Console.Write(".");
                    this.Database.SaveChanges();
                }

                this.Database.Employees.Add(employee);
            }

            Console.WriteLine("\nEmployees generated");
            Console.WriteLine();
        }
    }
}
