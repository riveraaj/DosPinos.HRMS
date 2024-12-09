using DosPinos.HRMS.Controllers.Commons.Notifications;
using DosPinos.HRMS.Entities.DTOs.Commons.Base;
using DosPinos.HRMS.Entities.DTOs.Payroll;
using DosPinos.HRMS.Entities.Enums.Commons;
using DosPinos.HRMS.Entities.Helpers;
using DosPinos.HRMS.Entities.Interfaces.Commons.Base;
using DosPinos.HRMS.Entities.ValueObjects;
using DosPinos.HRMS.WebApp.Controllers.Base;
using DosPinos.HRMS.WebApp.Helpers;
using DosPinos.HRMS.WebApp.Models.Payrolls;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DosPinos.HRMS.WebApp.Controllers.Payrolls
{
    [Authorize]
    public class PayrollController(GetAllNotificationController notificationController,
                                   UpdateNotificationController updateController,
                                   HRMS.Controllers.Payroll.PayrollController payrollController)
                                    : BaseController(notificationController, updateController)
    {
        private readonly HRMS.Controllers.Payroll.PayrollController _payrollController = payrollController;

        [Route("nomina")]
        public async Task<IActionResult> Index()
        {
            PayrollViewModel model = new();

            IOperationResponseVO response = await _payrollController.GetAllAsync(new EntityDTO { UserId = ActualUser });

            if (TempData["alert"] is not null)
            {
                var alert = JsonConvert.DeserializeObject<OperationResponseVO>((string)TempData["alert"]);
                model.Response = alert;
            }

            model.Payroll = response.Content as List<GetPayrollByDateDTO>;
            model.Notifications = await this.GetAllNotificationAsync();
            model.Today = GetDateHelper.GetMonthTodayCapitalize();

            return View(model);
        }

        [Route("nomina/crear")]
        [HttpPost]
        public async Task<IActionResult> Create()
        {
            IOperationResponseVO response = await _payrollController.CreateAsync(new EntityDTO() { UserId = ActualUser });

            TempData["alert"] = JsonConvert.SerializeObject(response);

            return RedirectToAction("Index");
        }

        [Route("nomina/crear-individual")]
        [HttpPost]
        public async Task<IActionResult> CreateIndividual(int employeeId, int identification)
        {
            var response = await _payrollController.CreateAsync(employeeId, new EntityDTO() { UserId = ActualUser });

            string id = CryptographyHelper.Encrypt(identification.ToString());

            TempData["alert"] = JsonConvert.SerializeObject(response);

            if (response.Status == ResponseStatus.Success) return RedirectToAction("Index");

            return RedirectToAction("Edit", "Employee", new { id });
        }
    }
}