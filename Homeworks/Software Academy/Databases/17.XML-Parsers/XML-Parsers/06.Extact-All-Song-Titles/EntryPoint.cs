namespace _06.Extact_All_Song_Titles
{
    using System;
    using System.Linq;
    using System.Xml.Linq;
 
    class EntryPoint
    {
        public static void Main()
        {
            XDocument doc = XDocument.Load("../../catalog.xml");
            var songs =
                from song in doc.Descendants("song")
                select new
                {
                    Title = song.Element("title").Value,
                    Duration = song.Element("duration").Value
                };

            foreach (var song in songs)
            {
                Console.WriteLine("{0} => {1}", song.Title, song.Duration);
            }
        }
    }
}
