namespace _07.Occurances_In_Interval
{
    using System;
    using System.Collections.Generic;

    class EntryPoint
    {
        static void Main(string[] args)
        {
            List<int> sequence = new List<int>() { 1123, 19, 19, 2, 2200, 3, 2, 15555, 100, 19, 3441, 4421, 999, 155, 1, 999, 14};
            Dictionary<int, int> occurances = new Dictionary<int, int>();

            int sequenceLength = sequence.Count;
            for (int i = 0; i < sequenceLength; i++)
            {
                if (!occurances.ContainsKey(sequence[i])) 
                {
                    if (sequence[i] >= 0 && sequence[i] <= 1000)
                    {
                        occurances[sequence[i]] = 1;
                    }
                }
                else
                {
                    occurances[sequence[i]]++;
                }
            }
            
            foreach (KeyValuePair<int, int> occurance in occurances)
            {
                 Console.WriteLine("{0} -> {1}", occurance.Key, occurance.Value);
            }

           
        }
    }
}
