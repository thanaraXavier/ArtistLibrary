using ArtistLibrary.DataAccess;
using ArtistLibrary.Models.Models;
using ArtistLibrary.Models.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ArtistLibrary.Controllers
{
    public class SolistDetailsController : Controller
    {
        private readonly AppDbContext _db;
        public SolistDetailsController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetDetails(int solistId)
        {
            var solistDetails = _db.SolistDetails.FirstOrDefault(s => s.SolistId == solistId);

            if (solistDetails == null)
            {
                // Armazena o solistId no ViewBag para passar para a view
                ViewBag.SolistId = solistId;
                return View();
            }

            return View(solistDetails);
        }

        // Exibe o formulário para adicionar detalhes do solista
        [HttpGet]
        public IActionResult AddSolistDetails(int solistId)
        {
            var model = new SolistDetailsDTO { SolistId = solistId };
            return View(model);
        }

        // Recebe os dados do formulário e salva no banco de dados
        [HttpPost]
        public IActionResult AddSolistDetails(SolistDetailsDTO newSolistDetails)
        {
            if (ModelState.IsValid)
            {
                var solistDetails = new SolistDetails
                {
                    SolistRealName = newSolistDetails.SolistRealName,
                    SolistAnniversary = newSolistDetails.SolistAnniversary,
                    SolistNationality = newSolistDetails.SolistNationality,
                    SolistInstagram = newSolistDetails.SolistInstagram,
                    SolistPhoto = newSolistDetails.SolistPhoto,
                    SolistId = newSolistDetails.SolistId,
                };

                _db.SolistDetails.Add(solistDetails);
                _db.SaveChanges();

                // Após salvar, redireciona para a página de detalhes do solista
                return RedirectToAction("GetDetails", new { solistId = solistDetails.SolistId });
            }

            // Se o modelo não for válido, retorna a mesma view com os dados preenchidos
            return View(newSolistDetails);
        }
    }
}
