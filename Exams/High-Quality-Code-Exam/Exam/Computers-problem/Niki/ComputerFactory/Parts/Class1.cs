using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computers.ComputerFactory.Parts
{
    public class Person
    {
        private int age;
        private string name;

        public int Age 
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }

        public Person(int age, string name)
        {
            this.Age = age;
            this.name = name;
        }

        public int GetAge(out Person person)
        {
            person = this;

            return 0;
        }
    }
}
