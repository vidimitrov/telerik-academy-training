namespace _06.Remove_Odd_Occurances
{
    using System;
    using System.Collections.Generic;

    class EntryPoint
    {
        static void Main(string[] args)
        {
            List<int> sequence = new List<int>() { 1, 2, 2, 3, 15, 1, 9, 31, 4, 2, 15, 1, 1};
            Dictionary<int, int> occurances = new Dictionary<int, int>();

            int sequenceLength = sequence.Count;
            for (int i = 0; i < sequenceLength; i++)
            {
                if (!occurances.ContainsKey(sequence[i])) 
                {
                    occurances[sequence[i]] = 1;
                }
                else
                {
                    occurances[sequence[i]]++;
                }
            }
            
            foreach (KeyValuePair<int, int> occurance in occurances)
            {
                if (occurance.Value % 2 != 0) 
                {
                    while (sequence.Contains(occurance.Key)) {
                        sequence.Remove(occurance.Key);
                    }
                }
            }

            Console.WriteLine(String.Join(", ", sequence));
        }
    }
}
