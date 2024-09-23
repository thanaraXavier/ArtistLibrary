using ArtistsWiki.DataAccess;
using ArtistsWiki.Models.Models.ViewModels;
using ArtistsWiki.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Group = ArtistsWiki.Models.Models.Group;
using Microsoft.EntityFrameworkCore;

namespace ArtistsWiki.Controllers
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
                return RedirectToAction("Index", "Home"); // Redirecionar após adicionar
            }

            return View(newGroup);
        }

    }
}
