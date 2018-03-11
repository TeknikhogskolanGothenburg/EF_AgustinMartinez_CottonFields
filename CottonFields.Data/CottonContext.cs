using CottonFields.Domain;
using Microsoft.EntityFrameworkCore;

namespace CottonFields.Data
{
    public class CottonContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<MatrixNumber> MatrixNumbers { get; set; }
        public DbSet<Release> Releases { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRelease>().HasKey(m => new { m.UserID, m.ReleaseID});
        }

        protected override void OnConfiguring (DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = CottonDb; Trusted_Connection = True;");
        }
    }
}
