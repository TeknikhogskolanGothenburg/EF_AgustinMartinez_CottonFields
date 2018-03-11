using System.Collections.Generic;

namespace CottonFields.Domain
{
    public class Label
    {
        public Label()
        {
            Releases = new List<Release>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public List<Release> Releases { get; set; }
    }
}
