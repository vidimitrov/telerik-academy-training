using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentSystem
{
    public class Course
    {
        private ICollection<Student> students;

        private ICollection<Homework> homeworks;

        public Course()
        {
            this.students = new HashSet<Student>();
        }

        public Course(string name, string description, IList materials)
            : this()
        {
            this.Name = name;
            this.Description = description;
            this.Materials = materials;
            this.homeworks = new HashSet<Homework>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public IList Materials { get; set; }

        //EF will automatically add ParentId
        public virtual Course Parent { get; set; }

        public virtual ICollection<Student> Students
        {
            get { return students; }
            set { students = value; }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get { return homeworks; }
            set { homeworks = value; }
        }
    }
}