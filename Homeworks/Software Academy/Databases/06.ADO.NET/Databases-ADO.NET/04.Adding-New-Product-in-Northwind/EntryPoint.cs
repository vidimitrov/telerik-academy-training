namespace _04.Adding_New_Product_in_Northwind
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
                string query = "INSERT INTO Products (ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued) VALUES (@productName, @supplierID, @categoryID, @quantityPerUnit, @unitPrice, @unitsInStock, @unitsOnOrder, @reorderLevel, @discontinued)";
                
                SqlCommand cmd = new SqlCommand(query, dbCon);

                cmd.Parameters.AddWithValue("@productName", "NewProduct");
                cmd.Parameters.AddWithValue("@supplierID", 2);
                cmd.Parameters.AddWithValue("@categoryID", 1);
                cmd.Parameters.AddWithValue("@quantityPerUnit", "10 boxes x 20 bags");
                cmd.Parameters.AddWithValue("@unitPrice", 18.0000);
                cmd.Parameters.AddWithValue("@unitsInStock", 39);
                cmd.Parameters.AddWithValue("@unitsOnOrder", 2);
                cmd.Parameters.AddWithValue("@reorderLevel", 10);
                cmd.Parameters.AddWithValue("@discontinued", 0);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
