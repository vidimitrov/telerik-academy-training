namespace Phonebook.Core.Interfaces
{
    public interface IRemovablePhonebookRepository
    {
        void DeletePhone(string phoneNumber);
    }
}
