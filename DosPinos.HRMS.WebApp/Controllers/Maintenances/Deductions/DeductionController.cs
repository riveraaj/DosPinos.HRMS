using DosPinos.HRMS.Controllers.Commons.Notifications;
using DosPinos.HRMS.Controllers.Employees.Catalogs.Deductions;
using DosPinos.HRMS.Entities.Enums.Commons;
using DosPinos.HRMS.Entities.Interfaces.Commons.Base;
using DosPinos.HRMS.Entities.Interfaces.Employees.Catalogs;
using DosPinos.HRMS.Entities.ValueObjects;
using DosPinos.HRMS.WebApp.Controllers.Base;
using DosPinos.HRMS.WebApp.Models.Maintenances.Deductions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DosPinos.HRMS.WebApp.Controllers.Maintenances.Deductions
{
    [Authorize(Roles = "3, 6")]
    public class DeductionController(GetAllNotificationController getAllNotification,
                                     UpdateNotificationController updateNotification,
                                     HRMS.Controllers.Deductions.DeductionController controller,
                                     GetAllDeductionController getAllDeduction) : BaseController(getAllNotification, updateNotification)
    {
        private readonly HRMS.Controllers.Deductions.DeductionController _controller = controller;
        private readonly GetAllDeductionController _getAllDeduction = getAllDeduction;

        [Route("mantenimiento/deducciones")]
        public async Task<IActionResult> Index()
        {
            DeductionViewModel model = await PopulateDeductionViewModel();

            if (TempData["alert"] is not null)
            {
                var alert = JsonConvert.DeserializeObject<OperationResponseVO>((string)TempData["alert"]);
                model.Response = alert;
            }

            return View(model);
        }

        [HttpPost]
        [Route("mantenimiento/deducciones/nueva-deduccion")]
        public async Task<IActionResult> Create(DeductionViewModel model)
        {
            model.DeductionObj.UserId = ActualUser;

            IOperationResponseVO response = await _controller.CreateAsync(model.DeductionObj);

            TempData["alert"] = JsonConvert.SerializeObject(response);
            return RedirectToAction("Index");

        }

        [HttpPost]
        [Route("mantenimiento/deducciones/actualizar")]
        public async Task<IActionResult> Edit(DeductionViewModel model)
        {
            model.UpdateDeductionObj.UserId = ActualUser;

            IOperationResponseVO response = await _controller.UpdateAsync(model.UpdateDeductionObj);

            return Json(new
            {
                success = response.Status == ResponseStatus.Success,
                message = response.Message.FirstOrDefault(),
                status = response.Status.ToString()
            });
        }

        [HttpPost]
        [Route("mantenimiento/deducciones/eliminar")]
        public async Task<IActionResult> Delete(byte deductionId)
        {
            IOperationResponseVO response = await _controller.DeleteAsync(deductionId, Entity);
            TempData["alert"] = JsonConvert.SerializeObject(response);
            return RedirectToAction("Index");
        }

        private async Task<DeductionViewModel> PopulateDeductionViewModel()
        {
            DeductionViewModel model = new();

            IOperationResponseVO response = await _getAllDeduction.GetAllAsync(Entity);
            model.Deductions = response.Content as List<IGetAllDeductionDTO>;

            model.Notifications = await this.GetAllNotificationAsync();

            return model;
        }
    }
}