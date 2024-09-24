using ArtistLibrary.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtistLibrary.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Solist> Solists { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<SolistDetails> SolistDetails { get; set; }
    }
}
