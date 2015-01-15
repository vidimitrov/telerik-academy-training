namespace Phonebook.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Phonebook.Core.Interfaces;
    using Wintellect.PowerCollections;

    class PhonebookRepositorySlow : IPhonebookRepository
    {
        private OrderedSet<PhonebookEntry> sorted = new OrderedSet<PhonebookEntry>();
        private Dictionary<string, PhonebookEntry> dict = new Dictionary<string, PhonebookEntry>();
        private MultiDictionary<string, PhonebookEntry> multidict = new MultiDictionary<string, PhonebookEntry>(false);

        public bool AddPhone(string name, IEnumerable<string> nums)
        {
            string name2 = name.ToLowerInvariant();
            PhonebookEntry entry; 
            
            bool flag = !this.dict.TryGetValue(name2, out entry);
            if (flag)
            {
                entry = new PhonebookEntry(); 
                entry.Name = name;
                entry.PhoneNumbers = new SortedSet<string>(); 
                this.dict.Add(name2, entry);
                this.sorted.Add(entry);
            }

            foreach (var num in nums)
            {
                this.multidict.Add(num, entry);
            }

            entry.PhoneNumbers.UnionWith(nums);

            return flag;
        }

        public int ChangePhone(string oldent, string newent)
        {
            var found = this.multidict[oldent].ToList(); foreach (var entry in found)
            {
                entry.PhoneNumbers.Remove(oldent);
                this.multidict.Remove(oldent, entry);
                entry.PhoneNumbers.Add(newent); 
                this.multidict.Add(newent, entry);
            }

            return found.Count;
        }

        public IEnumerable<PhonebookEntry> ListEntries(int first, int num)
        {
            if (first < 0 || first + num > this.dict.Count) 
            { 
                Console.WriteLine("Invalid start index or count."); 
                return null; 
            }

            PhonebookEntry[] list = new PhonebookEntry[num];

            for (int i = first; i <= first + num - 1; i++)
            {
                PhonebookEntry entry = this.sorted[i];
                list[i - first] = entry;
            }

            return list;
        }
    }
}
