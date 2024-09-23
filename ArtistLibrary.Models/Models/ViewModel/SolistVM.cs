namespace ArtistsWiki.Models.Models.ViewModels
{
    public class SolistVM
    {
        public List<Solist> Solists { get; set; }

        // Um dicionário para armazenar o estado de existência dos detalhes
        public Dictionary<int, bool> HasDetails { get; set; }
        public IEnumerable<Solist> Solist { get; set; }
    }

}
