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
        public DbSet<MatrixNumber> MatrixNumbers { get; set; }
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
                .UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = CottonDb; Trusted_Connection = True;");
        }
    }
}

//Data Source = (localdb)\MSSQLLocalDB;Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
