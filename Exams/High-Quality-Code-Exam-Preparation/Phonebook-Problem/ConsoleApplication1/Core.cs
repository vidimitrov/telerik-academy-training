namespace Phonebook.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Phonebook.Core.Interfaces;

    public class Core
    {
        private const string DEFAULT_CODE = "+359";

        private static IPhonebookRepository data = new PhonebookRepository();
        private static StringBuilder input = new StringBuilder();

        static void Main()
        {
            while (true)
            {
                string inputCommand = Console.ReadLine();
                if (inputCommand == "End" || inputCommand == null)
                {
                    break;
                }

                int openBracketIndex = inputCommand.IndexOf('('); 
                if (openBracketIndex == -1) 
                {
                    break;
                }

                string command = inputCommand.Substring(0, openBracketIndex);
                
                if (!inputCommand.EndsWith(")"))
                {
                    continue;
                }

                string s = inputCommand.Substring(openBracketIndex + 1, inputCommand.Length - openBracketIndex - 2);
                string[] strings = s.Split(',');
                for (int j = 0; j < strings.Length; j++)
                {
                    strings[j] = strings[j].Trim();
                }

                if ((command.StartsWith("AddPhone")) && (strings.Length >= 2)) 
                { 
                    ProcessCommand("AddPhone", strings); 
                }
                else if ((command == "ChangePhone") && (strings.Length == 2)) 
                { 
                    ProcessCommand("ChangePhone", strings); 
                }
                else if ((command == "List") && (strings.Length == 2)) 
                { 
                    ProcessCommand("List", strings); 
                }
                else 
                { 
                    throw new StackOverflowException(); 
                }
            }
            Console.Write(input);
        }

        private static void ProcessCommand(string command, string[] strings)
        {
            if (command == "AddPhone")
            {
                string str0 = strings[0]; 

                var str1 = strings.Skip(1).ToList();
                for (int i = 0; i < str1.Count; i++)
                {
                    str1[i] = conv(str1[i]);
                }

                bool flag = data.AddPhone(str0, str1);

                if (flag)
                {
                    Print("Phone entry created");
                }
                else
                {
                    Print("Phone entry merged");
                }
            }
            else if (command == "ChangePhone")
            {
                Print("" + data.ChangePhone(conv(strings[0]), conv(strings[1])) + " numbers changed");
            }
            else
            {
                try
                {
                    IEnumerable<PhonebookEntry> entries = data.ListEntries(int.Parse(strings[0]), int.Parse(strings[1]));
                    foreach (var entry in entries)
                    {
                        Print(entry.ToString());
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Print("Invalid range");
                }
            }
                
        }
        private static string conv(string num)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <= input.Length; i++)
            {
                sb.Clear();
                foreach (char ch in num)
                {
                    if (char.IsDigit(ch) || (ch == '+')) 
                    {
                        sb.Append(ch);
                    }
                }

                if (sb.Length >= 2 && sb[0] == '0' && sb[1] == '0')
                { 
                    sb.Remove(0, 1); 
                    sb[0] = '+'; 
                }

                while (sb.Length > 0 && sb[0] == '0')
                {
                    sb.Remove(0, 1);
                }

                if (sb.Length > 0 && sb[0] != '+')
                {
                    sb.Insert(0, DEFAULT_CODE);
                }

                sb.Clear();

                foreach (char ch in num)
                {
                    if (char.IsDigit(ch) || (ch == '+')) 
                    { 
                        sb.Append(ch); 
                    }
                }

                if (sb.Length >= 2 && sb[0] == '0' && sb[1] == '0')
                { 
                    sb.Remove(0, 1); 
                    sb[0] = '+'; 
                }

                while (sb.Length > 0 && sb[0] == '0')
                {
                    sb.Remove(0, 1);
                }

                if (sb.Length > 0 && sb[0] != '+')
                {
                    sb.Insert(0, DEFAULT_CODE);
                }

                sb.Clear();

                foreach (char ch in num)
                {
                    if (char.IsDigit(ch) || (ch == '+'))
                    {
                        sb.Append(ch);
                    }
                }
                if (sb.Length >= 2 && sb[0] == '0' && sb[1] == '0')
                { 
                    sb.Remove(0, 1); 
                    sb[0] = '+'; 
                }

                while (sb.Length > 0 && sb[0] == '0')
                {
                    sb.Remove(0, 1);
                }

                if (sb.Length > 0 && sb[0] != '+')
                {
                    sb.Insert(0, DEFAULT_CODE);
                }
            }
            return sb.ToString();
        }
        private static void Print(string text)
        {
            input.AppendLine(text);
        }
    }
}
