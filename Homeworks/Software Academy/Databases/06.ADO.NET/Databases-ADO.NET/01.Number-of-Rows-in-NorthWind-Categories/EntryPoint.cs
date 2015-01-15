namespace _01.Number_of_Rows_in_NorthWind_Categories
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
                SqlCommand cmdCount = new SqlCommand("SELECT COUNT(*) FROM Categories", dbCon);
                int categoriesCount = (int)cmdCount.ExecuteScalar();

                Console.WriteLine("Categories count: {0}", categoriesCount);
            }
        }
    }
}
