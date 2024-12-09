using DosPinos.HRMS.Controllers.Commons.Notifications;
using DosPinos.HRMS.Entities.DTOs.Vacations;
using DosPinos.HRMS.Entities.Enums.Commons;
using DosPinos.HRMS.Entities.Interfaces.Commons.Base;
using DosPinos.HRMS.Entities.ValueObjects;
using DosPinos.HRMS.WebApp.Controllers.Base;
using DosPinos.HRMS.WebApp.Helpers;
using DosPinos.HRMS.WebApp.Models;
using DosPinos.HRMS.WebApp.Models.FreeTimes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DosPinos.HRMS.WebApp.Controllers.Vacations
{
    [Authorize]
    public class FreeTimeController(GetAllNotificationController notificationController,
                                    UpdateNotificationController updateController,
                                    HRMS.Controllers.Vacation.VacationController controller) : BaseController(notificationController,
                                                                                                              updateController)
    {
        private readonly HRMS.Controllers.Vacation.VacationController _controller = controller;

        [Route("tiempo-libre/mis-solicitudes")]
        public async Task<IActionResult> Index()
        {
            FreeTimeViewModel model = new();

            IOperationResponseVO responseVacation = await _controller.GetAllByEmployeeAsync(ActualEmployeeIdentification, Entity);
            IOperationResponseVO responseBalance = await _controller.GetAsync(ActualEmployeeIdentification, Entity);


            if (TempData["alert"] is not null)
            {
                var alert = JsonConvert.DeserializeObject<OperationResponseVO>((string)TempData["alert"]);
                model.Response = alert;
            }

            model.Notifications = await this.GetAllNotificationAsync();
            model.Vacations = responseVacation.Content as List<GetAllVacationByEmployeeDTO>;
            model.VacationBalance = responseBalance.Content as GetEmployeeVacationBalance;
            model.Today = GetDateHelper.GetToday();

            return View(model);
        }

        [HttpPost]
        [Route("tiempo-libre/mis-solicitudes/solicitar")]
        public async Task<IActionResult> Create(FreeTimeViewModel model)
        {
            model.VacationObj.EmployeeId = this.ActualEmployee;
            model.VacationObj.ManagerId = this.ActualEmployeeManager;
            model.VacationObj.UserId = this.ActualUser;

            model.Response = await _controller.CreateAsync(model.VacationObj);

            if (model.Response.Status == ResponseStatus.Success)
            {
                TempData["alert"] = JsonConvert.SerializeObject(model.Response);
                return RedirectToAction("Index");
            }

            IOperationResponseVO response = await _controller.GetAllByEmployeeAsync(ActualEmployeeIdentification, Entity);

            model.Notifications = await this.GetAllNotificationAsync();
            model.Vacations = response.Content as List<GetAllVacationByEmployeeDTO>;
            model.Today = GetDateHelper.GetToday();

            return View("Index", model);
        }

        public async Task<IActionResult> Pending()
        {
            var response = await _controller.GetAllAsync(Entity);

            VacationViewModel model = new()
            {
                Get = (List<GetAllVacationPendingDTO>)response.Content
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Evaluation(EvaluateVacationDTO vacation)
        {
            vacation.UserId = ActualUser;
            var response = await _controller.EvaluateAsync(vacation);

            ViewData["alert"] = response;

            return RedirectToAction("Pending");
        }
    }
}