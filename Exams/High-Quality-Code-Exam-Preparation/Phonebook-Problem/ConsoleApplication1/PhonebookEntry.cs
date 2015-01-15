namespace Phonebook.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PhonebookEntry : IComparable<PhonebookEntry>
    {
        private string name; 
        private string nameInLowerInvariant;
        
        public ISet<string> PhoneNumbers { get; set; }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
                this.nameInLowerInvariant = value.ToLowerInvariant();
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(); 

            sb.Append('[');
            sb.Append(this.Name);
            sb.Append(": ");
            sb.Append(String.Join(", ", this.PhoneNumbers));
            sb.Append(']');

            return sb.ToString();
        }

        public int CompareTo(PhonebookEntry entry)
        {
            return this.nameInLowerInvariant.CompareTo(entry.nameInLowerInvariant);
        }
    }
}
