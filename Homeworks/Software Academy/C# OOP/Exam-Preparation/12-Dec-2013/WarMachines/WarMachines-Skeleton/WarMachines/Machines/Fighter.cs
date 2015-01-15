namespace WarMachines.Machines
{
    using System;
    using WarMachines.Interfaces;

    public class Fighter : Machine, IFighter
    {
        //Fields and constants
        private const int InitialHealth = 200;

        private bool stealthMode;

        //Constructors
        
        public Fighter(string name, double attackPoints,
            double defensePoints, bool initialStealthMode) 
            : base(name, InitialHealth, attackPoints, defensePoints)
        {
            this.StealthMode = initialStealthMode;
        }
        
        //Properties

        public bool StealthMode
        {
            get
            {
                return this.stealthMode;
            }
            private set
            {
                this.stealthMode = value;
            }
        }

        //Methods

        public void ToggleStealthMode()
        {
            this.StealthMode = !this.StealthMode;
        }

        public override string ToString()
        {
            string machineInfo = base.ToString();

            string stealthMode;

            if (this.StealthMode)
            {
                stealthMode = "ON";
            }
            else
            {
                stealthMode = "OFF";
            }

            string stealthModeInfo = " *Stealth: " + stealthMode;

            machineInfo += stealthModeInfo;

            return machineInfo;
        }
    }
}