namespace _03.Sort_Integers
{
    using System;
    using System.Collections.Generic;

    class EntryPoint
    {
        static void Main(string[] args)
        {
            List<int> sequence = new List<int>();

            Console.WriteLine("Enter the sequence of numbers:");
            
            int inputNumber;
            bool isValid;
            string input;
            do
            {
                input = Console.ReadLine();
                isValid = int.TryParse(input, out inputNumber);
                if (isValid && inputNumber > 0)
                {
                    sequence.Add(inputNumber);
                }
            }
            while (!String.IsNullOrEmpty(input));

            sequence.Sort();

            Console.WriteLine("Sorted in increasing order: {0}", String.Join(", ", sequence));
        }
    }
}
