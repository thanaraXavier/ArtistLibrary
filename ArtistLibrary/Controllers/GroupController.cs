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

        [HttpGet]
        public IActionResult GetAllGroups()
        {
            var groupVM = new GroupVM()
            {
                Groups = _db.Groups.ToList()
            };

            return View(groupVM);
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
                return RedirectToAction("Index", "Home"); // Redirecionar após adicionar
            }

            return View(newGroup);
        }
    }
}
