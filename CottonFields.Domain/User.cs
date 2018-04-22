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
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Country { get; set; }
        public int Phone { set; get; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<UserRelease> Releases { get; set; }
    }
}
