using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentSystem;

public class StudentContext : DbContext
{
    public StudentContext()
        : base("StudentSystemDb")
    { }

    public DbSet<Student> Students { get; set; }

    public DbSet<Course> Courses { get; set; }

    public DbSet<Homework> Homeworks { get; set; }
}