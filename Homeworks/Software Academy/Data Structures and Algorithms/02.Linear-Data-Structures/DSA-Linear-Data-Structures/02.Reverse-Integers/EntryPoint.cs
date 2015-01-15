namespace _02.Reverse_Integers
{
    using System;
    using System.Collections.Generic;

    class EntryPoint
    {
        static void Main(string[] args)
        {
            Stack<int> numbers = new Stack<int>();

            Console.Write("N = ");
            string inputNumbersCount = Console.ReadLine();
            int numbersCount = int.Parse(inputNumbersCount);

            string inputNumber;
            int number;
            for (int i = 0; i < numbersCount; i++)
            {
                Console.Write("[{0}] = ", i);
                inputNumber = Console.ReadLine();
                number = int.Parse(inputNumber);
                numbers.Push(number);
            }

            Console.Write("Reversed: ");
            for (int i = 0; i < numbersCount; i++)
            {
                int poppedNumber = numbers.Pop();
                Console.Write("{0} ", poppedNumber);
            }
            Console.WriteLine();
        }
    }
}
