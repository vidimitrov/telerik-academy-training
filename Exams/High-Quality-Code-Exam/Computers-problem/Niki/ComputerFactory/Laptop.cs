namespace Computers.ComputerFactory
{
    using System.Collections.Generic;
    using Computers.ComputerFactory.Parts;

    public class Laptop : Computer
    {
        private Battery battery;

        public Laptop(Motherboard motherboard, CPU cpu, RAM ram, IEnumerable<HardDrive> hardDrives, VideoCard videoCard, Battery battery) 
            : base(motherboard, cpu, ram, hardDrives, videoCard)
        {
            this.battery = battery;
        }

        public void ChargeBattery(int percentage)
        {
            this.battery.Charge(percentage);

            string textToDraw = string.Format("Battery status: {0}", this.battery.Percentage);
            this.VideoCard.Draw(textToDraw);
        }
    }
}
