using DosPinos.HRMS.Controllers.Commons.Notifications;
using DosPinos.HRMS.Entities.DTOs.IncomeTaxes;
using DosPinos.HRMS.Entities.Enums.Commons;
using DosPinos.HRMS.Entities.Interfaces.Commons.Base;
using DosPinos.HRMS.Entities.ValueObjects;
using DosPinos.HRMS.WebApp.Controllers.Base;
using DosPinos.HRMS.WebApp.Models.Maintenances.IncomeTaxes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DosPinos.HRMS.WebApp.Controllers.Maintenances.IncomeTaxes
{
    [Authorize(Roles = "3, 6")]
    public class IncomeTaxController(GetAllNotificationController getAllNotification,
                                     UpdateNotificationController updateNotification,
                                     HRMS.Controllers.IncomeTaxes.IncomeTaxController controller) : BaseController(getAllNotification,
                                                                                                                   updateNotification)
    {
        private readonly HRMS.Controllers.IncomeTaxes.IncomeTaxController _controller = controller;

        [Route("mantenimiento/impuestos")]
        public async Task<IActionResult> Index()
        {
            IncomeTaxViewModel model = await PopulateIncomeTaxViewModel();

            if (TempData["alert"] is not null)
            {
                var alert = JsonConvert.DeserializeObject<OperationResponseVO>((string)TempData["alert"]);
                model.Response = alert;
            }

            return View(model);
        }

        [HttpPost]
        [Route("mantenimiento/impuestos/nuevo-impuesto")]
        public async Task<IActionResult> Create(IncomeTaxViewModel model)
        {
            model.IncomeTaxObj.UserId = ActualUser;

            IOperationResponseVO response = await _controller.CreateAsync(model.IncomeTaxObj);

            TempData["alert"] = JsonConvert.SerializeObject(response);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("mantenimiento/impuestos/actualizar")]
        public async Task<IActionResult> Edit(IncomeTaxViewModel model)
        {
            model.UpdateIncomeTaxObj.UserId = ActualUser;

            IOperationResponseVO response = await _controller.UpdateAsync(model.UpdateIncomeTaxObj);

            return Json(new
            {
                success = response.Status == ResponseStatus.Success,
                message = response.Message.FirstOrDefault(),
                status = response.Status.ToString()
            });
        }

        [HttpPost]
        [Route("mantenimiento/impuestos/eliminar")]
        public async Task<IActionResult> Delete(byte incomeTaxId)
        {
            IOperationResponseVO response = await _controller.DeleteAsync(incomeTaxId, Entity);
            TempData["alert"] = JsonConvert.SerializeObject(response);
            return RedirectToAction("Index");
        }

        private async Task<IncomeTaxViewModel> PopulateIncomeTaxViewModel()
        {
            IncomeTaxViewModel model = new();

            IOperationResponseVO response = await _controller.GetAllTableAsync(Entity);
            model.IncomeTaxes = response.Content as List<GetAllIncomeTaxTableDTO>;

            model.Notifications = await this.GetAllNotificationAsync();

            return model;
        }
    }
}