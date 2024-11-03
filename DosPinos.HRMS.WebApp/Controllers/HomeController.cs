using DosPinos.HRMS.Controllers.Securities.Catalogs;
using DosPinos.HRMS.Entities.DTOs.Commons.Base;
using DosPinos.HRMS.Entities.Interfaces.Commons.Base;
using DosPinos.HRMS.Entities.Interfaces.Securities.Catalogs;
using DosPinos.HRMS.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DosPinos.HRMS.WebApp.Controllers
{
    public class HomeController(GetAllRoleController roleController,
                                ILogger<HomeController> logger) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;
        private readonly GetAllRoleController _roleController = roleController;

        public async Task<IActionResult> Index()
        {
            IOperationResponseVO response = await _roleController.GetAllAsync(new EntityDTO
            {
                UserId = 1
            });

            List<IGetAllRoleDTO> roleList = (List<IGetAllRoleDTO>)response.Content;

            return View(roleList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
