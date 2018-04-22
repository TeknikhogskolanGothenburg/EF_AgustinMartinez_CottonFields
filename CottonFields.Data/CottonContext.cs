using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using CottonFields.Domain;

namespace CottonFields.Data
{
    public class CottonContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<MatrixNumber> MatrixNumber { get; set; }
        public DbSet<Release> Releases { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<User> Users { get; set; }

        public static readonly LoggerFactory CottonLoggerFactory
            = new LoggerFactory(new[] {
            new ConsoleLoggerProvider((category, level)
                => category == DbLoggerCategory.Database.Command.Name
                && level == LogLevel.Information, true)
            });

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRelease>().HasKey(m => new { m.UserID, m.ReleaseID});
        }

        protected override void OnConfiguring (DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder
                .EnableSensitiveDataLogging()
                .UseLoggerFactory(CottonLoggerFactory)
                .UseSqlServer("Data Source=DESKTOP-FAGSG73\\SQLEXPRESS;Initial Catalog=CottonDb;Integrated Security=True;Pooling=False");
        }
    }
}
//.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = CottonDb; Trusted_Connection = True;");