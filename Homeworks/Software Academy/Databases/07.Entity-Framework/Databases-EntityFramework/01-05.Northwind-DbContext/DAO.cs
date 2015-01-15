namespace _01.Create_Northwind_DbContext
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public static class DAO
    {
        public static void InsertCustomer(Customer newCustomer, NorthwindEntities db)
        {
            db.Customers.Add(newCustomer);
            db.SaveChanges();
        }

        public static void ModifyCustomer(Customer customer, Customer modifiedCustomer, NorthwindEntities db)
        {
            customer.Address = modifiedCustomer.Address;
            customer.City = modifiedCustomer.City;
            customer.CompanyName = modifiedCustomer.CompanyName;
            customer.ContactName = modifiedCustomer.ContactName;
            customer.ContactTitle = modifiedCustomer.ContactTitle;
            customer.Country = modifiedCustomer.Country;
            customer.CustomerDemographics = modifiedCustomer.CustomerDemographics;
            customer.Fax = modifiedCustomer.Fax;
            customer.Orders = modifiedCustomer.Orders;
            customer.Phone = modifiedCustomer.Phone;
            customer.PostalCode = modifiedCustomer.PostalCode;
            customer.Region = modifiedCustomer.Region;

            db.SaveChanges();
        }

        public static void DeleteCustomer(Customer customerToDelete, NorthwindEntities db)
        {
            db.Customers.Remove(customerToDelete);
            db.SaveChanges();
        }
    }
}
