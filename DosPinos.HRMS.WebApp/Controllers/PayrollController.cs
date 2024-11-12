using DosPinos.HRMS.Entities.DTOs.Commons.Base;
using DosPinos.HRMS.Entities.DTOs.Payroll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DosPinos.HRMS.WebApp.Controllers
{
    [Authorize]
    public class PayrollController(HRMS.Controllers.Payroll.PayrollController payrollController) : Controller
    {
        private readonly HRMS.Controllers.Payroll.PayrollController _payrollController = payrollController;

        public IActionResult Index()
        {
            var payrollData = TempData["PayrollData"] as string;
            if (!string.IsNullOrEmpty(payrollData))
            {
                var payrollList = JsonConvert.DeserializeObject<List<GetPayrollByDateDTO>>(payrollData);
                return View(payrollList);
            }

            // Si no hay datos en TempData, pasar un modelo vacío o predeterminado
            return View(new List<GetPayrollByDateDTO>());
        }


        [HttpPost]
        public async Task<IActionResult> Create()
        {
            var response = await _payrollController.CreateAsync(new EntityDTO()
            {
                //UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value)
                UserId = 1
            });

            ViewData["alert"] = response;
            TempData["PayrollData"] = JsonConvert.SerializeObject(response.Content);

            return RedirectToAction("Index");
        }
    }
}