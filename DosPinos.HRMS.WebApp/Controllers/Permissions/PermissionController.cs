using DosPinos.HRMS.Controllers.Commons.Notifications;
using DosPinos.HRMS.WebApp.Controllers.Base;
using DosPinos.HRMS.WebApp.Models.FreeTimes;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DosPinos.HRMS.WebApp.Controllers.Permissions
{
    public class PermissionController(GetAllNotificationController notificationController,
                                      UpdateNotificationController updateController,
                                      HRMS.Controllers.Permissions.PermissionController controller) : BaseController(notificationController,
                                                                                                                     updateController)
    {
        private readonly HRMS.Controllers.Permissions.PermissionController _controller = controller;

        [HttpPost]
        [Route("tiempo-libre/mis-solicitudes/permiso-especial")]
        public async Task<IActionResult> Create(FreeTimeViewModel model)
        {
            model.Permission.PermissionObj.EmployeeId = this.ActualEmployee;
            model.Permission.PermissionObj.ManagerId = this.ActualEmployeeManager;
            model.Permission.PermissionObj.UserId = this.ActualUser;

            model.Response = await _controller.CreateAsync(model.Permission.PermissionObj);

            TempData["alert"] = JsonConvert.SerializeObject(model.Response);

            return RedirectToAction("Index", "FreeTime");
        }
    }
}