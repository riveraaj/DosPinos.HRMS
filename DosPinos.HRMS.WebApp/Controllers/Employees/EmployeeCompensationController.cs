﻿using DosPinos.HRMS.Controllers.Commons.Notifications;
using DosPinos.HRMS.Entities.Enums.Commons;
using DosPinos.HRMS.Entities.Interfaces.Commons.Base;
using DosPinos.HRMS.WebApp.Controllers.Base;
using DosPinos.HRMS.WebApp.Models.Employees;
using Microsoft.AspNetCore.Mvc;

namespace DosPinos.HRMS.WebApp.Controllers.Employees
{
    public class EmployeeCompensationController(GetAllNotificationController getAllNotification,
                                 UpdateNotificationController updateNotification,
                                 HRMS.Controllers.Employees.EmployeeCompensationController controller) : BaseController(getAllNotification,
                                                                                                                        updateNotification)
    {
        private readonly HRMS.Controllers.Employees.EmployeeCompensationController _controller = controller;

        [HttpPost]
        public async Task<IActionResult> Edit(EditEmployeeViewModel model)
        {
            model.UpdateEmployeeObj.CompensationObj.UserId = ActualUser;
            model.UpdateEmployeeObj.CompensationObj.SalaryCategoryId = model.EmployeeObj.SalaryCategoryId;

            IOperationResponseVO response = await _controller.UpdateAsync(model.UpdateEmployeeObj.CompensationObj);

            return Json(new
            {
                success = response.Status == ResponseStatus.Success,
                message = response.Message.FirstOrDefault(),
                status = response.Status.ToString()
            });
        }
    }
}