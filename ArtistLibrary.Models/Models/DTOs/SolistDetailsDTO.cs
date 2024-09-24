using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArtistLibrary.Models.Models.DTOs
{
    public class SolistDetailsDTO
    {
        public string SolistRealName { get; set; }
        public string SolistAnniversary { get; set; }
        public string SolistNationality { get; set; }
        public string? SolistInstagram { get; set; }
        public string SolistPhoto { get; set; }
        public int SolistId { get; set; }
    }
}
