namespace _03.All_Different_Artists_in_Catalog_XPath
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;

    class EntryPoint
    {
        public static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"../../catalog.xml");
            var query = @"/catalog/album";

            var albums = doc.SelectNodes(query);
            Dictionary<string, int> artists = new Dictionary<string, int>();

            foreach (XmlNode album in albums)
            {
                var artist = album.ChildNodes[1];
                if (artists.ContainsKey(artist.InnerText))
                {
                    artists[artist.InnerText]++;
                }
                else
                {
                    artists[artist.InnerText] = 1;
                }
            }

            foreach (var artist in artists)
            {
                Console.WriteLine("Artist: {0}, Albums: {1}", artist.Key, artist.Value);
            }
        }
    }
}
