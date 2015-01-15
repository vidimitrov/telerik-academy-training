using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;

namespace _05.Images_from_Northwind
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            SqlConnection dbCon = new SqlConnection("Server=.; " +
            "Database=Northwind; Integrated Security=true");

            dbCon.Open();

            using (dbCon)
            {
                string query = "SELECT Picture FROM Categories";
                
                SqlCommand cmd = new SqlCommand(query, dbCon);

                SqlDataReader images = cmd.ExecuteReader();
                int indexer = 0;

                while (images.Read()) {
                    byte[] image = (byte[])images["Picture"];

                    ImageConverter converter = new System.Drawing.ImageConverter();
                    Image img = (Image)converter.ConvertFrom(image);

                    using(img)
                    {
                        img.Save("output" + indexer + ".jpg", ImageFormat.Jpeg);
                    }

                    indexer++;
                }

                //Look in the Debug folder. There will be the images.
            }
        }
    }
}
