﻿using DosPinos.HRMS.Controllers.Commons.Notifications;
using DosPinos.HRMS.Entities.Helpers;
using DosPinos.HRMS.Entities.Interfaces.Commons.Base;
using DosPinos.HRMS.WebApp.Controllers.Base;
using DosPinos.HRMS.WebApp.Models.Employees;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DosPinos.HRMS.WebApp.Controllers.Employees
{
    public class EmployeeDetailController(GetAllNotificationController getAllNotification,
                                 UpdateNotificationController updateNotification,
                                 HRMS.Controllers.Employees.EmployeeDetailController controller) : BaseController(getAllNotification,
                                                                                                                  updateNotification)
    {
        private readonly HRMS.Controllers.Employees.EmployeeDetailController _controller = controller;

        [HttpPost]
        public async Task<IActionResult> Edit(EditEmployeeViewModel model)
        {
            model.UpdateEmployeeObj.DetailObj.UserId = ActualUser;
            model.UpdateEmployeeObj.DetailObj.HiringTypeId = model.EmployeeObj.HiringTypeId;
            model.UpdateEmployeeObj.DetailObj.MaritalStatusId = model.EmployeeObj.MaritalStatusId;
            model.UpdateEmployeeObj.DetailObj.NationalityId = model.EmployeeObj.NationalityId;
            model.UpdateEmployeeObj.DetailObj.GenderId = model.EmployeeObj.GenderId;
            model.UpdateEmployeeObj.DetailObj.JobTitleId = model.EmployeeObj.JobTitleId;

            IOperationResponseVO response = await _controller.UpdateAsync(model.UpdateEmployeeObj.DetailObj);

            TempData["alert"] = JsonConvert.SerializeObject(response);

            string id = CryptographyHelper.Encrypt(model.EmployeeObj.Identification.ToString());

            return RedirectToAction("Edit", "Employee", new { id });
        }
    }
}