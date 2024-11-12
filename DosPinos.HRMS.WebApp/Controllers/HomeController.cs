using DosPinos.HRMS.Controllers.Employees;
using DosPinos.HRMS.Entities.DTOs.Commons.Base;
using DosPinos.HRMS.Entities.Interfaces.Commons.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DosPinos.HRMS.WebApp.Controllers
{
    [Authorize]
    public class HomeController(GetAllEmployeeController controller,
                                ILogger<HomeController> logger) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;
        private readonly GetAllEmployeeController _controller = controller;

        public async Task<IActionResult> Index()
        {
            IOperationResponseVO response = await _controller.GetAllAsync(new EntityDTO()
            {
                //UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value)
                UserId = 1
            });

            return View(response.Content);
        }
    }
}