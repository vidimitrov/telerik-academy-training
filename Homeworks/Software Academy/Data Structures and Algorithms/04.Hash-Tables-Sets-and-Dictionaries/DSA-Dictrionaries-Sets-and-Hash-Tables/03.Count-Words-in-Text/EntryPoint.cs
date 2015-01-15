namespace _03.Count_Words_in_Text
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class EntryPoint
    {
        static void Main()
        {
            string text = "This is the TEXT. Text, text, text - THIS TEXT! Is this the text?";

            List<string> words = text.Split(new char[] { ' ', '.', ',', '-', '!', '?', ';', ':' },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(w => w.Trim().ToLowerInvariant())
                .ToList();

            var map = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (!map.ContainsKey(word)) 
                {
                    map[word] = 1;
                }
                else
                {
                    map[word]++;
                }
            }

            foreach (var value in map)
            {
                Console.WriteLine("{0} => {1}", value.Key, value.Value);
            }
        }
    }
}
