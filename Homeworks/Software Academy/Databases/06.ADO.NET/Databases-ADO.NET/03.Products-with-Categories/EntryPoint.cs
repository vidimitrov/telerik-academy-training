namespace _03.Products_with_Categories
{
    using System;
    using System.Data.SqlClient;

    class EntryPoint
    {
        static void Main(string[] args)
        {
            SqlConnection dbCon = new SqlConnection("Server=.; " +
            "Database=Northwind; Integrated Security=true");

            dbCon.Open();

            using (dbCon)
            {
                string query = "SELECT p.ProductName, c.CategoryName " + 
                                    "FROM Products p " + 
                                        "INNER JOIN Categories c " +
	                                    "ON p.CategoryID = c.CategoryID";

                SqlCommand cmd = new SqlCommand(query, dbCon);
                var products = cmd.ExecuteReader();

                Console.WriteLine("Product name     |      Category name");

                while (products.Read())
                {
                    string productName = (string)products["ProductName"];
                    string categoryName = (string)products["CategoryName"];

                    Console.WriteLine("{0} - {1}", categoryName, productName);
                }
            }
        }
    }
}
