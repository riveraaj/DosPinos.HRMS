using DosPinos.HRMS.Controllers.Commons.Notifications;
using DosPinos.HRMS.Entities.DTOs.Payroll;
using DosPinos.HRMS.Entities.Interfaces.Commons.Base;
using DosPinos.HRMS.WebApp.Controllers.Base;
using DosPinos.HRMS.WebApp.Models.Payrolls;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DosPinos.HRMS.WebApp.Controllers.Payrolls
{
    [Authorize]
    public class PayrollReportController(GetAllNotificationController notificationController,
                                         UpdateNotificationController updateController,
                                         HRMS.Controllers.Payroll.PayrollController payrollController) : BaseController(notificationController,
                                                                                                                  updateController)
    {
        private readonly HRMS.Controllers.Payroll.PayrollController _payrollController = payrollController;

        public async Task<IActionResult> Index()
        {
            PayrollReportViewModel model = new();

            IOperationResponseVO response = await _payrollController.GetAllEmployeeAsync(ActualEmployee, Entity);

            model.Notifications = await this.GetAllNotificationAsync();
            model.Payrolls = response.Content as List<GetAllPayrollByEmployeeDTO>;

            return View(model);
        }
    }
}