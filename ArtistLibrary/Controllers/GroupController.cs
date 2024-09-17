using ArtistsWiki.DataAccess;
using ArtistsWiki.Models.Models.ViewModels;
using ArtistsWiki.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Group = ArtistsWiki.Models.Models.Group;

namespace ArtistsWiki.Controllers
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
