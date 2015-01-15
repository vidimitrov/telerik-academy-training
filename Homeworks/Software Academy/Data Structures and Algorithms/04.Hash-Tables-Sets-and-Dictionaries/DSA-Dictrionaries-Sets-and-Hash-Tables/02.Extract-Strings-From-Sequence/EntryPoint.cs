namespace _02.Extract_Strings_From_Sequence
{
    using System;
    using System.Collections.Generic;

    class EntryPoint
    {
        static void Main()
        {
            string[] strings = new string[] { "SQL", "C#", "C#", "JavaScript", "C#", "SQL" };

            var map = new Dictionary<string, int>();

            foreach (var value in strings)
            {
                if (!map.ContainsKey(value)) 
                {
                    map[value] = 1;
                }
                else
                {
                    map[value]++;
                }
            }

            List<string> oddOccuranceStrings = new List<string>();

            foreach (var value in map)
            {
                if (value.Value % 2 != 0)
                {
                    oddOccuranceStrings.Add(value.Key);
                }
            }

            Console.WriteLine("Odd occurance stings: {0}", string.Join(", ", oddOccuranceStrings));
        }
    }
}
