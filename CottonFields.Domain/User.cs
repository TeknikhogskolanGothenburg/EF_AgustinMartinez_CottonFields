using System;
using System.Collections.Generic;

namespace CottonFields.Domain
{
    public class User
    {
        public User()
        {
            Releases = new List<UserRelease>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Nationality { get; set; }
        public int phone { set; get; }
        public string email { get; set; }
        public string password { get; set; }
        public List<UserRelease> Releases { get; set; }
    }
}
