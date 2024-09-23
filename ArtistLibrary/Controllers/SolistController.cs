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
        public IActionResult GetAllSolists()
        {
            var solists = _db.Solists.ToList();

            var solistVM = new SolistVM()
            {
                Solists = solists,
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
