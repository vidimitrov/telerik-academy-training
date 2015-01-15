namespace Computers.ComputerFactory
{
    using System;
    using System.Collections.Generic;
    using Computers.ComputerFactory.Parts;

    public class Server : Computer
    {
        public Server(Motherboard motherboard, CPU cpu, RAM ram, IEnumerable<HardDrive> hardDrives, VideoCard videoCard) 
            : base(motherboard, cpu, ram, hardDrives, videoCard)
        {
        }

        public void Process(int data)
        {
            this.RAM.SaveValue(data);
            this.CPU.CalculateSquareNumber();
        }
    }
}
