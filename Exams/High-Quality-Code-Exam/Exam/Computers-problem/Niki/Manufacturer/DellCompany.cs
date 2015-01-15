namespace Computers.Manufacturer
{
    using System;
    using System.Collections.Generic;
    using Computers.ComputerFactory;
    using Computers.ComputerFactory.Parts;

    public class DellCompany : ComputerManufacturer
    {
        private const int DefaultRamAmount = 8;
        private const int DefaultHddCapacity = 1000;
        private const byte DefaultCpuBits = 32;
        private const byte DefaultCpuCores = 4;

        public override PC CretePC()
        {
            VideoCard videoCard = new VideoCard(VideoCardType.Colorful);
            RAM ram = new RAM(DefaultRamAmount);

            HardDrive hdd = new HardDrive(DefaultHddCapacity, false, 0);
            List<HardDrive> hardDrives = new List<HardDrive>();
            hardDrives.Add(hdd);

            byte numberOfCPUBits = 2 * DefaultCpuBits;
            byte numberOfCPUCores = DefaultCpuCores;
            CPU cpu = new CPU(numberOfCPUCores, numberOfCPUBits, ram, videoCard);
            
            Motherboard motherboard = new Motherboard(cpu, ram, videoCard);

            PC pc = new PC(motherboard, cpu, ram, hardDrives, videoCard);

            return pc;
        }

        public override Laptop CreateLaptop()
        {
            VideoCard videoCard = new VideoCard(VideoCardType.Colorful);
            RAM ram = new RAM(DefaultRamAmount);
            Battery battery = new Battery();

            HardDrive hdd = new HardDrive(DefaultHddCapacity, false, 0);
            List<HardDrive> hardDrives = new List<HardDrive>();
            hardDrives.Add(hdd);

            byte numberOfCPUBits = DefaultCpuBits;
            byte numberOfCPUCores = DefaultCpuCores;
            CPU cpu = new CPU(numberOfCPUCores, numberOfCPUBits, ram, videoCard);
            
            Motherboard motherboard = new Motherboard(cpu, ram, videoCard);

            Laptop laptop = new Laptop(motherboard, cpu, ram, hardDrives, videoCard, battery);

            return laptop;
        }

        public override Server CreateServer()
        {
            VideoCard videoCard = new VideoCard(VideoCardType.Monochrome);
            RAM ram = new RAM(DefaultRamAmount * DefaultRamAmount);

            HardDrive firstExternalHdd = new HardDrive(2 * DefaultHddCapacity, false, 0);
            HardDrive secondExternalHdd = new HardDrive(2 * DefaultHddCapacity, false, 0);
            List<HardDrive> externalHardDrives = new List<HardDrive>();
            externalHardDrives.Add(firstExternalHdd);
            externalHardDrives.Add(secondExternalHdd);

            HardDrive raidHdd = new HardDrive(0, true, 2, externalHardDrives);
            List<HardDrive> hardDrives = new List<HardDrive>();
            hardDrives.Add(raidHdd);

            byte numberOfCPUBits = 2 * DefaultCpuBits;
            byte numberOfCPUCores = 2 * DefaultCpuCores;
            CPU cpu = new CPU(numberOfCPUCores, numberOfCPUBits, ram, videoCard);
            
            Motherboard motherboard = new Motherboard(cpu, ram, videoCard);

            Server server = new Server(motherboard, cpu, ram, hardDrives, videoCard);

            return server;
        }
    }
}