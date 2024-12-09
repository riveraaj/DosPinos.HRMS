using DosPinos.HRMS.Controllers.Commons.Notifications;
using DosPinos.HRMS.WebApp.Controllers.Base;
using DosPinos.HRMS.WebApp.Models.Dashboards;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DosPinos.HRMS.WebApp.Controllers.Dashboards
{
    [Authorize]
    public class DashboardController(GetAllNotificationController getAllNotificationController,
                                     UpdateNotificationController updateNotificationController) : BaseController(getAllNotificationController,
                                                                                                                 updateNotificationController)
    {
        public async Task<IActionResult> Index()
        {
            DashboardViewModel model = new()
            {
                Notifications = await GetAllNotificationAsync()
            };

            return View(model);
        }
    }
}