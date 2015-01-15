namespace _02.Name_and_Desc_of_All_Northwind_Categories
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
                SqlCommand cmd = new SqlCommand("SELECT CategoryName, Description FROM Categories", dbCon);
                var categories = cmd.ExecuteReader();

                Console.WriteLine("Category name     |      Description");

                while (categories.Read())
                {
                    string categoryName = (string)categories["CategoryName"];
                    string categoryDescription = (string)categories["Description"];

                    Console.WriteLine("{0} - {1}", categoryName, categoryDescription);
                }
            }
        }
    }
}
