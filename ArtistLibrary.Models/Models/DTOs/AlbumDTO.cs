namespace ArtistLibrary.Models.DTOs
{
    public class AlbumDTO
    {
        public string AlbumName { get; set; }
        public string AlbumTracklist { get; set; }
        public string AlbumCover { get; set; }
        public DateTime AlbumRelease { get; set; }
        public int? GroupId { get; set; }
        public int? SolistId { get; set; }
    }
}
