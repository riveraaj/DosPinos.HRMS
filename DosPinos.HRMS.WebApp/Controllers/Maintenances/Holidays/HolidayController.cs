using DosPinos.HRMS.Controllers.Commons.Notifications;
using DosPinos.HRMS.Controllers.WorkingDays.Catalogs;
using DosPinos.HRMS.Entities.DTOs.WorkingDays.Catalogs;
using DosPinos.HRMS.Entities.Enums.Commons;
using DosPinos.HRMS.Entities.Interfaces.Commons.Base;
using DosPinos.HRMS.Entities.ValueObjects;
using DosPinos.HRMS.WebApp.Controllers.Base;
using DosPinos.HRMS.WebApp.Models.Maintenances.Holidays;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DosPinos.HRMS.WebApp.Controllers.Maintenances.Holidays
{
    [Authorize(Roles = "3, 6")]
    public class HolidayController(GetAllNotificationController getAllNotification,
                                     UpdateNotificationController updateNotification,
                                     HRMS.Controllers.Holidays.HolidayController controller,
                                     GetAllHolidayController getAll) : BaseController(getAllNotification, updateNotification)
    {
        private readonly HRMS.Controllers.Holidays.HolidayController _controller = controller;
        private readonly GetAllHolidayController _getAll = getAll;

        [Route("mantenimiento/feriados")]
        public async Task<IActionResult> Index()
        {
            HolidayViewModel model = await PopulateHolidayViewModel();

            if (TempData["alert"] is not null)
            {
                var alert = JsonConvert.DeserializeObject<OperationResponseVO>((string)TempData["alert"]);
                model.Response = alert;
            }

            return View(model);
        }

        [HttpPost]
        [Route("mantenimiento/feriados/nuevo-feriado")]
        public async Task<IActionResult> Create(HolidayViewModel model)
        {
            model.HolidayObj.UserId = ActualUser;

            IOperationResponseVO response = await _controller.CreateAsync(model.HolidayObj);

            TempData["alert"] = JsonConvert.SerializeObject(response);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("mantenimiento/feriados/actualizar")]
        public async Task<IActionResult> Edit(HolidayViewModel model)
        {
            model.UpdateHolidayObj.UserId = ActualUser;

            IOperationResponseVO response = await _controller.UpdateAsync(model.UpdateHolidayObj);

            return Json(new
            {
                success = response.Status == ResponseStatus.Success,
                message = response.Message.FirstOrDefault(),
                status = response.Status.ToString()
            });
        }
        private async Task<HolidayViewModel> PopulateHolidayViewModel()
        {
            HolidayViewModel model = new();

            IOperationResponseVO response = await _getAll.GetAllAsync(Entity);
            model.Holidays = response.Content as List<GetAllHolidayDTO>;

            model.Notifications = await this.GetAllNotificationAsync();

            return model;
        }
    }
}