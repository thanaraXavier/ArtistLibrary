namespace ArtistLibrary.Models.Models.ViewModels
{
    public class GroupVM
    {
        public List<Group> Groups { get; set; } = new List<Group>();
        public IEnumerable<Group> Group { get; set; }

    }
}
