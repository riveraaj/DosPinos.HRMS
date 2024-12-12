using DosPinos.HRMS.Controllers.Commons.Notifications;
using DosPinos.HRMS.WebApp.Controllers.Base;
using DosPinos.HRMS.WebApp.Models.FreeTimes;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DosPinos.HRMS.WebApp.Controllers.Licenses
{
    public class LicenseController(GetAllNotificationController notificationController,
                                   UpdateNotificationController updateController,
                                   HRMS.Controllers.Licenses.LicenseController controller) : BaseController(notificationController,
                                                                                                                updateController)
    {
        private readonly HRMS.Controllers.Licenses.LicenseController _controller = controller;

        [HttpPost]
        [Route("tiempo-libre/mis-solicitudes/incapacidad")]
        public async Task<IActionResult> Create(FreeTimeViewModel model)
        {
            model.License.LicenseObj.EmployeeId = this.ActualEmployee;
            model.License.LicenseObj.ManagerId = this.ActualEmployeeManager;
            model.License.LicenseObj.UserId = this.ActualUser;

            model.Response = await _controller.CreateAsync(model.License.LicenseObj);

            TempData["alert"] = JsonConvert.SerializeObject(model.Response);

            return RedirectToAction("Index", "FreeTime");
        }
    }
}