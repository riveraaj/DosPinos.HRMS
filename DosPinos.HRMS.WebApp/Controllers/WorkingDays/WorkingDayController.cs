using System.Globalization;
using DosPinos.HRMS.Controllers.Commons.Notifications;
using DosPinos.HRMS.Entities.DTOs.Commons.Base;
using DosPinos.HRMS.Entities.DTOs.WorkingDays;
using DosPinos.HRMS.Entities.Interfaces.Commons.Base;
using DosPinos.HRMS.Entities.ValueObjects;
using DosPinos.HRMS.WebApp.Controllers.Base;
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

        [Route("asistencia/control-asistencia")]
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
        [Route("asistencia/control-asistencia/crear")]
        public async Task<IActionResult> Create(WorkingDayViewModel model)
        {
            model.WorkingDayObj.UserId = ActualUser;

            IOperationResponseVO response = await _controller.CreateAsync(model.WorkingDayObj);

            TempData["alert"] = JsonConvert.SerializeObject(response);

            return RedirectToAction("Index");
        }

        [Route("asistencia/gestion-asistencia")]
        public async Task<IActionResult> Pending()
        {
            PendingWorkingDayViewModel model = new();

            IOperationResponseVO response = await _controller.GetAllAsync(new EntityDTO() { UserId = ActualUser });

            if (TempData["alert"] is not null)
            {
                var alert = JsonConvert.DeserializeObject<OperationResponseVO>((string)TempData["alert"]);
                model.Response = alert;
            }

            model.Notifications = await this.GetAllAsync();
            model.PendingWorkingDays = response.Content as List<GetAllPendingWorkingDayDTO>;

            return View(model);
        }

        [HttpPost]
        [Route("asistencia/gestion-asistencia/evaluar")]
        public async Task<IActionResult> Evaluate(PendingWorkingDayViewModel model)
        {
            model.EvaluateWorkingDayObj.UserId = ActualUser;

            IOperationResponseVO response = await _controller.EvaluateAsync(model.EvaluateWorkingDayObj);

            ViewData["alert"] = JsonConvert.SerializeObject(response);

            return RedirectToAction("Pending");
        }

        private string SetDate() => char.ToUpper(DateTime.Now.ToString("MMMM dd 'del' yyyy", new CultureInfo("es-CR"))[0]) +
                                    DateTime.Now.ToString("MMMM dd 'del' yyyy", new CultureInfo("es-CR"))[1..];
    }
}