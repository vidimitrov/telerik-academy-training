namespace _01.Knapsack_Problem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class EntryPoint
    {
        private static void Main()
        {
            Item[] items = new Item[]{
                                    new Item("beer", 3, 2),
                                    new Item("vodka", 8, 12),
                                    new Item("cheese", 4, 5),
                                    new Item("nuts", 1, 4),
                                    new Item("ham", 2, 3),
                                    new Item("whiskey", 8, 13),
                                    new Item("bread", 1, 2),
                                    new Item("melon", 3, 5),
            };

            int capacity = 10;

            Console.WriteLine("Best choice: ");

            Console.WriteLine("Dynamic: " + String.Join(" ", KnapsackDynamic(items, capacity).Select(r => r.Name)));
            Console.WriteLine("Recursive: " + String.Join(" ", KnapsackRecursive(items, capacity).Select(r => r.Name)));
        }

        public static List<Item> KnapsackDynamic(Item[] items, int capacity)
        {
            if (capacity == 0)
                return new List<Item>();

            if (items.Length == 0)
                return new List<Item>();

            int[,] valuesArray = new int[items.Length, capacity + 1];

            int[,] keepArray = new int[items.Length, capacity + 1];

            for (int x = 0; x <= items.Length - 1; x++)
            {
                valuesArray[x, 0] = 0;
                keepArray[x, 0] = 0;
            }

            for (int y = 1; y <= capacity; y++)
            {
                if (items[0].Weight <= y)
                {
                    valuesArray[0, y] = items[0].Value;
                    keepArray[0, y] = 1;
                }
                else
                {
                    valuesArray[0, y] = 0;
                    keepArray[0, y] = 0;
                }
            }

            for (int x = 0; x <= items.Length - 2; x++)
            {
                for (int y = 1; y <= capacity; y++)
                {
                    var currentItem = items[x + 1];

                    if (currentItem.Weight > y)
                    {
                        valuesArray[x + 1, y] = valuesArray[x, y];

                        continue;
                    }

                    int valueWhenDropping = valuesArray[x, y];
                    int valueWhenTaking = valuesArray[x, y - currentItem.Weight] + currentItem.Value;
                    
                    if (valueWhenTaking > valueWhenDropping)
                    {
                        valuesArray[x + 1, y] = valueWhenTaking;
                        keepArray[x + 1, y] = 1;
                    }
                    else
                    {
                        valuesArray[x + 1, y] = valueWhenDropping;
                        keepArray[x + 1, y] = 0;
                    }
                }
            }
            
            var bestItems = new List<Item>();

            {
                int remainingSpace = capacity;
                int item = items.Length - 1;

                while (item >= 0 && remainingSpace >= 0)
                {
                    if (keepArray[item, remainingSpace] == 1)
                    {
                        bestItems.Add(items[item]);
                        remainingSpace -= items[item].Weight;
                        item -= 1;
                    }
                    else
                    {
                        item -= 1;
                    }
                }
            }

            return bestItems;
        }

        public static List<Item> KnapsackRecursive(Item[] items, int capacity)
        {
            if (capacity <= 0 || items.Length == 0)
                return new List<Item>();

            var x = items.Length - 1;
            var currentItem = items[x];

            var bestWhenDropping = KnapsackRecursive(items.Take(x).ToArray(), capacity);

            if (capacity < currentItem.Weight)
                return bestWhenDropping;

            var bestWhenTaking = KnapsackRecursive(items.Take(x).ToArray(), capacity - currentItem.Weight);

            bestWhenTaking.Add(currentItem);


            var valueWhenTaking = bestWhenTaking.Sum(i => i.Value);
            var valueWhenDropping = bestWhenDropping.Sum(i => i.Value);

            if (valueWhenTaking > valueWhenDropping)
            {
                return bestWhenTaking;
            }
            else
            {
                return bestWhenDropping;
            }
        }

        public static void PrintMatrix(int[,] mx, int untilRow, Item[] items)
        {
            const int FOO = 17;

            Console.Write("R ITEM     W  V |");

            for (int col = 0; col < mx.GetLength(1); ++col)
            {
                Console.Write((col + "").PadLeft(2, ' ').PadRight(3, ' '));
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', FOO + mx.GetLength(1) * 3));

            for (int row = 0; row <= untilRow; ++row)
            {
                Console.Write("{0} ", row);
                Console.Write("{0:0} ", items[row].Name.PadRight(8, ' '));
                Console.Write("{0:0} ", items[row].Weight);
                Console.Write("{0:0} |", (items[row].Value + "").PadLeft(2, ' '));

                for (int col = 0; col < mx.GetLength(1); ++col)
                {
                    Console.Write("{0:00} ", mx[row, col]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();

        }
    }
}
