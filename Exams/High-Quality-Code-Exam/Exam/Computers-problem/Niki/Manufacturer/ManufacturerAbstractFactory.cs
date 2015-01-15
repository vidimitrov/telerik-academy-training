namespace Computers.Manufacturer
{
    using Computers.Exceptions;

    public static class ManufacturerAbstractFactory
    {
        public static ComputerManufacturer GetManufacturer(string manufacturerAsString)
        {
            ComputerManufacturer manufacturer;

            if (manufacturerAsString == "HP")
            {
                manufacturer = new HPCompany();
            }
            else if (manufacturerAsString == "Dell")
            {
                manufacturer = new DellCompany();
            }
            else 
            { 
                throw new InvalidArgumentException("Invalid manufacturer!"); 
            }

            return manufacturer;
        }
    }
}
