using DosPinos.HRMS.Entities.DTOs.Commons.Base;
using DosPinos.HRMS.Entities.DTOs.WorkingDays;
using DosPinos.HRMS.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DosPinos.HRMS.WebApp.Controllers.WorkingDays
{
    [Authorize]
    public class WorkingDayController(HRMS.Controllers.WorkingDays.WorkingDayController controller) : Controller
    {
        private readonly HRMS.Controllers.WorkingDays.WorkingDayController _controller = controller;

        public async Task<IActionResult> Index()
        {
            var response = await _controller.GetAsync(new EntityDTO()
            {
                UserId = 1,
            });

            WorkingDayViewModel model = new()
            {
                Get = (List<GetAllWorkingDayByDayDTO>)response.Content
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateWorkingDayDTO dto)
        {
            //TimeSpan regularWorkingHours = new TimeSpan(8, 0, 0);

            //// Calcular horas trabajadas
            //TimeSpan totalHoursWorked = endTime - startTime;

            //// Determinar horas normales y horas extras
            //TimeSpan regularHours, overtimeHours;
            //if (totalHoursWorked > regularWorkingHours)
            //{
            //    regularHours = regularWorkingHours;
            //    overtimeHours = totalHoursWorked - regularWorkingHours;
            //}
            //else
            //{
            //    regularHours = totalHoursWorked;
            //    overtimeHours = TimeSpan.Zero;
            //}

            //dto.HoursWorked = int.TryParse(regularHours.TotalHours);

            dto.UserId = 1;
            var response = await _controller.CreateAsync(dto);

            ViewData["alert"] = response;

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Evaluate(EvaluateWorkingDayDTO dto)
        {
            dto.UserId = 1;
            var response = await _controller.EvaluateAsync(dto);

            ViewData["alert"] = response;

            return RedirectToAction("Pending");
        }


        public async Task<IActionResult> Pending()
        {
            var response = await _controller.GetAllAsync(new EntityDTO()
            {
                UserId = 1,
            });

            PendingWorkingDayViewModel model = new()
            {
                Get = (List<GetAllPendingWorkingDayDTO>)response.Content
            };

            return View(model);
        }
    }
}