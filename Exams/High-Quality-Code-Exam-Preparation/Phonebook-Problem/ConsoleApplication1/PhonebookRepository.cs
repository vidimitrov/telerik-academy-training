namespace Phonebook.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Phonebook.Core.Interfaces;

    public class PhonebookRepository : IPhonebookRepository, IRemovablePhonebookRepository
    {
        private List<PhonebookEntry> phonebookEntries;

        public PhonebookRepository()
            :this(new List<PhonebookEntry>())
        {
        }

        public PhonebookRepository(List<PhonebookEntry> phonebookEntries)
        {
            this.phonebookEntries = phonebookEntries;
        }

        public bool AddPhone(string name, IEnumerable<string> nums)
        {
            var old = from e in this.phonebookEntries where e.Name.ToLowerInvariant() == name.ToLowerInvariant() select e;

            bool flag;
            if (old.Count() == 0)
            {
                PhonebookEntry obj = new PhonebookEntry(); 
                obj.Name = name;
                obj.PhoneNumbers = new SortedSet<string>();

                foreach (var num in nums)
                {
                    obj.PhoneNumbers.Add(num);
                }

                this.phonebookEntries.Add(obj);

                flag = true;
            }
            else if (old.Count() == 1)
            {
                PhonebookEntry obj2 = old.First();

                foreach (var num in nums)
                {
                    obj2.PhoneNumbers.Add(num);
                } 
                
                flag = false;
            }
            else
            {
                Console.WriteLine("Duplicated name in the phonebook found: " + name);
                return false;
            }

            return flag;
        }

        public int ChangePhone(string oldPhoneNumber, string newPhoneNumber)
        {
            var list = this.phonebookEntries.Where(entry => entry.PhoneNumbers.Contains(oldPhoneNumber));

            foreach (var entry in list)
            {
                entry.PhoneNumbers.Remove(oldPhoneNumber); 
                entry.PhoneNumbers.Add(newPhoneNumber);
            }

            return list.Count();
        }

        public IEnumerable<PhonebookEntry> ListEntries(int start, int num)
        {
            if (start < 0 || start + num > this.phonebookEntries.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid start index or count.");
            }

            this.phonebookEntries.Sort();

            PhonebookEntry[] ent = new PhonebookEntry[num]; 
            for (int i = start; i <= start + num - 1; i++)
            {
                PhonebookEntry entry = this.phonebookEntries[i];
                ent[i - start] = entry;
            }

            return ent;
        }

        public void DeletePhone(string phoneNumber)
        {
            throw new NotImplementedException();
        }
    }
}
