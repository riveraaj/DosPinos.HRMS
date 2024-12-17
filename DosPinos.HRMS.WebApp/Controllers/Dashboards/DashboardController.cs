using DosPinos.HRMS.Controllers.Commons.Notifications;
using DosPinos.HRMS.Entities.DTOs.Commons.Base;
using DosPinos.HRMS.Entities.DTOs.Commons.Dashboards;
using DosPinos.HRMS.Entities.Interfaces.Commons.Base;
using DosPinos.HRMS.WebApp.Controllers.Base;
using DosPinos.HRMS.WebApp.Models.Base;
using DosPinos.HRMS.WebApp.Models.Dashboards;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DosPinos.HRMS.WebApp.Controllers.Dashboards
{
    [Authorize]
    public class DashboardController(GetAllNotificationController getAllNotificationController,
                                     UpdateNotificationController updateNotificationController,
                                     HRMS.Controllers.Commons.Dashboards.DashboardController controller) : BaseController(getAllNotificationController,
                                                                                                                 updateNotificationController)
    {
        private readonly HRMS.Controllers.Commons.Dashboards.DashboardController _controller = controller;

        public async Task<IActionResult> Index() => View(await PopulateDashboardViewModel());


        [Route("notificacion/actualizar")]
        [HttpPost]
        public async Task<IActionResult> UpdateNotification(BaseViewModel model) => await this.UpdateNotificationAsync(model.NotificationObj);

        private async Task<DashboardViewModel> PopulateDashboardViewModel()
        {
            IEntityDTO entity = new EntityDTO { UserId = ActualUser };
            DashboardViewModel model = new();

            IOperationResponseVO response = await _controller.GetAllCloseVacationAsync(entity);
            model.CloseVacations = response.Content as List<GetAllCloseVacationDTO>;

            response = await _controller.GetAllActiveEmployeesAsync(entity);
            model.Employees = response.Content as GetAllActiveEmployeesDTO;

            response = await _controller.GetAllEmployeesExcessOvertimeAsync(entity);
            model.EmployeesExcessOvertime = response.Content as List<GetAllEmployeesExcessOvertimeDTO>;

            response = await _controller.GetAllEmployeesLicenseAsync(entity);
            model.Licenses = response.Content as GetAllEmployeesLicenseDTO;

            response = await _controller.GetAllEmployeesVacationAsync(entity);
            model.Vacations = response.Content as List<GetAllEmployeesVacationDTO>;

            model.Notifications = await GetAllNotificationAsync();

            return model;
        }
    }
}