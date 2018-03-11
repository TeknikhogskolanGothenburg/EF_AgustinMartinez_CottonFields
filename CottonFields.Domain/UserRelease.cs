namespace CottonFields.Domain
{
    public class UserRelease
    {
        public int UserID { get; set; }
        public int ReleaseID { get; set; }

        public User User { get; set; }
        public Release Release { get; set; }
    }
}
