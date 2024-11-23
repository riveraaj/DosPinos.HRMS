using DosPinos.HRMS.Controllers.Commons.Notifications;
using DosPinos.HRMS.Controllers.Employees;
using DosPinos.HRMS.Entities.DTOs.Commons.Base;
using DosPinos.HRMS.Entities.DTOs.Employees;
using DosPinos.HRMS.Entities.Enums.Commons;
using DosPinos.HRMS.Entities.Helpers;
using DosPinos.HRMS.Entities.Interfaces.Commons.Base;
using DosPinos.HRMS.Entities.Interfaces.Employees;
using DosPinos.HRMS.Entities.ValueObjects;
using DosPinos.HRMS.WebApp.Controllers.Base;
using DosPinos.HRMS.WebApp.Models.Employees;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DosPinos.HRMS.WebApp.Controllers.Employees
{
    [Authorize]
    public class EmployeeController(GetAllNotificationController getAllNotificationController,
                                    UpdateNotificationController updateNotificationController,
                                    CreateEmployeeController createController,
                                    GetAllEmployeeController getAllController,
                                    HRMS.Controllers.Employees.EmployeeController employeeController) : BaseController(getAllNotificationController,
                                                                                                                       updateNotificationController)
    {
        private readonly CreateEmployeeController _createController = createController;
        private readonly GetAllEmployeeController _getAllController = getAllController;
        private readonly HRMS.Controllers.Employees.EmployeeController _employeeController = employeeController;

        [Route("empleados")]
        public async Task<IActionResult> Index()
        {
            EmployeeViewModel model = new();

            IOperationResponseVO response = await _getAllController.GetAllAsync(new EntityDTO()
            {
                UserId = ActualUser
            });

            if (TempData["alert"] is not null)
            {
                var alert = JsonConvert.DeserializeObject<OperationResponseVO>((string)TempData["alert"]);
                model.Response = alert;
            }

            model.Employees = (List<IGetAllEmployeeDTO>)response.Content;
            model.Notifications = await this.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        [Route("empleado")]
        public async Task<IActionResult> Edit(string id)
        {
            IOperationResponseVO response = await _employeeController.GetAsync(Convert.ToInt32(CryptographyHelper.Decrypt(id)), new EntityDTO()
            {
                UserId = ActualUser
            });

            if (response.Status != ResponseStatus.Success)
            {
                TempData["alert"] = JsonConvert.SerializeObject(response);
                return RedirectToAction("Index");
            }

            EditEmployeeViewModel model = new()
            {
                Employee = (GetEmployeeByIdentifactionDTO)response.Content,
                Notifications = await this.GetAllAsync()
            };

            return View(model);
        }
    }
}