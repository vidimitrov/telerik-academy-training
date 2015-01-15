namespace Computers.Interfaces
{
    public interface IRam
    {
        int Amount { get; set; }

        void SaveValue(int newValue);

        int LoadValue();
    }
}
