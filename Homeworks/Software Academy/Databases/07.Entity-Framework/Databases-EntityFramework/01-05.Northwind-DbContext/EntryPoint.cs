namespace _01.Create_Northwind_DbContext
{
    using System;
using System.Collections.Generic;
using System.Linq;

    class EntryPoint
    {
        static void Main()
        {
            //01. 

            var northwindDB = new NorthwindEntities();
            
            var northwindCategories = northwindDB.Categories.ToList();

            foreach (var category in northwindCategories)
            {
                Console.WriteLine(category.CategoryName);
            }

            //02. 

            //DAO.InsertCustomer(new Customer(...)); Create an instance and it will work

            //DAO.ModifyCustomer(northwindDb.Customers.First(), new Customer(), northwindDB);

            //DAO.DeleteCustomer(northwindDb.Customers.First(), northwindDB);

            //03.

            //var customers = GetAllCustomersWithCertainOrders(northwindDB);
        }

        //03. Write a method that finds all customers who have orders made in 1997 and shipped to Canada.

        public List<Customer> GetAllCustomersWithCertainOrders(NorthwindEntities db)
        {
            //var customers = db.Customers
            //    .Where(c => c.Orders.AsQueryable()
            //                    .Where(o => o.OrderDate.Value.Year == 1997 && o.ShipCity == "Canada")
            //                    .ToList());

            //return customers;
            return null;
        }
    }
}
