using ArtistsWiki.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace ArtistsWiki.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Solist> Solists { get; set; }
        public DbSet<Models.Models.Group> Groups { get; set; }
    }
}
