using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArtistLibrary.Models.Models.DTOs
{
    public class GroupDetailsDTO
    {
        public string MemberStageName { get; set; }
        public string MemberRealName { get; set; }
        public string MemberAnniversary { get; set; }
        public string MemberNationality { get; set; }
        public string MemberPosition { get; set; }
        public string MemberPhoto { get; set; }
        public string? MemberInstagram { get; set; }
        public int GroupId { get; set; }
    }
}
