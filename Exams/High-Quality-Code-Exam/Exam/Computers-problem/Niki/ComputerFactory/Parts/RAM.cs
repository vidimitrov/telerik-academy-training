namespace Computers.ComputerFactory.Parts
{
    using Computers.Interfaces;

    public class RAM : IRam
    {
        private const int DefaultRamAmount = 1;

        private int value;
        private int amount;

        public RAM()
            : this(DefaultRamAmount)
        {
        }

        public RAM(int amount)
        {
            this.amount = amount;
        }

        public int Amount 
        { 
            get
            {
                return this.amount;
            }

            set
            {
                this.amount = value;
            }
        }

        public int Value
        {
            get
            {
                return this.value;
            }

            set
            {
                // Throw exception on some condition, probably with the Amount
                this.value = value;
            }
        }

        public void SaveValue(int newValue)
        {
            this.Value = newValue;
        }

        public int LoadValue()
        {
            return this.Value;
        }
    }
}