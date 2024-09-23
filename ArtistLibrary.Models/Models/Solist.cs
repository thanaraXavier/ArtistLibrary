using System.ComponentModel.DataAnnotations;

namespace ArtistLibrary.Models.Models
{
    public class Solist
    {
        [Key]
        public int SolistId { get; set; }

        [Required]
        public string SolistName { get; set; }

        [Required]
        public string SolistDebutDate { get; set; }

        [Required]
        public string SolistMusicGenre { get; set; }

        [Required]
        public string SolistPhoto { get; set; }
    }
}
