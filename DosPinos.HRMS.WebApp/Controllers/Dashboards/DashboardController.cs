using DosPinos.HRMS.WebApp.Models.Dashboards;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DosPinos.HRMS.WebApp.Controllers.Dashboard
{
    [Authorize]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            DashboardViewModel model = new();
            return View(model);
        }
    }
}