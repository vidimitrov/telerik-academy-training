namespace _06.Read_Excel_File
{
    using System;
    using System.Data;
    using System.Data.OleDb;
    using System.IO;

    class EntryPoint
    {
        static void Main()
        {
            string filePath = @"C:\Users\vesel_000\Documents\Visual Studio 2013\Projects\Databases-ADO.NET\Persons.xlsx";
            string sheetName = "Persons";

            DataTable excelTable = ReadExcelFile(filePath, sheetName);

            foreach (DataRow row in excelTable.Rows)
            {
                Console.WriteLine("{0} -> {1}", row.ItemArray[0], row.ItemArray[1]);
            }
        }

        private static DataTable ReadExcelFile(string filePath, string sheetName)
        {
            OleDbConnection connection = new OleDbConnection();

            using (connection)
            {
                DataTable table = new DataTable();

                connection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties='Excel 12.0 Xml;HDR=YES;'";

                OleDbCommand command = new OleDbCommand();
                using (command)
                {
                    command.CommandText = "SELECT * FROM [" + sheetName + "$]";
                    command.Connection = connection;

                    OleDbDataAdapter adapter = new OleDbDataAdapter();
                    using (adapter)
                    {
                        adapter.SelectCommand = command;
                        adapter.Fill(table);
                        
                        return table;
                    }
                }
            }
        }
    }
}
