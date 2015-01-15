namespace Computers.ComputerFactory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Computers.ComputerFactory.Parts;

    public abstract class Computer
    {
        private Motherboard motherboard;
        private CPU cpu;
        private RAM ram;
        private VideoCard videoCard;
        private IEnumerable<HardDrive> hardDrives;
        
        public Computer(Motherboard motherboard, CPU cpu, RAM ram, IEnumerable<HardDrive> hardDrives, VideoCard videoCard)
        {
            this.motherboard = motherboard;
            this.cpu = cpu;
            this.ram = ram;
            this.hardDrives = hardDrives;
            this.videoCard = videoCard;
        }

        public CPU CPU 
        { 
            get
            {
                return this.cpu;
            }

            set
            {
                this.cpu = value;
            }
        }

        public RAM RAM 
        { 
            get
            {
                return this.ram;
            }

            set
            {
                this.ram = value;
            }
        }

        public VideoCard VideoCard 
        { 
            get
            {
                return this.videoCard;
            }

            set
            {
                this.videoCard = value;
            }
        }

        public IEnumerable<HardDrive> HardDrives 
        { 
            get
            {
                return this.hardDrives;
            }

            set
            {
                this.hardDrives = value;
            }
        }
    }
}
