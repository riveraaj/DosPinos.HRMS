using DosPinos.HRMS.Controllers.Commons.Notifications;
using DosPinos.HRMS.Entities.Helpers;
using DosPinos.HRMS.Entities.Interfaces.Commons.Base;
using DosPinos.HRMS.WebApp.Controllers.Base;
using DosPinos.HRMS.WebApp.Models.Employees;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DosPinos.HRMS.WebApp.Controllers.Employees
{
    public class EmployeeDeductionController(GetAllNotificationController getAllNotification,
                                 UpdateNotificationController updateNotification,
                                 HRMS.Controllers.Employees.EmployeeDeductionController controller) : BaseController(getAllNotification,
                                                                                                                        updateNotification)
    {
        private readonly HRMS.Controllers.Employees.EmployeeDeductionController _controller = controller;

        [HttpPost]
        public async Task<IActionResult> Create(EditEmployeeViewModel model)
        {
            model.UpdateEmployeeObj.DeductionObj.UserId = ActualUser;

            IOperationResponseVO response = await _controller.CreateAsync(model.UpdateEmployeeObj.DeductionObj);

            TempData["alert"] = JsonConvert.SerializeObject(response);

            string id = CryptographyHelper.Encrypt(model.EmployeeObj.Identification.ToString());

            return RedirectToAction("Edit", "Employee", new { id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int employeeDeductionId, int identification)
        {
            IOperationResponseVO response = await _controller.DeleteAsync(employeeDeductionId, Entity);

            TempData["alert"] = JsonConvert.SerializeObject(response);

            string id = CryptographyHelper.Encrypt(identification.ToString());

            return RedirectToAction("Edit", "Employee", new { id });
        }
    }
}