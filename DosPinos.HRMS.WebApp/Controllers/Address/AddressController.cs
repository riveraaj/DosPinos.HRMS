﻿using DosPinos.HRMS.Controllers.Commons.Notifications;
using DosPinos.HRMS.Entities.Helpers;
using DosPinos.HRMS.Entities.Interfaces.Commons.Base;
using DosPinos.HRMS.WebApp.Controllers.Base;
using DosPinos.HRMS.WebApp.Models.Employees;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DosPinos.HRMS.WebApp.Controllers.Address
{
    public class AddressController(GetAllNotificationController getAllNotification,
                                   UpdateNotificationController updateNotification,
                                   HRMS.Controllers.Employees.AddressController controller) : BaseController(getAllNotification,
                                                                                                             updateNotification)
    {
        private readonly HRMS.Controllers.Employees.AddressController _controller = controller;

        [HttpPost]
        public async Task<IActionResult> Edit(EditEmployeeViewModel model)
        {
            model.UpdateEmployeeObj.AddressObj.UserId = ActualUser;
            model.UpdateEmployeeObj.AddressObj.Address = model.EmployeeObj.Address;
            model.UpdateEmployeeObj.AddressObj.DistrictId = model.EmployeeObj.DistrictId;

            IOperationResponseVO response = await _controller.UpdateAsync(model.UpdateEmployeeObj.AddressObj);

            TempData["alert"] = JsonConvert.SerializeObject(response);

            string id = CryptographyHelper.Encrypt(model.EmployeeObj.Identification.ToString());

            return RedirectToAction("Edit", "Employee", new { id });
        }
    }
}