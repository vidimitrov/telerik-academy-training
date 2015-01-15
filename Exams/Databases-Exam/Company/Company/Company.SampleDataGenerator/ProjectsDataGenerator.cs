namespace Company.SampleDataGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Company.Data;

    internal class ProjectsDataGenerator: DataGenerator, IDataGenerator
    {
        public ProjectsDataGenerator(IRandomDataGenerator randomDataGenerator,
            CompanyEntities companyEntities, int countOfGeneratedObjects)
            : base(randomDataGenerator, companyEntities, countOfGeneratedObjects)
        { 
            
        }

        public override void Generate()
        {
            Console.WriteLine("Generating projects...");

            var employeeIds = this.Database.Employees
                .AsQueryable()
                .Select(e => e.Id)
                .ToList();

            for (int i = 0; i < this.Count; i++)
            {
                var project = new Project
                {
                    Name = this.Random.GetRandomStringWithRandomLength(5, 50)
                };

                if (employeeIds.Count > 0)
                {
                    var uniqueEmployeeIds = new HashSet<int>();
                    var employeesInProject = this.Random.GetRandomNumber(2, Math.Min(20, employeeIds.Count));

                    while (uniqueEmployeeIds.Count != employeesInProject)
                    {
                        uniqueEmployeeIds.Add(employeeIds[this.Random.GetRandomNumber(0, employeeIds.Count - 1)]);
                    }

                    foreach (var id in uniqueEmployeeIds)
                    {
                        var startDate = this.Random.GetRandomDate();
                        var endDate = this.Random.GetRandomDate(startDate);

                        project.EmployeesProjects.Add(new EmployeesProject 
                        { 
                            Employee = this.Database.Employees.Find(id),
                            EmployeeId = id,
                            Project = project,
                            ProjectId = project.Id,
                            StartingDate = startDate,
                            EndingDate = endDate
                        });

                        //I think that the Database first method didn't do the many to many relation correctly
                        //so try to add new EmployeesProjects directly in EmployeesProjects table.
                    }
                }

                if (i % 100 == 0)
                {
                    Console.Write(".");
                    this.Database.SaveChanges();
                }

                this.Database.Projects.Add(project);
            }

            Console.WriteLine("\nProjects generated");
            Console.WriteLine();
        }
    }
}
