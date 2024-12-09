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
                Notifications = await this.GetAllNotificationAsync(),
                Vacation = response.Content as List<VacationReportDTO>,
            };

            return View(model);
        }

        [Route("reportes/reporte-exceso-horas-extras")]
        public async Task<IActionResult> Overtime()
        {
            IOperationResponseVO response = await _reportController.GetAllOvertimeAsync(new EntityDTO { UserId = ActualUser });

            ReportOvertimeViewModel model = new()
            {
                Notifications = await this.GetAllNotificationAsync(),
                Overtime = response.Content as List<OvertimeReportDTO>,
            };

            return View(model);
        }

        [Route("reportes/reporte-incapacidades")]
        public async Task<IActionResult> License()
        {
            IOperationResponseVO response = await _reportController.GetAllLicenseAsync(new EntityDTO { UserId = ActualUser });

            ReportLicenseViewModel model = new()
            {
                Notifications = await this.GetAllNotificationAsync(),
                License = response.Content as List<LicenseReportDTO>,
            };

            return View(model);
        }

        [Route("reportes/reporte-permisos-especiales")]
        public async Task<IActionResult> SpecialPermission()
        {
            IOperationResponseVO response = await _reportController.GetAllSpecialPermissionAsync(new EntityDTO { UserId = ActualUser });

            ReportSpecialPermissionViewModel model = new()
            {
                Notifications = await this.GetAllNotificationAsync(),
                SpecialPermission = response.Content as List<SpecialPermissionReportDTO>,
            };

            return View(model);
        }
    }
}