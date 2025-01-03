﻿using DosPinos.HRMS.Controllers.Commons.Notifications;
using DosPinos.HRMS.Entities.DTOs.Commons.Base;
using DosPinos.HRMS.Entities.DTOs.Liquidation;
using DosPinos.HRMS.Entities.Enums.Commons;
using DosPinos.HRMS.Entities.Helpers;
using DosPinos.HRMS.Entities.Interfaces.Commons.Base;
using DosPinos.HRMS.Entities.ValueObjects;
using DosPinos.HRMS.WebApp.Controllers.Base;
using DosPinos.HRMS.WebApp.Models.Employees;
using DosPinos.HRMS.WebApp.Models.Liquidations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DosPinos.HRMS.WebApp.Controllers.Liquidations
{
    [Authorize(Roles = "4, 5, 6")]
    public class LiquidationController(GetAllNotificationController notificationController,
                                       UpdateNotificationController updateController,
                                       HRMS.Controllers.Liquidations.LiquidationController liquidationController)
                                        : BaseController(notificationController, updateController)
    {
        private readonly HRMS.Controllers.Liquidations.LiquidationController _liquidationController = liquidationController;

        [Route("liquidaciones")]
        public async Task<IActionResult> Index()
        {
            LiquidationViewModel model = new();

            IOperationResponseVO response = await _liquidationController.GetAllAsync(new EntityDTO() { UserId = ActualUser });

            if (TempData["alert"] is not null)
            {
                var alert = JsonConvert.DeserializeObject<OperationResponseVO>((string)TempData["alert"]);
                model.Response = alert;
            }

            model.Notifications = await this.GetAllNotificationAsync();
            model.Liquidation = response.Content as List<GetAllLiquidationDTO>;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EditEmployeeViewModel model)
        {
            model.LiquidationObj.TerminationDate = DateOnly.FromDateTime(DateTime.Now);
            model.LiquidationObj.UserId = ActualUser;

            string id = CryptographyHelper.Encrypt(model.LiquidationObj.Identification.ToString());

            IOperationResponseVO response = await _liquidationController.CreateAsync(model.LiquidationObj);

            TempData["alert"] = JsonConvert.SerializeObject(response);

            if (response.Status == ResponseStatus.Success) return RedirectToAction("Index");

            return RedirectToAction("Edit", "Employee", new { id });
        }
    }
}