using DosPinos.HRMS.Entities.DTOs.Commons.Base;
using DosPinos.HRMS.Entities.DTOs.Liquidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DosPinos.HRMS.WebApp.Controllers.Liquidations
{
    [Authorize]
    public class LiquidationController(HRMS.Controllers.Liquidations.LiquidationController liquidationController)
                                        : Controller
    {
        private readonly HRMS.Controllers.Liquidations.LiquidationController _liquidationController = liquidationController;

        public async Task<IActionResult> Index()
        {
            var response = await _liquidationController.GetAllAsync(new EntityDTO()
            {
                UserId = 1
            });

            return View(response.Content);
        }

        public async Task<IActionResult> Create(CreateLiquidationDTO liquidation)
        {
            liquidation.TerminationDate = DateOnly.FromDateTime(DateTime.Now);
            liquidation.UserId = 1;

            var response = await _liquidationController.CreateAsync(liquidation);

            TempData["alert"] = JsonConvert.SerializeObject(response);

            return RedirectToAction("Edit", "Employee", liquidation.Identification);
        }
    }
}