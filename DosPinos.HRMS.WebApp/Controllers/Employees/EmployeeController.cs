using System.Security.Claims;
using DosPinos.HRMS.Controllers.Commons.Notifications;
using DosPinos.HRMS.Controllers.Employees;
using DosPinos.HRMS.Entities.DTOs.Commons.Base;
using DosPinos.HRMS.Entities.DTOs.Employees;
using DosPinos.HRMS.Entities.Enums.Commons;
using DosPinos.HRMS.Entities.Interfaces.Commons.Base;
using DosPinos.HRMS.WebApp.Controllers.Base;
using DosPinos.HRMS.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        public async Task<IActionResult> Index()
        {
            IOperationResponseVO response = await _getAllController.GetAllAsync(new EntityDTO()
            {
                UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value),
            });

            return View(response.Content);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int employeeId)
        {

            var response = await _employeeController.GetAsync(employeeId, new EntityDTO()
            {
                UserId = 1
            });

            if (response.Status != ResponseStatus.Success)
            {
                ViewData["alert"] = response;
                return RedirectToAction("Index");
            }

            EmployeeViewModel model = new()
            {
                Employee = (GetEmployeeByIdentifactionDTO)response.Content
            };

            return View(model);
        }
    }
}