namespace ArtistLibrary.Models.Models
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public List<string> AlbumTracklist { get; set; }
        public DateTime AlbumRelease { get; set; }
        public string AlbumCover { get; set; }
    }
}
