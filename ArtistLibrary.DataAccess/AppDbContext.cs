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
        public DbSet<GroupDetails> GroupDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SolistDetails>().HasData(
                new SolistDetails
                {
                    SolistDetailId = 1,
                    SolistRealName = "Elizabeth Woolridge Grant",
                    SolistAnniversary = "21/06/1985",
                    SolistNationality = "American",
                    SolistInstagram = "honeymoon",
                    SolistPhoto = "https://i.imgur.com/SLwB5GO.jpeg",
                    SolistId = 2
                }
            );

            modelBuilder.Entity<GroupDetails>().HasData(
                new GroupDetails
                {
                    MemberId = 1,
                    MemberStageName = "Felp22",
                    MemberRealName = "Felipe Laurindo de Carvalho",
                    MemberAnniversary = "02/07/1992",
                    MemberNationality = "Brazilian",
                    MemberPosition = "Vocalist",
                    MemberPhoto = "https://i.imgur.com/LDapGbF.jpeg",
                    MemberInstagram = "felpcacife",
                    GroupId = 7
                }
            );
        }
    }
}
