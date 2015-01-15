namespace Computers.ComputerFactory.Parts
{
    using System;
    using Computers.Interfaces;

    public class Motherboard : IMotherboard
    {
        private CPU cpu;
        private RAM ram;
        private VideoCard videoCard;
        
        public Motherboard(CPU cpu, RAM ram, VideoCard videoCard)
        {
            this.cpu = cpu;
            this.ram = ram;
            this.videoCard = videoCard;
        }

        public int LoadRamValue()
        {
            return this.ram.Value;
        }

        public void SaveRamValue(int value)
        {
            this.ram.Value = value;
        }

        public void DrawOnVideoCard(string data)
        {
            this.videoCard.Draw(data);
        }
    }
}
