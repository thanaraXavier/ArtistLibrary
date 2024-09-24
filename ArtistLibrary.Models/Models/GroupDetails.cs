using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtistLibrary.Models.Models
{
    public class GroupDetails
    {
        [Key]
        [Required]
        public int MemberId { get; set; }

        [Required]
        public string MemberStageName { get; set; }

        [Required]
        public string MemberRealName { get; set; }

        [Required]
        public string MemberAnniversary { get; set; }

        [Required]
        public string MemberNationality { get; set; }

        [Required]
        public string MemberPosition { get; set; }

        [Required]
        public string MemberPhoto { get; set; }
        public string? MemberInstagram { get; set; }

        [ForeignKey("Group")]
        [Required]
        public int GroupId { get; set; }

        // Navigation property
        public Group Group { get; set; }
    }
}
