namespace WarMachines.Machines
{
    using System;
    using WarMachines.Interfaces;

    public class Tank : Machine, ITank
    {
        //Fields and constants
        private const int InitialHealth = 100;
        private const int ModifierAttackPoints = 40;
        private const int ModifierDefensePoints = 30;

        private bool defenseMode;

        //Constructors

        public Tank(string name, double attackPoints,
            double defensePoints) 
            : base(name, InitialHealth, attackPoints, defensePoints)
        {
            this.ToggleDefenseMode();
        }

        //Properties

        public bool DefenseMode
        {
            get
            {
                return this.defenseMode;
            }
            private set
            {
                this.defenseMode = value;
            }
        }

        //Methods

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode)
            {
                this.AttackPoints += ModifierAttackPoints;
                this.DefensePoints -= ModifierDefensePoints;
            }
            else
            {
                this.AttackPoints -= ModifierAttackPoints;
                this.DefensePoints += ModifierDefensePoints;
            }

            this.DefenseMode = !this.DefenseMode;
        }

        public override string ToString()
        {
            string machineInfo = base.ToString();

            string defenseMode;

            if (this.DefenseMode)
            {
                defenseMode = "ON";
            }
            else
            {
                defenseMode = "OFF";
            }

            string defenseModeInfo = " *Defense: " + defenseMode;

            machineInfo += defenseModeInfo;

            return machineInfo;
        }
    }
}
