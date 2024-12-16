using DosPinos.HRMS.Controllers.Commons.Notifications;
using DosPinos.HRMS.Entities.Helpers;
using DosPinos.HRMS.Entities.Interfaces.Commons.Base;
using DosPinos.HRMS.WebApp.Controllers.Base;
using DosPinos.HRMS.WebApp.Models.Employees;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DosPinos.HRMS.WebApp.Controllers.Phone
{
    public class PhoneController(GetAllNotificationController getAllNotification,
                                 UpdateNotificationController updateNotification,
                                 HRMS.Controllers.Employees.PhoneController controller) : BaseController(getAllNotification,
                                                                                                           updateNotification)
    {
        private readonly HRMS.Controllers.Employees.PhoneController _controller = controller;

        [HttpPost]
        public async Task<IActionResult> Edit(EditEmployeeViewModel model)
        {
            model.UpdateEmployeeObj.PhoneObj.UserId = ActualUser;
            model.UpdateEmployeeObj.PhoneObj.PhoneTypeId = model.EmployeeObj.PhoneTypeId;

            IOperationResponseVO response = await _controller.UpdateAsync(model.UpdateEmployeeObj.PhoneObj);

            TempData["alert"] = JsonConvert.SerializeObject(response);

            string id = CryptographyHelper.Encrypt(model.EmployeeObj.Identification.ToString());

            return RedirectToAction("Edit", "Employee", new { id });
        }
    }
}