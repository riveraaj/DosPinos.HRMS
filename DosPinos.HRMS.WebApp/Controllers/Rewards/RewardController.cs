using DosPinos.HRMS.Controllers.Commons.Notifications;
using DosPinos.HRMS.Entities.Enums.Commons;
using DosPinos.HRMS.Entities.Helpers;
using DosPinos.HRMS.Entities.Interfaces.Commons.Base;
using DosPinos.HRMS.WebApp.Controllers.Base;
using DosPinos.HRMS.WebApp.Models.Employees;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DosPinos.HRMS.WebApp.Controllers.Rewards
{
    public class RewardController(GetAllNotificationController notificationController,
                                       UpdateNotificationController updateController,
                                       HRMS.Controllers.Rewards.RewardController controller) : BaseController(notificationController, updateController)
    {
        private readonly HRMS.Controllers.Rewards.RewardController _controller = controller;

        [HttpPost]
        public async Task<IActionResult> Create(EditEmployeeViewModel model)
        {
            model.RewardObj.UserId = ActualUser;

            string id = CryptographyHelper.Encrypt(model.RewardObj.Identification.ToString());

            IOperationResponseVO response = await _controller.CreateAsync(model.RewardObj);

            TempData["alert"] = JsonConvert.SerializeObject(response);

            if (response.Status == ResponseStatus.Success) return RedirectToAction("Index");

            return RedirectToAction("Edit", "Employee", new { id });
        }
    }
}
