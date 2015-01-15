namespace _01.Read_Integers_From_The_Console
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

            double sum = CalculateSum(sequence);
            double average = sum / sequence.Count;

            Console.WriteLine("Sum: {0}, Average: {1}", sum, average);
        }
  
        private static int CalculateSum(List<int> sequence)
        {
            int sum = 0;

            foreach (int num in sequence)
            {
                sum += num;
            }

            return sum;
        }
    }
}
