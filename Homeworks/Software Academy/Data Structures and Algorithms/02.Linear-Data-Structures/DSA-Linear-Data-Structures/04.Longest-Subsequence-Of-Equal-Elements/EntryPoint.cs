namespace _04.Longest_Subsequence_Of_Equal_Elements
{
    using System;
    using System.Collections.Generic;

    class EntryPoint
    {
        static void Main(string[] args)
        {
            List<int> sequence = new List<int>() { 1, 1, 1, 1, 1, 1, 2, 3, 3, 3, 3, 3, 3, 3, 3, 4, 5, 5, 5, 5, 1};

            var longestSubsequence = GetLongestEqualSubsequence(sequence);

            Console.WriteLine("The longest subsequence is: {0}", String.Join(", ", longestSubsequence));
        }

        private static List<int> GetLongestEqualSubsequence(List<int> sequence)
        {
            List<int> subsequence = new List<int>();
            List<int> tempSubsequence = new List<int>();

            for (int i = 0; i < sequence.Count - 1; i++)
            {
                if (tempSubsequence.Count > 0)
                {
                    if (!tempSubsequence.Contains(sequence[i])) 
                    {
                        if (tempSubsequence.Count > subsequence.Count) 
                        {
                            subsequence.Clear();
                            subsequence.AddRange(tempSubsequence);
                        }

                        tempSubsequence.Clear();
                    }
                }
                    
                tempSubsequence.Add(sequence[i]);
            }

            return subsequence;
        }
    }
}
