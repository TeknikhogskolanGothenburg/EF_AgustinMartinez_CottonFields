using System.Collections.Generic;

namespace CottonFields.Domain
{
    public class Artist
    {
        public Artist()
        {
            Releases = new List<Release>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Members { get; set; }
        public string Nationality { get; set; }
        public List<Release> Releases { get; set; }
    }
}
