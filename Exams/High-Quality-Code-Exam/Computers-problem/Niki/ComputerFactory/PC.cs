namespace Computers.ComputerFactory
{
    using System;
    using System.Collections.Generic;
    using Computers.ComputerFactory.Parts;

    public class PC : Computer
    {
        public PC(Motherboard motherboard, CPU cpu, RAM ram, IEnumerable<HardDrive> hardDrives, VideoCard videoCard)
            : base(motherboard, cpu, ram, hardDrives, videoCard)
        {
        }

        public void Play(int guessNumber)
        {
            this.CPU.GenerateRandomNumber(1, 10);

            var number = this.RAM.LoadValue();
            if (number + 1 != guessNumber + 1)
            {
                this.VideoCard.Draw(string.Format("You didn't guess the number {0}.", number));
            }
            else
            {
                this.VideoCard.Draw("You win!");
            }
        }
    }
}
