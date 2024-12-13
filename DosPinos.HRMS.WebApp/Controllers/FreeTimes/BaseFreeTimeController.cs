using DosPinos.HRMS.Controllers.Commons.Notifications;
using DosPinos.HRMS.Controllers.Licenses;
using DosPinos.HRMS.Controllers.Licenses.Catalogs;
using DosPinos.HRMS.Controllers.Permissions;
using DosPinos.HRMS.Controllers.Permissions.Catalogs;
using DosPinos.HRMS.Controllers.Vacation;
using DosPinos.HRMS.Entities.DTOs.Commons.Base;
using DosPinos.HRMS.Entities.DTOs.Commons.FreeTimes;
using DosPinos.HRMS.Entities.DTOs.Licenses;
using DosPinos.HRMS.Entities.DTOs.Permissions;
using DosPinos.HRMS.Entities.DTOs.Permissions.Catalogs;
using DosPinos.HRMS.Entities.DTOs.Vacations;
using DosPinos.HRMS.Entities.Enums.FreeTimes;
using DosPinos.HRMS.Entities.Interfaces.Commons.Base;
using DosPinos.HRMS.Entities.Interfaces.Licenses.Catalogs;
using DosPinos.HRMS.WebApp.Controllers.Base;
using DosPinos.HRMS.WebApp.Helpers;
using DosPinos.HRMS.WebApp.Models.FreeTimes;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DosPinos.HRMS.WebApp.Controllers.FreeTimes
{
    public abstract class BaseFreeTimeController(GetAllNotificationController notificationController,
                                        UpdateNotificationController updateController,
                                        VacationController vacationController,
                                        GetAllLicenseTypeController incapacityTypeController,
                                        LicenseController licenseController,
                                        PermissionController permissionController,
                                        GetAllPermissionTypeController getAllPermissionTypeController,
                                        HRMS.Controllers.Commons.FreeTimes.FreeTimeController controller) : BaseController(notificationController,
                                                                                                                           updateController)
    {
        private readonly VacationController _vacationController = vacationController;
        private readonly GetAllLicenseTypeController _incapacityTypeController = incapacityTypeController;
        private readonly LicenseController _licenseController = licenseController;
        private readonly PermissionController _permissionController = permissionController;
        private readonly GetAllPermissionTypeController _getAllPermissionTypeController = getAllPermissionTypeController;
        private readonly HRMS.Controllers.Commons.FreeTimes.FreeTimeController _controller = controller;

        public IActionResult Evaluation(ManageApplicationViewModel model)
        {
            model.EvaluationObj.EmployeeId = ActualEmployee;
            model.EvaluationObj.UserId = ActualUser;
            TempData["Evaluation"] = JsonConvert.SerializeObject(model.EvaluationObj);

            switch (model.EvaluationObj.Code)
            {
                case ApplicationCode.License:
                    return RedirectToAction("Evaluate", "License");
                case ApplicationCode.Permission:
                    return RedirectToAction("Evaluate", "Permission");
                default:
                    return RedirectToAction("Evaluate", "Vacation");
            }
        }

        internal async Task<FreeTimeViewModel> PopulateFreeTimeViewModel()
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

        internal async Task<ManageApplicationViewModel> PopulateManageApplicationViewModel()
        {
            ManageApplicationViewModel model = new();

            IOperationResponseVO response = await _controller.GetAllAsync(new EntityDTO { UserId = ActualUser });
            model.Applications = response.Content as List<GetAllPendingApplicantDTO>;

            model.Notifications = await this.GetAllNotificationAsync();

            return model;
        }
    }
}