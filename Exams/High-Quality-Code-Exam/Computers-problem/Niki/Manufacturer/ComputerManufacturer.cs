namespace Computers.Manufacturer
{
    using Computers.ComputerFactory;

    public abstract class ComputerManufacturer
    {
        public abstract PC CretePC();

        public abstract Laptop CreateLaptop();

        public abstract Server CreateServer();
    }
}
