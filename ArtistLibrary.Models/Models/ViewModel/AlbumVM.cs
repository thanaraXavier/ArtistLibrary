using ArtistLibrary.Models.Models; // Para usar Album

namespace ArtistLibrary.Models.Models.ViewModel
{
    public class AlbumVM
    {
        public List<Album> Albums { get; set; }
        public List<string> ArtistNames { get; set; }
    }
}
