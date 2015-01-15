namespace Phonebook.Core.Interfaces
{
    using System.Collections.Generic;
    using Phonebook.Core;

    public interface IPhonebookRepository
    {
        bool AddPhone(string name, IEnumerable<string> phoneNumbers);

        int ChangePhone(string oldPhoneNumber, string newPhoneNumber);

        IEnumerable<PhonebookEntry> ListEntries(int startIndex, int count);
    }
}
