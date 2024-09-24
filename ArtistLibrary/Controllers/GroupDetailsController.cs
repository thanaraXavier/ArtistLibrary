using ArtistLibrary.DataAccess;
using ArtistLibrary.Models.Models.DTOs;
using ArtistLibrary.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ArtistLibrary.Controllers
{
    public class GroupDetailsController : Controller
    {
        private readonly AppDbContext _db;
        public GroupDetailsController(AppDbContext db)
        {
            _db = db;
        }

        // Exibe os detalhes de todos os membros de um grupo específico
        [HttpGet]
        public IActionResult GetDetails(int groupId)
        {
            var groupDetails = _db.GroupDetails.Where(s => s.GroupId == groupId).ToList();

            if (!groupDetails.Any())
            {
                ViewBag.GroupId = groupId;
                return View(Enumerable.Empty<GroupDetails>()); // Retorna uma lista vazia se não houver membros
            }

            ViewBag.GroupId = groupId;
            return View(groupDetails);
        }

        // Exibe o formulário para adicionar um novo membro a um grupo
        [HttpGet]
        public IActionResult AddGroupDetails(int groupId)
        {
            var model = new GroupDetailsDTO { GroupId = groupId };
            return View(model);
        }

        // Recebe os dados do formulário e salva no banco de dados
        [HttpPost]
        public IActionResult AddGroupDetails(GroupDetailsDTO newGroupDetails)
        {
            if (ModelState.IsValid)
            {
                var groupDetails = new GroupDetails
                {
                    MemberStageName = newGroupDetails.MemberStageName,
                    MemberRealName = newGroupDetails.MemberRealName,
                    MemberAnniversary = newGroupDetails.MemberAnniversary,
                    MemberNationality = newGroupDetails.MemberNationality,
                    MemberPosition = newGroupDetails.MemberPosition,
                    MemberPhoto = newGroupDetails.MemberPhoto,
                    MemberInstagram = newGroupDetails.MemberInstagram,
                    GroupId = newGroupDetails.GroupId,
                };

                _db.GroupDetails.Add(groupDetails);
                _db.SaveChanges();

                // Após salvar, redireciona para a página de detalhes de todos os membros do grupo
                return RedirectToAction("GetDetails", new { groupId = groupDetails.GroupId });
            }

            // Se o modelo não for válido, retorna a mesma view com os dados preenchidos
            return View(newGroupDetails);
        }
    }
}
