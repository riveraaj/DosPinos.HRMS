using DosPinos.HRMS.Controllers.Commons.Notifications;
using DosPinos.HRMS.Controllers.Employees;
using DosPinos.HRMS.Controllers.Machines;
using DosPinos.HRMS.Entities.DTOs.Commons.Base;
using DosPinos.HRMS.Entities.DTOs.Employees;
using DosPinos.HRMS.Entities.DTOs.Machines;
using DosPinos.HRMS.Entities.DTOs.OEEs;
using DosPinos.HRMS.Entities.Enums.Commons;
using DosPinos.HRMS.Entities.Interfaces.Commons.Base;
using DosPinos.HRMS.Entities.ValueObjects;
using DosPinos.HRMS.WebApp.Controllers.Base;
using DosPinos.HRMS.WebApp.Models.OEEs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DosPinos.HRMS.WebApp.Controllers.OEEs
{
    [Authorize(Roles = "2, 6")]
    public class OEEController(GetAllNotificationController notification,
                               UpdateNotificationController updateNotification,
                               HRMS.Controllers.OEEs.OEEController controller,
                               EmployeeController employeeController,
                               MachineController machineController) : BaseController(notification, updateNotification)
    {
        private readonly HRMS.Controllers.OEEs.OEEController _controller = controller;
        private readonly EmployeeController _employeeController = employeeController;
        private readonly MachineController _machineController = machineController;

        public async Task<IActionResult> Index()
        {
            OEEViewModel model = await PopulateOEEViewModel();

            if (TempData["alert"] is not null)
            {
                var alert = JsonConvert.DeserializeObject<OperationResponseVO>((string)TempData["alert"]);
                model.Response = alert;
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OEEViewModel model)
        {
            model.OEEObj.UserId = ActualUser;

            IOperationResponseVO response = await _controller.CreateAsync(model.OEEObj);

            if (response.Status == ResponseStatus.Success)
            {
                TempData["alert"] = JsonConvert.SerializeObject(response);
                return RedirectToAction("Index");
            }

            OEEViewModel newModel = await PopulateOEEViewModel();
            newModel.Response = response;
            newModel.OEEObj = model.OEEObj;

            return View("Index", newModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int OEEId)
        {
            IOperationResponseVO response = await _controller.DeleteAsync(OEEId, new EntityDTO { UserId = ActualUser });

            TempData["alert"] = JsonConvert.SerializeObject(response);

            return RedirectToAction("Index");
        }

        private async Task<OEEViewModel> PopulateOEEViewModel()
        {
            OEEViewModel model = new();

            IOperationResponseVO response = await _controller.GetAllAsync(new EntityDTO { UserId = ActualUser });
            model.OEEs = response.Content as List<GetAllOEEDTO>;

            response = await _employeeController.GetAllActiveAsync(new EntityDTO { UserId = ActualUser });
            model.EmployeeList = response.Content as List<GetAllActiveEmployeeDTO>;

            response = await _machineController.GetAllAsync(new EntityDTO { UserId = ActualUser });
            model.MachineList = response.Content as List<GetAllMachineDTO>;

            model.Notifications = await this.GetAllNotificationAsync();

            return model;
        }
    }
}