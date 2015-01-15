namespace _04.Hash_Table
{
    using System;

    class EntryPoint
    {
        static void Main()
        {
            DateTime start = DateTime.Now;
            var table = new HashDictionary<string, int>();
            var count = 1000000;

            for (var i = 0; i < count; i++)
            {
                table.Add("value" + i, i);
            }

            Console.WriteLine(DateTime.Now - start);
        }
    }
}
