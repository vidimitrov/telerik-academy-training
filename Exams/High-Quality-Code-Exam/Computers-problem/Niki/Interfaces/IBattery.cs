namespace Computers.Interfaces
{
    public interface IBattery
    {
        int Percentage { get; set; }

        void Charge(int p);
    }
}
