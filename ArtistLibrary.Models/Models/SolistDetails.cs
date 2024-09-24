using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtistLibrary.Models.Models
{
    public class SolistDetails
    {
        [Required]
        [Key]
        public int SolistDetailId { get; set; }

        [Required]
        public string SolistRealName { get; set; }

        [Required]
        public string SolistAnniversary { get; set; }

        [Required]
        public string SolistNationality { get; set; }
        public string? SolistInstagram { get; set; }

        [Required]
        public string SolistPhoto { get; set; }

        // Foreign key for Solist
        [Required]
        [ForeignKey("Solist")]
        public int SolistId { get; set; }

        // Navigation property
        public Solist Solist { get; set; }
    }
}
