namespace Computers.Interfaces
{
    using Computers.ComputerFactory.Parts;

    public interface IVideoCard
    {
        VideoCardType Type { get; set; }

        void Draw(string text);
    }
}
