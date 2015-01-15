namespace Cars.Importer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Cars.Data;
    using Cars.Models;
    using System.IO;
    using Newtonsoft.Json;
    using System.Xml.Linq;

    class EntryPoint
    {
        public static CarsDbContext db = new CarsDbContext();

        private static void Main()
        {
            db.Cars.Any();

            var jsonFilesDirectory = @"../../../ExternalFiles/Data.Json.Files";
            var jsonFiles = Directory.GetFiles(jsonFilesDirectory);
            var filesCount = jsonFiles.Count();

            Console.WriteLine("Inserting JSON files to the db (this may take few minutes):");
            Console.WriteLine();

            for (int i = 0; i < filesCount; i++)
            {
                //Comment ImportJSONToDb below if you want to see the search results and exports faster!
                ImportJSONToDb(jsonFiles[i]);

                Console.WriteLine("---- Inserting file {0}...", i);
            }

            Console.WriteLine("\nJSON file inserted!");
            Console.WriteLine();

            var queriesFilePath = @"../../../ExternalFiles/Queries.xml";

            Console.WriteLine("Searching...\n");
            SearchQueries(queriesFilePath);
            Console.WriteLine("\nSearched results are exported to the output files!\n");
        }

        private static void ImportJSONToDb(string jsonFilePath)
        {
            var stream = new StreamReader(jsonFilePath);
            JsonTextReader reader = new JsonTextReader(stream);
            JsonSerializer serializer = new JsonSerializer();
            object parsedJson = serializer.Deserialize(reader);

            dynamic carsObject = JsonConvert.DeserializeObject(parsedJson.ToString());

            int index = 0;
            foreach (var carObject in carsObject)
            {
                string model = carObject.Model;
                int year = (int)carObject.Year;
                TransmissionType type = (TransmissionType)carObject.TransmissionType;
                decimal price = (decimal)carObject.Price;

                var manufacturerName = (string)carObject.ManufacturerName;
                var manufacturer = db.Manufacturers.FirstOrDefault(m => m.Name == manufacturerName);
                if (manufacturer == null)
                {
                    manufacturer = new Manufacturer
                    {
                        Name = carObject.ManufacturerName
                    };
                }

                var dealerName = (string)carObject.Dealer.Name;
                var dealer = db.Dealers.FirstOrDefault(d => d.Name == dealerName);
                if (dealer == null)
                {
                    dealer = new Dealer
                    {
                        Name = carObject.Dealer.Name
                    };
                }

                var cityName = (string)carObject.Dealer.City;
                var city = db.Cities.FirstOrDefault(c => c.Name == cityName);
                if (city == null)
                {
                    city = new City
                    {
                        Name = cityName
                    };
                }

                dealer.Cities.Add(city);

                var car = new Car
                {
                    Model = model,
                    Year = year,
                    Price = price,
                    TransmissionType = type,
                    Manufacturer = manufacturer,
                    Dealer = dealer
                };

                db.Cars.Add(car);

                if (index % 100 == 0)
                {
                    db.SaveChanges();
                }
            }
        }

        private static void SearchQueries(string queriesFilePath)
        {
            var xmlQueries = XElement.Load(queriesFilePath).Elements();

            foreach (var query in xmlQueries)
            {
                var queryOutputFile = query.Attribute("OutputFileName").Value;

                foreach (var parameter in query.Elements())
                {
                    var cars = db.Cars.AsQueryable();
                    string orderBy = null;

                    if (parameter.Name == "OrderBy")
                    {
                        orderBy = parameter.Value;
                    }
                    else if (parameter.Name == "WhereClauses")
                    {
                        var whereClauses = parameter.Elements();
                        foreach (var whereClause in whereClauses)
                        {
                            var whereClausePropertyName = whereClause.Attribute("PropertyName").Value;
                            var whereClauseType = whereClause.Attribute("Type").Value;
                            var whereClauseCriteria = whereClause.Value;

                            switch (whereClausePropertyName)
                            {
                                case "Id":
                                    {
                                        int criteria = int.Parse(whereClauseCriteria);

                                        switch (whereClauseType)
                                        {
                                            case "Equals":
                                                cars = cars.Where(c => c.Id == criteria);
                                                break;
                                            case "GreaterThan":
                                                cars = cars.Where(c => c.Id > criteria);
                                                break;
                                            case "LessThan":
                                                cars = cars.Where(c => c.Id < criteria);
                                                break;
                                        }
                                    }
                                    break;
                                case "Year":
                                    {
                                        int criteria = int.Parse(whereClauseCriteria);

                                        switch (whereClauseType)
                                        {
                                            case "Equals":
                                                cars = cars.Where(c => c.Year == criteria);
                                                break;
                                            case "GreaterThan":
                                                cars = cars.Where(c => c.Year > criteria);
                                                break;
                                            case "LessThan":
                                                cars = cars.Where(c => c.Year < criteria);
                                                break;
                                        }
                                    }
                                    break;
                                case "Price":
                                    {
                                        decimal criteria = decimal.Parse(whereClauseCriteria);

                                        switch (whereClauseType)
                                        {
                                            case "Equals":
                                                cars = cars.Where(c => c.Price == criteria);
                                                break;
                                            case "GreaterThan":
                                                cars = cars.Where(c => c.Price > criteria);
                                                break;
                                            case "LessThan":
                                                cars = cars.Where(c => c.Price < criteria);
                                                break;
                                        }
                                    }
                                    break;
                                case "Model":
                                    {
                                        switch (whereClauseType)
                                        {
                                            case "Equals":
                                                cars = cars.Where(c => c.Model == whereClauseCriteria);
                                                break;
                                            case "Contains":
                                                cars = cars.Where(c => c.Model.Contains(whereClauseCriteria));
                                                break;
                                        }
                                    }
                                    break;
                                case "Manufacturer":
                                    {
                                        switch (whereClauseType)
                                        {
                                            case "Equals":
                                                cars = cars.Where(c => c.Manufacturer.Name == whereClauseCriteria);
                                                break;
                                            case "Contains":
                                                cars = cars.Where(c => c.Manufacturer.Name.Contains(whereClauseCriteria));
                                                break;
                                        }
                                    }
                                    break;
                                case "Dealer":
                                    {
                                        switch (whereClauseType)
                                        {
                                            case "Equals":
                                                cars = cars.Where(c => c.Dealer.Name == whereClauseCriteria);
                                                break;
                                            case "Contains":
                                                cars = cars.Where(c => c.Dealer.Name.Contains(whereClauseCriteria));
                                                break;
                                        }
                                    }
                                    break;
                                //case "City":
                                    //TODO implement
                            }

                            switch (orderBy)
                            {
                                case "Id": cars = cars.OrderBy(c => c.Id); break;
                                case "Year": cars = cars.OrderBy(c => c.Year); break;
                                case "Model": cars = cars.OrderBy(c => c.Model); break;
                                case "Price": cars = cars.OrderBy(c => c.Price); break;
                                case "Manufacturer": cars = cars.OrderBy(c => c.Manufacturer.Name); break;
                                case "Dealer": cars = cars.OrderBy(c => c.Dealer.Name); break;
                            }

                            ExportCarsToXml(cars.ToList(), queryOutputFile);
                        }
                    }
                }
            }
        }

        private static void ExportCarsToXml(List<Car> carsList, string queryOutputFile)
        {
            var carsElement = new XElement("Cars");

            foreach (var car in carsList)
            {
                var carElement = new XElement("Car");
                carElement.Add(new XAttribute("Manufacturer", car.Manufacturer.Name));
                carElement.Add(new XAttribute("Model", car.Model));
                carElement.Add(new XAttribute("Year", car.Year));
                carElement.Add(new XAttribute("Price", car.Price));

                carElement.Add(new XElement("TransmissionType", ((TransmissionType)car.TransmissionType).ToString().ToLowerInvariant()));

                var dealerElement = new XElement("Dealer");
                dealerElement.Add(new XAttribute("Name", car.Dealer.Name));

                var citiesElement = new XElement("Cities");

                foreach (var city in car.Dealer.Cities)
                {
                    var cityElement = new XElement("City", city.Name);
                    citiesElement.Add(cityElement);
                }

                dealerElement.Add(citiesElement);

                carElement.Add(dealerElement);

                carsElement.Add(carElement);
            }

            carsElement.Save(@"../../../ExternalFiles/" + queryOutputFile);
        }
    }
}