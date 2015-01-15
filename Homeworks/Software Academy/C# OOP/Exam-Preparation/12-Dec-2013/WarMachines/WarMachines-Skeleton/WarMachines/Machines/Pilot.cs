namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    using WarMachines.Interfaces;

    public class Pilot : IPilot
    {
        //Fields

        private string name;
        private IList<IMachine> machines;

        //Constructors

        public Pilot(string initialName)
        {
            this.Name = initialName;
            this.machines = new List<IMachine>();
        }

        //Properties

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Pilot's name cannot be null or empty!");
                }

                this.name = value;
            }
        }

        public IList<IMachine> Machines
        {
            get 
            {
                return new List<IMachine>(this.machines);
            }
        }

        //Methods

        public void AddMachine(IMachine machine)
        {
            if (machine != null)
            {
                this.machines.Add(machine);
            }
        }

        public string Report()
        {
            StringBuilder pilotAsString = new StringBuilder();

            string numberOfMachines;
            string pluralOrSingular;

            if (this.Machines.Count > 0)
            {
                if (this.Machines.Count == 1)
                {
                    pluralOrSingular = "machine";
                }
                else
                {
                    pluralOrSingular = "machines";
                }

                numberOfMachines = this.Machines.Count.ToString() + " ";    
            }
            else
            {
                pluralOrSingular = "machines";
                numberOfMachines = "no ";
            }

            pilotAsString.Append(this.Name);
            pilotAsString.Append(" - ");
            pilotAsString.Append(numberOfMachines);
            pilotAsString.Append(pluralOrSingular);
            pilotAsString.Append(Environment.NewLine);

            var sortedMachines = this.Machines.OrderBy(m => m.HealthPoints).ThenBy(m => m.Name);

            foreach (var machine in sortedMachines)
            {
                pilotAsString.Append(machine);
                pilotAsString.Append(Environment.NewLine);
            }

            return pilotAsString.ToString().Trim();
        }
    }
}
