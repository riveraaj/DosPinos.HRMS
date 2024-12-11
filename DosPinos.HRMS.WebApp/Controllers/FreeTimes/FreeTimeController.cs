using DosPinos.HRMS.Controllers.Commons.Notifications;
using DosPinos.HRMS.Controllers.Incapacities;
using DosPinos.HRMS.Controllers.Incapacities.Catalogs;
using DosPinos.HRMS.Controllers.Permissions;
using DosPinos.HRMS.Controllers.Permissions.Catalogs;
using DosPinos.HRMS.Entities.DTOs.Commons.Base;
using DosPinos.HRMS.Entities.DTOs.Incapacities;
using DosPinos.HRMS.Entities.DTOs.Permissions;
using DosPinos.HRMS.Entities.DTOs.Permissions.Catalogs;
using DosPinos.HRMS.Entities.DTOs.Vacations;
using DosPinos.HRMS.Entities.Enums.Commons;
using DosPinos.HRMS.Entities.Interfaces.Commons.Base;
using DosPinos.HRMS.Entities.Interfaces.Incapacities.Catalogs;
using DosPinos.HRMS.Entities.ValueObjects;
using DosPinos.HRMS.WebApp.Controllers.Base;
using DosPinos.HRMS.WebApp.Helpers;
using DosPinos.HRMS.WebApp.Models;
using DosPinos.HRMS.WebApp.Models.FreeTimes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DosPinos.HRMS.WebApp.Controllers.Vacations
{
    [Authorize]
    public class FreeTimeController(GetAllNotificationController notificationController,
                                    UpdateNotificationController updateController,
                                    HRMS.Controllers.Vacation.VacationController controller,
                                    GetAllIncapacityTypeController incapacityTypeController,
                                    LicenseController licenseController,
                                    PermissionController permissionController,
                                    GetAllPermissionTypeController getAllPermissionTypeController) : BaseController(notificationController,
                                                                                                                    updateController)
    {
        private readonly HRMS.Controllers.Vacation.VacationController _controller = controller;
        private readonly GetAllIncapacityTypeController _incapacityTypeController = incapacityTypeController;
        private readonly LicenseController _licenseController = licenseController;
        private readonly PermissionController _permissionController = permissionController;
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

        [HttpPost]
        [Route("tiempo-libre/mis-solicitudes/vacaciones")]
        public async Task<IActionResult> CreateVacation(FreeTimeViewModel model)
        {
            model.VacationObj.EmployeeId = this.ActualEmployee;
            model.VacationObj.ManagerId = this.ActualEmployeeManager;
            model.VacationObj.UserId = this.ActualUser;

            model.Response = await _controller.CreateAsync(model.VacationObj);

            if (model.Response.Status == ResponseStatus.Success)
            {
                TempData["alert"] = JsonConvert.SerializeObject(model.Response);
                return RedirectToAction("Index");
            }

            IOperationResponseVO response = await _controller.GetAllByEmployeeAsync(ActualEmployeeIdentification, Entity);

            model.Notifications = await this.GetAllNotificationAsync();
            model.Vacations = response.Content as List<GetAllVacationByEmployeeDTO>;
            model.Today = GetDateHelper.GetToday();

            return View("Index", model);
        }

        [HttpPost]
        [Route("tiempo-libre/mis-solicitudes/incapacidad")]
        public async Task<IActionResult> CreateLicense(FreeTimeViewModel model)
        {
            model.LicenseObj.EmployeeId = this.ActualEmployee;
            model.LicenseObj.UserId = this.ActualUser;

            model.Response = await _licenseController.CreateAsync(model.LicenseObj);

            TempData["alert"] = JsonConvert.SerializeObject(model.Response);

            if (model.Response.Status == ResponseStatus.Success) return RedirectToAction("Index");

            FreeTimeViewModel newModel = await PopulateFreeTimeViewModel();
            newModel.LicenseObj = model.LicenseObj;
            newModel.Response = model.Response;

            return View("Index", newModel);
        }

        [HttpPost]
        [Route("tiempo-libre/mis-solicitudes/permiso-especial")]
        public async Task<IActionResult> CreatePermission(FreeTimeViewModel model)
        {
            model.PermissionObj.EmployeeId = this.ActualEmployee;
            model.PermissionObj.UserId = this.ActualUser;

            model.Response = await _permissionController.CreateAsync(model.PermissionObj);

            TempData["alert"] = JsonConvert.SerializeObject(model.Response);

            if (model.Response.Status == ResponseStatus.Success) return RedirectToAction("Index");

            FreeTimeViewModel newModel = await PopulateFreeTimeViewModel();
            newModel.PermissionObj = model.PermissionObj;
            newModel.Response = model.Response;

            return View("Index", newModel);
        }

        public async Task<IActionResult> Pending()
        {
            var response = await _controller.GetAllAsync(Entity);

            VacationViewModel model = new()
            {
                Get = (List<GetAllVacationPendingDTO>)response.Content
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EvaluationVacation(EvaluateVacationDTO vacation)
        {
            vacation.UserId = ActualUser;
            var response = await _controller.EvaluateAsync(vacation);

            ViewData["alert"] = response;

            return RedirectToAction("Pending");
        }

        public async Task<FreeTimeViewModel> PopulateFreeTimeViewModel()
        {
            FreeTimeViewModel model = new();

            IOperationResponseVO response = await _controller.GetAllByEmployeeAsync(ActualEmployeeIdentification, Entity);
            model.Vacations = response.Content as List<GetAllVacationByEmployeeDTO>;

            response = await _licenseController.GetAllAsync(ActualEmployeeIdentification, new EntityDTO { UserId = ActualUser });
            model.Licenses = response.Content as List<GetAllLicenseByEmployeeDTO>;

            response = await _permissionController.GetAllAsync(ActualEmployeeIdentification, new EntityDTO { UserId = ActualUser });
            model.Permissions = response.Content as List<GetAllPermissionByEmployeeDTO>;

            response = await _controller.GetAsync(ActualEmployeeIdentification, Entity);
            model.VacationBalance = response.Content as GetEmployeeVacationBalance;

            response = await _incapacityTypeController.GetAllAsync(new EntityDTO { UserId = ActualUser });
            model.LicenseTypeList = response.Content as List<IGetAllIncapacityTypeDTO>;

            response = await _getAllPermissionTypeController.GetAllAsync(new EntityDTO { UserId = ActualUser });
            model.PermissionTypeList = response.Content as List<GetAllPermissionTypeDTO>;

            model.Notifications = await this.GetAllNotificationAsync();
            model.Today = GetDateHelper.GetToday();

            return model;
        }
    }
}