namespace Computers.ComputerFactory.Parts
{
    using System;
    using Computers.Interfaces;

    public class CPU : ICpu
    {
        private byte numberOfBits;
        private byte numberOfCores;
        private RAM ram;
        private VideoCard videoCard;

        public CPU()
        {
        }

        public CPU(byte numberOfCores, byte numberOfBits, RAM ram, VideoCard videoCard)
        {
            this.NumberOfCores = numberOfCores;
            this.NumberOfBits = numberOfBits;
            this.ram = ram;
            this.videoCard = videoCard;
        }

        public byte NumberOfCores 
        {
            get
            {
                return this.numberOfCores;
            }

            set 
            {
                this.numberOfCores = value;
            }
        }

        public byte NumberOfBits 
        {
            get
            {
                return this.numberOfBits;
            }

            set 
            {
                this.numberOfBits = value;
            }
        }

        public void CalculateSquareNumber()
        {
            if (this.numberOfBits == 32)
            {
                this.SquareNumber32();
            }
            else if (this.numberOfBits == 64)
            {
                this.SquareNumber64();
            }
        }

        public void SquareNumber32()
        {
            var data = this.ram.LoadValue();
            if (data < 0)
            {
                this.videoCard.Draw("Number too low.");
            }
            else if (data > 500)
            {
                this.videoCard.Draw("Number too high.");
            }
            else
            {
                int value = 0;
                for (int i = 0; i < data; i++)
                {
                    value += data;
                }

                this.videoCard.Draw(string.Format("Square of {0} is {1}.", data, value));
            }
        }

        public void SquareNumber64()
        {
            var data = this.ram.LoadValue();
            if (data < 0)
            {
                this.videoCard.Draw("Number too low.");
            }
            else if (data > 1000)
            {
                this.videoCard.Draw("Number too high.");
            }
            else
            {
                int value = 0;
                for (int i = 0; i < data; i++)
                {
                    value += data;
                }

                this.videoCard.Draw(string.Format("Square of {0} is {1}.", data, value));
            }
        }

        public int GenerateRandomNumber(int min, int max)
        {
            int randomNumber;
            Random randomGenerator = new Random();

            do
            {
                randomNumber = randomGenerator.Next(0, 1000);
            }
            while (!(randomNumber >= min && randomNumber <= max));

            // Refactor when see where in the code it is used
            this.SaveValueToRam(randomNumber);

            return randomNumber;
        }

        public void SaveValueToRam(int number)
        {
            this.ram.SaveValue(number);
        }
    }
}
