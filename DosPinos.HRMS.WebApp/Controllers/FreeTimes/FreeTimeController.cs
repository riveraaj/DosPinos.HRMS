using DosPinos.HRMS.Controllers.Commons.Notifications;
using DosPinos.HRMS.Controllers.Licenses;
using DosPinos.HRMS.Controllers.Licenses.Catalogs;
using DosPinos.HRMS.Controllers.Permissions.Catalogs;
using DosPinos.HRMS.Entities.DTOs.Commons.Base;
using DosPinos.HRMS.Entities.DTOs.Licenses;
using DosPinos.HRMS.Entities.DTOs.Permissions;
using DosPinos.HRMS.Entities.DTOs.Permissions.Catalogs;
using DosPinos.HRMS.Entities.DTOs.Vacations;
using DosPinos.HRMS.Entities.Interfaces.Commons.Base;
using DosPinos.HRMS.Entities.Interfaces.Licenses.Catalogs;
using DosPinos.HRMS.Entities.ValueObjects;
using DosPinos.HRMS.WebApp.Controllers.Base;
using DosPinos.HRMS.WebApp.Helpers;
using DosPinos.HRMS.WebApp.Models.FreeTimes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DosPinos.HRMS.WebApp.Controllers.FreeTimes
{
    [Authorize]
    public class FreeTimeController(GetAllNotificationController notificationController,
                                    UpdateNotificationController updateController,
                                    HRMS.Controllers.Vacation.VacationController vacationController,
                                    GetAllLicenseTypeController incapacityTypeController,
                                    LicenseController licenseController,
                                    HRMS.Controllers.Permissions.PermissionController permissionController,
                                    GetAllPermissionTypeController getAllPermissionTypeController) : BaseController(notificationController,
                                                                                                                    updateController)
    {
        private readonly HRMS.Controllers.Vacation.VacationController _vacationController = vacationController;
        private readonly GetAllLicenseTypeController _incapacityTypeController = incapacityTypeController;
        private readonly LicenseController _licenseController = licenseController;
        private readonly HRMS.Controllers.Permissions.PermissionController _permissionController = permissionController;
        private readonly GetAllPermissionTypeController _getAllPermissionTypeController = getAllPermissionTypeController;

        [Route("tiempo-libre/mis-solicitudes")]
        public async Task<IActionResult> Index()
        {
            FreeTimeViewModel model = await PopulateFreeTimeViewModel();

            if (TempData["alert"] is not null)
            {
                var alert = JsonConvert.DeserializeObject<OperationResponseVO>((string)TempData["alert"]);
                model.Response = alert;
            }

            return View(model);
        }

        private async Task<FreeTimeViewModel> PopulateFreeTimeViewModel()
        {
            FreeTimeViewModel model = new();

            IOperationResponseVO response = await _vacationController.GetAllByEmployeeAsync(ActualEmployeeIdentification, Entity);
            model.Vacation.Vacations = response.Content as List<GetAllVacationByEmployeeDTO>;

            response = await _vacationController.GetAsync(ActualEmployeeIdentification, Entity);
            model.Vacation.VacationBalance = response.Content as GetEmployeeVacationBalance;

            response = await _licenseController.GetAllAsync(ActualEmployeeIdentification, new EntityDTO { UserId = ActualUser });
            model.License.Licenses = response.Content as List<GetAllLicenseByEmployeeDTO>;

            response = await _incapacityTypeController.GetAllAsync(new EntityDTO { UserId = ActualUser });
            model.License.LicenseTypeList = response.Content as List<IGetAllLicenseTypeDTO>;

            response = await _permissionController.GetAllAsync(ActualEmployeeIdentification, new EntityDTO { UserId = ActualUser });
            model.Permission.Permissions = response.Content as List<GetAllPermissionByEmployeeDTO>;

            response = await _getAllPermissionTypeController.GetAllAsync(new EntityDTO { UserId = ActualUser });
            model.Permission.PermissionTypeList = response.Content as List<GetAllPermissionTypeDTO>;

            model.Notifications = await this.GetAllNotificationAsync();
            model.Today = GetDateHelper.GetToday();

            return model;
        }
    }
}