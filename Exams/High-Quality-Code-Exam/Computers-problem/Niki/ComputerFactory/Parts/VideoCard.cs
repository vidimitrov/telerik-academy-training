namespace Computers.ComputerFactory.Parts
{
    using System;
    using Computers.Interfaces;

    public class VideoCard : IVideoCard
    {
        private VideoCardType type;

        public VideoCard(VideoCardType type)
        {
            this.Type = type;
        }

        public VideoCardType Type
        {
            get
            {
                return this.type;
            }

            set
            {
                // Make a check, before assign
                this.type = value;
            }
        }

        public void Draw(string text)
        {
            if (this.type == VideoCardType.Monochrome)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(text);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(text);
                Console.ResetColor();
            }
        }
    }
}
