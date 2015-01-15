namespace _07.Append_Row_to_Excel_File
{
    using System;
    using System.Data;
    using System.Data.OleDb;

    class EntryPoint
    {
        static void Main()
        {
            string filePath = @"C:\Users\vesel_000\Documents\Visual Studio 2013\Projects\Databases-ADO.NET\Persons.xlsx";
            string sheetName = "Persons";

            string insertQuery = "INSERT INTO [" + sheetName + "$](Name, Score) VALUES ('Gencho Genev', 100)";
            AppendRowToExcelFile(filePath, sheetName, insertQuery);
        }

        private static void AppendRowToExcelFile(string filePath, string sheetName, string insertQuery)
        {
            OleDbConnection connection = new OleDbConnection();

            using (connection)
            {
                DataTable table = new DataTable();

                connection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties='Excel 12.0 Xml;HDR=YES;'";

                OleDbCommand command = new OleDbCommand();
                using (command)
                {
                    command.CommandText = insertQuery;//"SELECT * FROM [" + sheetName + "$]";
                    command.Connection = connection;

                    command.ExecuteNonQuery();

                    //OleDbDataAdapter adapter = new OleDbDataAdapter();
                    //using (adapter)
                    //{
                    //    adapter.SelectCommand = command;
                    //    adapter.Fill(table);
                        
                    //    //table.Rows.Add(new PersonRecord("Vesko Dimitrov", 150));
                    //    table.Rows.RemoveAt(0);

                    //    table.AcceptChanges();
                    //    adapter.Update(table);
                    //}
                }
            }
        }
    }

    class PersonRecord
    {
        public PersonRecord(string name, int score)
        {
            this.Name = name;
            this.Score = score;
        }

        public string Name { get; set; }
        public int Score { get; set; }
    }
}
