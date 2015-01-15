namespace Computers.ComputerFactory.Parts
{
    using Computers.Interfaces;

    public class Battery : IBattery
    {
        private int percentage;

        public Battery() 
        { 
            this.Percentage = 100 / 2; 
        }

        public int Percentage 
        { 
            get
            {
                return this.percentage;
            }

            set
            {
                this.percentage = value;
            }
        }

        public void Charge(int percentsToCharge)
        {
            this.Percentage += percentsToCharge;

            if (this.Percentage > 100)
            {
                this.Percentage = 100;
            }
            else if (this.Percentage < 0)
            {
                this.Percentage = 0;
            }
        }
    }
}
