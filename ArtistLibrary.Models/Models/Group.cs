using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtistLibrary.Models.Models
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }

        [Required]
        public string GroupName { get; set; }

        [Required]
        public string GroupDebutDate { get; set; }

        [Required]
        public string GroupMusicGenre { get; set; }

        [Required]
        public string GroupPhoto { get; set; }
    }
}
