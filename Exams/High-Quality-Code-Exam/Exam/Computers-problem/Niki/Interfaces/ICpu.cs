namespace Computers.Interfaces
{
    public interface ICpu
    {
        byte NumberOfCores { get; set; }

        byte NumberOfBits { get; set; }

        int GenerateRandomNumber(int min, int max);

        void SaveValueToRam(int value);

        void CalculateSquareNumber();
    }
}
