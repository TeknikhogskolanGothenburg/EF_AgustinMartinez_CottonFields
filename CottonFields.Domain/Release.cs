using System;
using System.Collections.Generic;

namespace CottonFields.Domain
{
    public class Release
    {
        public Release()
        {
            Tracks = new List<Track>();
            MatrixNumbers = new List<MatrixNumber>();
            Users = new List<UserRelease>();
        }
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<Track> Tracks { get; set; }
        public List<MatrixNumber> MatrixNumbers { get; set; }
        public List<UserRelease> Users { get; set; }
    }
}
