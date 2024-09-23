using ArtistLibrary.DataAccess;
using ArtistLibrary.Models.DTOs;
using ArtistLibrary.Models.Models;
using ArtistLibrary.Models.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

public class AlbumController : Controller
{
    private readonly AppDbContext _db;

    public AlbumController(AppDbContext db)
    {
        _db = db;
    }
    public IActionResult GetAllAlbums()
    {
        var albums = _db.Albums.ToList();
        var artistNames = albums.Select(album =>
        {
            if (album.GroupId != null)
                return _db.Groups.Find(album.GroupId)?.GroupName;
            if (album.SolistId != null)
                return _db.Solists.Find(album.SolistId)?.SolistName;
            return "Desconhecido"; // Caso não tenha artista
        }).ToList();

        var albumVM = new AlbumVM()
        {
            Albums = albums,
            ArtistNames = artistNames
        };

        return View(albumVM);
    }

    [HttpGet]
    public IActionResult AddNewAlbum()
    {
        ViewBag.Solists = _db.Solists.ToList();
        ViewBag.Groups = _db.Groups.ToList();

        return View(new AlbumDTO());
    }

    [HttpPost]
    public IActionResult AddNewAlbum(AlbumDTO dto)
    {
        // Validação para garantir que o usuário não escolha ambos ou nenhum
        if (dto.GroupId == null && dto.SolistId == null ||
            dto.GroupId != null && dto.SolistId != null)
        {
            ModelState.AddModelError("", "Please select either a Group or a Solist, but not both.");
        }

        if (ModelState.IsValid)
        {
            var album = new Album
            {
                AlbumName = dto.AlbumName,
                AlbumTracklist = dto.AlbumTracklist,
                AlbumRelease = dto.AlbumRelease,
                AlbumCover = dto.AlbumCover,
                GroupId = dto.GroupId,
                SolistId = dto.SolistId
            };

            // Adiciona o álbum ao banco de dados
            _db.Albums.Add(album);
            _db.SaveChanges();

            return RedirectToAction("GetAllAlbums");
        }

        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                // Log ou exiba o erro
                Console.WriteLine(error.ErrorMessage);
            }
        }

        // Recarregar listas de solistas e grupos para a view
        ViewBag.Solists = _db.Solists.ToList();
        ViewBag.Groups = _db.Groups.ToList();

        return View(dto); // Retorna o DTO para preservar os dados já inseridos
    }
}
