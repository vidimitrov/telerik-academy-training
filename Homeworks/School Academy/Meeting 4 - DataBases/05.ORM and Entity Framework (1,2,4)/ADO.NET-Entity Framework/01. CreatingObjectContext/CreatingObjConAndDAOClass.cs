using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.CreatingObjectContext
{
    class CreatingObjConAndDAOClass
    {
        public static void Main(string[] args)
        {
            //Exercise 1
            NORTHWNDEntities context = new NORTHWNDEntities();

            //Exercise 4
            string query = 'SELECT c.CustomerID FROM Customers c JOIN Orders o ON (c.CustomerID = o.CustomerID) WHERE o.ShipCity = \'Canada\' AND DATEPART(yyyy, o.OrderDate) = 1997';
            var queryResult = ctx.ExecuteStoreQuery<List<string>>(query);

        }
    }
    //Exercise 2
    class DAOClass
    {

        static void Insert(string CustomerID, string CompanyName, string ContactName, string ContactTitle,
            string Address, string City, string Region, string PostalCode, string Country, string Phone,
            string Fax)
        {
            Customer customer = new Customer();
            customer.CustomerID = CustomerID;
            customer.CompanyName = CompanyName;
            customer.ContactName = ContactName;
            customer.ContactTitle = ContactTitle;
            customer.Address = Address;
            customer.City = City;
            customer.Region = Region;
            customer.PostalCode = PostalCode;
            customer.Country = Country;
            customer.Phone = Phone;
            customer.Fax = Fax;

            context.Customer.Add(customer);
            context.SaveChanges();
        }

        static void Update()
        {
            Customer customer = NORTHWNDEntities.Customer.First();
            customer.CompanyName = 'Oracle';
            context.SaveChanges();
        }

        static void Delete()
        {
            Customer customer = NORTHWNDEntities.Customer.First();
            NORTHWNDEntities.Customer.DeleteObject(customer);
            NORTHWNDEntities.SaveChanges();
        }
    }
}
