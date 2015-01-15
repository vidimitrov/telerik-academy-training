namespace _01.Count_Double_Values_Occurances
{
    using System;
    using System.Collections.Generic;

    class EntryPoint
    {
        static void Main()
        {
            double[] values = new double[] {3, 2.12, 4.51, 5.55, 1.34, 3.14, 2.12, 3, 1.34, 3};

            var map = new Dictionary<double, int>();

            foreach (var value in values)
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

            foreach (var pair in map)
            {
                Console.WriteLine("{0} => {1}", pair.Key, pair.Value);
            }
        }
    }
}
