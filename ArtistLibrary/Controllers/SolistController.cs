using ArtistLibrary.DataAccess;
using ArtistLibrary.Models.Models;
using ArtistLibrary.Models.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ArtistLibrary.Controllers
{
    public class SolistsController : Controller
    {
        private readonly AppDbContext _db;
        public SolistsController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetAllSolists(string name = null, string genre = null, string debutDate = null)
        {
            var solists = _db.Solists.AsQueryable(); // Não converta a lista aqui

            if (!string.IsNullOrEmpty(name))
            {
                solists = solists.Where(s => s.SolistName.Contains(name));
            }

            if (!string.IsNullOrEmpty(genre))
            {
                solists = solists.Where(s => s.SolistMusicGenre.Contains(genre));
            }

            if (!string.IsNullOrEmpty(debutDate))
            {
                solists = solists.Where(s => s.SolistDebutDate.Contains(debutDate));
            }

            var solistVM = new SolistVM()
            {
                Solists = solists.ToList(), // Converte para lista somente após aplicar os filtros
            };

            return View(solistVM);
        }

        [HttpGet]
        public IActionResult AddNewSolist()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewSolist(Solist newSolist)
        {
            if (ModelState.IsValid)
            {
                _db.Solists.Add(newSolist);
                _db.SaveChanges();
                return RedirectToAction("GetAllSolists", "Solists"); // Redirecionar após adicionar
            }

            return View(newSolist);
        }
    }
}
