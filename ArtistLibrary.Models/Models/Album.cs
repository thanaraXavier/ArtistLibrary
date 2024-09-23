using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtistLibrary.Models.Models
{
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }

        [Required]
        public string AlbumName { get; set; }

        // Alteração: Armazenar a lista de faixas como uma string
        [Required]
        public string AlbumTracklist { get; set; }

        [Required]
        public DateTime AlbumRelease { get; set; }

        [Required]
        public string AlbumCover { get; set; }

        // Foreign key for Group
        [ForeignKey("Group")]
        public int? GroupId { get; set; }

        // Navigation property
        public Group Group { get; set; }

        // Foreign key for Solist
        [ForeignKey("Solist")]
        public int? SolistId { get; set; }

        // Navigation property
        public Solist Solist { get; set; }
    }
}
