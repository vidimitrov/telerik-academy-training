using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace StudentSystem
{
    public class Student
    {
        private ICollection<Course> courses;

        private ICollection<Homework> homeworks;

        public Student()
        {
            this.courses = new HashSet<Course>();      
        }

        public Student(string name, int number)
            : this()
        {
            this.Name = name;
            this.Number = number;
            this.homeworks = new HashSet<Homework>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Number { get; set; }

        //public Course Course { get; set; }

        public virtual ICollection<Course> Courses
        {
            get { return courses; }
            set { courses = value; }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get { return homeworks; }
            set { homeworks = value; }
        }
    }
}
