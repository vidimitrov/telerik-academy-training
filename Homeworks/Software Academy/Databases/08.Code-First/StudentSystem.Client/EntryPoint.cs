using StudentSystem;
using StudentSystemContext.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

internal class EntryPoint
{
    static void Main()
    {
        Database.SetInitializer(
            new MigrateDatabaseToLatestVersion<StudentContext, Configuration>());

        var db = new StudentContext();

        var course = new Course("c#", "New javascript web technology", new List<string> { "1", "2", "3" });
        db.Courses.Add(course);

        var student = new Student("Venci", 9999);
        db.Students.Add(student);
        student.Courses.Add(course);

        var homework = new Homework() { Course = course, Content = "Good", TimeSent = DateTime.Now };
        student.Homeworks.Add(homework);
        db.SaveChanges();
    }
}