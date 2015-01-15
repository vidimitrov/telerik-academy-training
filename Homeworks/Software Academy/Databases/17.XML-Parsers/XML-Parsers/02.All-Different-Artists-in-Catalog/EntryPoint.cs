namespace _02.All_Different_Artists_in_Catalog
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

            var rootNode = doc.DocumentElement;
            Dictionary<string, int> artists = new Dictionary<string, int>();

            foreach (XmlElement child in rootNode.ChildNodes)
            {
                string artistName = child["artist"].InnerText;
                
                if (artists.ContainsKey(artistName)) 
                {
                    artists[artistName]++;
                }
                else
                {
                    artists[artistName] = 1;
                }
                
            }

            foreach (var artist in artists)
            {
                Console.WriteLine("Artist: {0} => Number of albums: {1}", artist.Key, artist.Value);
            }
        }
    }
}
