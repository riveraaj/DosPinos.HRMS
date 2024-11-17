using DosPinos.HRMS.Entities.DTOs.ChristmasBonus;
using DosPinos.HRMS.Entities.DTOs.Commons.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DosPinos.HRMS.WebApp.Controllers.ChristmasBonus
{
    [Authorize]
    public class ChristmasBonusController(HRMS.Controllers.ChristmasBonus.ChristmasBonusController christmas) : Controller
    {
        private readonly HRMS.Controllers.ChristmasBonus.ChristmasBonusController _christmas = christmas;

        public IActionResult Index()
        {
            if (TempData["ChristmasData"] is string christmasData)
            {
                var christmasList = JsonConvert.DeserializeObject<List<GetAllChristmasBonusDTO>>(christmasData);
                return View(christmasList);
            }

            // Si no hay datos en TempData, pasar un modelo predeterminado
            return View(new List<GetAllChristmasBonusDTO>());
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            var response = await _christmas.CreateAsync(new EntityDTO()
            {
                //UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value)
                UserId = 1
            });

            ViewData["alert"] = response;
            TempData["ChristmasData"] = JsonConvert.SerializeObject(response.Content);
            return RedirectToAction("Index");
        }
    }
}