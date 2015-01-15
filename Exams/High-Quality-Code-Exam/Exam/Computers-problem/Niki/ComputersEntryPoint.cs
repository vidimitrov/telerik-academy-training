﻿namespace Computers
{
    using System;
    using Computers.Manufacturer;
    using Computers.ComputerFactory.Parts;

    public static class ComputersEntryPoint
    {
        public static void Main()
        {
            Person person = new Person(15, "Pesho");
            Person person2;

            int num = person.GetAge(out person2);

            Console.WriteLine("Num: {0}", num);
            Console.WriteLine("Person: {0}", person2.Age);

            //var manufacturerAsString = Console.ReadLine();

            //ComputerManufacturer manufacturer = ManufacturerAbstractFactory.GetManufacturer(manufacturerAsString);

            //var pc = manufacturer.CretePC();
            //var server = manufacturer.CreateServer();
            //var laptop = manufacturer.CreateLaptop();

            //while (true)
            //{
            //    var command = Console.ReadLine();

            //    if (command == null || command.StartsWith("Exit"))
            //    {
            //        break;
            //    }
                
            //    var splittedCommand = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                
            //    if (splittedCommand.Length != 2)
            //    {
            //        {
            //            throw new ArgumentException("Invalid command!");
            //        }
            //    }
                
            //    var commandName = splittedCommand[0];
            //    var commandParams = int.Parse(splittedCommand[1]);

            //    if (commandName == "Charge")
            //    { 
            //        laptop.ChargeBattery(commandParams); 
            //    }
            //    else if (commandName == "Process")
            //    { 
            //        server.Process(commandParams); 
            //    }
            //    else if (commandName == "Play")
            //    {
            //        pc.Play(commandParams);
            //    }
            //    else
            //    {
            //        throw new ArgumentException("Invalid command!");
            //    }
            //}
        }
    }
}
