using DosPinos.HRMS.Entities.DTOs.Commons.Base;
using DosPinos.HRMS.Entities.DTOs.Vacations;
using DosPinos.HRMS.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DosPinos.HRMS.WebApp.Controllers.Vacations
{
    [Authorize]
    public class VacationController(HRMS.Controllers.Vacation.VacationController controller) : Controller
    {
        private readonly HRMS.Controllers.Vacation.VacationController _controller = controller;

        public IActionResult Index() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateVacationDTO vacation)
        {
            vacation.EmployeeId = 3;
            vacation.UserId = 1;

            var response = await _controller.CreateAsync(vacation);

            ViewData["alert"] = response;

            return View("Index");
        }

        public async Task<IActionResult> Pending()
        {
            var response = await _controller.GetAllAsync(new EntityDTO()
            {
                UserId = 1
            });

            VacationViewModel model = new()
            {
                Get = (List<GetAllVacationPendingDTO>)response.Content
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Evaluation(EvaluateVacationDTO vacation)
        {
            vacation.UserId = 1;
            var response = await _controller.EvaluateAsync(vacation);

            ViewData["alert"] = response;

            return RedirectToAction("Pending");
        }
    }
}