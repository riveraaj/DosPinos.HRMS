using System.Globalization;
using DosPinos.HRMS.Controllers.Commons.Notifications;
using DosPinos.HRMS.Entities.DTOs.Commons.Base;
using DosPinos.HRMS.Entities.DTOs.WorkingDays;
using DosPinos.HRMS.Entities.Interfaces.Commons.Base;
using DosPinos.HRMS.Entities.ValueObjects;
using DosPinos.HRMS.WebApp.Controllers.Base;
using DosPinos.HRMS.WebApp.Models;
using DosPinos.HRMS.WebApp.Models.WorkingDays;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DosPinos.HRMS.WebApp.Controllers.WorkingDays
{
    [Authorize]
    public class WorkingDayController(GetAllNotificationController notificationController,
                                      UpdateNotificationController updateController,
                                      HRMS.Controllers.WorkingDays.WorkingDayController controller) : BaseController(notificationController,
                                                                                                                     updateController)
    {
        private readonly HRMS.Controllers.WorkingDays.WorkingDayController _controller = controller;

        [Route("jornada-laboral")]
        public async Task<IActionResult> Index()
        {
            WorkingDayViewModel model = new();

            IOperationResponseVO response = await _controller.GetAsync(new EntityDTO() { UserId = ActualUser });

            if (TempData["alert"] is not null)
            {
                var alert = JsonConvert.DeserializeObject<OperationResponseVO>((string)TempData["alert"]);
                model.Response = alert;
            }

            model.Today = SetDate();
            model.Notifications = await this.GetAllAsync();
            model.WorkinDays = response.Content as List<GetAllWorkingDayByDayDTO>;

            return View(model);
        }

        [HttpPost]
        [Route("jornada-laboral/crear")]
        public async Task<IActionResult> Create(WorkingDayViewModel model)
        {
            model.WorkingDayObj.UserId = ActualUser;

            IOperationResponseVO response = await _controller.CreateAsync(model.WorkingDayObj);

            TempData["alert"] = JsonConvert.SerializeObject(response);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Pending()
        {
            var response = await _controller.GetAllAsync(new EntityDTO() { UserId = ActualUser });

            PendingWorkingDayViewModel model = new()
            {
                Get = (List<GetAllPendingWorkingDayDTO>)response.Content
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Evaluate(EvaluateWorkingDayDTO dto)
        {
            dto.UserId = 1;
            var response = await _controller.EvaluateAsync(dto);

            ViewData["alert"] = JsonConvert.SerializeObject(response);

            return RedirectToAction("Pending");
        }

        private string SetDate() => char.ToUpper(DateTime.Now.ToString("MMMM dd 'del' yyyy", new CultureInfo("es-CR"))[0]) +
                                    DateTime.Now.ToString("MMMM dd 'del' yyyy", new CultureInfo("es-CR"))[1..];
    }
}