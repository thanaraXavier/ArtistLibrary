using ArtistLibrary.DataAccess;
using ArtistLibrary.Models.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Group = ArtistLibrary.Models.Models.Group;

namespace ArtistLibrary.Controllers
{
    public class GroupsController : Controller
    {
        private readonly AppDbContext _db;
        public GroupsController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult GetAllGroups(string name, string genre, string debutDate)
        {
            var groups = _db.Groups.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                groups = groups.Where(g => g.GroupName.Contains(name));
            }

            if (!string.IsNullOrEmpty(genre))
            {
                groups = groups.Where(g => g.GroupMusicGenre.Contains(genre));
            }

            if (!string.IsNullOrEmpty(debutDate))
            {
                groups = groups.Where(g => g.GroupDebutDate.Contains(debutDate));
            }

            var viewModel = new GroupVM
            {
                Groups = groups.ToList()
            };

            return View(viewModel);
        }


        [HttpGet]
        public IActionResult AddNewGroup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewGroup(Group newGroup)
        {
            if (ModelState.IsValid)
            {
                _db.Groups.Add(newGroup);
                _db.SaveChanges();
                return RedirectToAction("GetAllGroups", "Groups"); // Redirecionar após adicionar
            }

            return View(newGroup);
        }

    }
}
