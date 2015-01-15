namespace _05.Remove_Negatives
{
    using System;
    using System.Collections.Generic;

    class EntryPoint
    {
        static void Main(string[] args)
        {
            List<int> sequence = new List<int>() { 1, 2, -10, 14, -5, -2, 13, 25, -14 };
            List<int> elementsToRemove = new List<int>();

            int sequenceLength = sequence.Count;
            for (int i = 0; i < sequenceLength; i++)
            {
                if (sequence[i] < 0)
                {
                    elementsToRemove.Add(sequence[i]);
                }
            }

            foreach (int num in elementsToRemove)
            {
                sequence.Remove(num);
            }

            Console.WriteLine("Only positives in sequence: {0}", String.Join(", ", sequence));
        }
    }
}
