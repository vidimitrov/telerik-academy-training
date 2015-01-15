namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WarMachines.Interfaces;

    public abstract class Machine : IMachine
    {
        //Fields

        private string name;
        private IPilot pilot;
        private double healthPoints;
        private double attackPoints;
        private double defensePoints;
        private IList<string> targets;

        //Constructors

        public Machine(string name, double healthPoints,
            double attackPoints, double defensePoints)
        {
            this.Name = name;
            this.HealthPoints = healthPoints;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.targets = new List<string>();
        }

        //Properties

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Machine's name cannot be null or empty!");
                }

                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot; // Try to implement Clone() and check if it is right
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Pilot cannot be null!");
                }

                this.pilot = value;
            }
        }

        public double HealthPoints
        {
            get
            {
                return this.healthPoints;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Machine's health points cannot be negative!");
                }

                this.healthPoints = value;
            }
        }

        public double AttackPoints
        {
            get
            {
                return this.attackPoints;
            }
            protected set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Attack points cannot be negative!");
                }

                this.attackPoints = value;
            }
        }

        public double DefensePoints
        {
            get
            {
                return this.defensePoints;
            }
            protected set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Defense points cannot be negative!");
                }

                this.defensePoints = value;
            }
        }

        public IList<string> Targets
        {
            get
            {
                return new List<string>(this.targets);
            }
        }

        //Methods

        public void Attack(string target)
        {
            if (!String.IsNullOrEmpty(target))
            {
                this.targets.Add(target);
            }

            //Check if you must implement "else" and throw an exception
        }

        public override string ToString()
        {
            StringBuilder machineAsString = new StringBuilder();

            string machineTargets;
            
            if (this.Targets.Count > 0)
            {
                machineTargets = String.Join(", ", this.Targets);
            }
            else
            {
                machineTargets = "None";
            }

            machineAsString.Append("- " + this.Name);
            machineAsString.Append(Environment.NewLine);
            machineAsString.Append(" *Type: " + this.GetType().Name);
            machineAsString.Append(Environment.NewLine);
            machineAsString.Append(" *Health: " + this.HealthPoints);
            machineAsString.Append(Environment.NewLine);
            machineAsString.Append(" *Attack: " + this.AttackPoints);
            machineAsString.Append(Environment.NewLine);
            machineAsString.Append(" *Defense: " + this.DefensePoints);
            machineAsString.Append(Environment.NewLine);
            machineAsString.Append(" *Targets: " + machineTargets);
            machineAsString.Append(Environment.NewLine);

            return machineAsString.ToString();
        }
    }
}
