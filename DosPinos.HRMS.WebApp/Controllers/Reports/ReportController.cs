using DosPinos.HRMS.Controllers.Commons.Notifications;
using DosPinos.HRMS.Entities.DTOs.Commons.Base;
using DosPinos.HRMS.Entities.DTOs.Reports;
using DosPinos.HRMS.Entities.Interfaces.Commons.Base;
using DosPinos.HRMS.WebApp.Controllers.Base;
using DosPinos.HRMS.WebApp.Models.Reports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DosPinos.HRMS.WebApp.Controllers.Reports
{
    [Authorize]
    public class ReportController(HRMS.Controllers.Reports.ReportController reportController,
                                  GetAllNotificationController getAllNotificationController,
                                  UpdateNotificationController updateNotificationController) : BaseController(getAllNotificationController,
                                                                                                              updateNotificationController)
    {
        private readonly HRMS.Controllers.Reports.ReportController _reportController = reportController;

        [Route("reportes/reporte-vacaciones")]
        public async Task<IActionResult> Vacation()
        {
            IOperationResponseVO response = await _reportController.GetAllVacationAsync(new EntityDTO { UserId = ActualUser });

            ReportVacationViewModel model = new()
            {
                Notifications = await this.GetAllAsync(),
                Vacation = response.Content as List<VacationReportDTO>,
            };

            return View(model);
        }
    }
}