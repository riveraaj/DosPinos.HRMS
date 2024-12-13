using DosPinos.HRMS.Controllers.Commons.Notifications;
using DosPinos.HRMS.Controllers.Licenses;
using DosPinos.HRMS.Controllers.Licenses.Catalogs;
using DosPinos.HRMS.Controllers.Permissions.Catalogs;
using DosPinos.HRMS.Controllers.Vacation;
using DosPinos.HRMS.Entities.ValueObjects;
using DosPinos.HRMS.WebApp.Models.FreeTimes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DosPinos.HRMS.WebApp.Controllers.FreeTimes
{
    [Authorize]
    public class FreeTimeController(GetAllNotificationController notificationController,
                                    UpdateNotificationController updateController,
                                    VacationController vacationController,
                                    GetAllLicenseTypeController incapacityTypeController,
                                    LicenseController licenseController,
                                    HRMS.Controllers.Permissions.PermissionController permissionController,
                                    GetAllPermissionTypeController getAllPermissionTypeController,
                                    HRMS.Controllers.Commons.FreeTimes.FreeTimeController controller) : BaseFreeTimeController(notificationController,
                                                                                                                               updateController,
                                                                                                                               vacationController,
                                                                                                                               incapacityTypeController,
                                                                                                                               licenseController,
                                                                                                                               permissionController,
                                                                                                                               getAllPermissionTypeController,
                                                                                                                               controller)
    {
        [Route("tiempo-libre/mis-solicitudes")]
        public async Task<IActionResult> Index()
        {
            FreeTimeViewModel model = await this.PopulateFreeTimeViewModel();

            if (TempData["alert"] is not null)
            {
                var alert = JsonConvert.DeserializeObject<OperationResponseVO>((string)TempData["alert"]);
                model.Response = alert;
            }

            return View(model);
        }

        [Route("tiempo-libre/gestion-solicitudes")]
        public async Task<IActionResult> ManageApplication()
        {
            ManageApplicationViewModel model = await this.PopulateManageApplicationViewModel();

            if (TempData["alert"] is not null)
            {
                var alert = JsonConvert.DeserializeObject<OperationResponseVO>((string)TempData["alert"]);
                model.Response = alert;
            }

            return View(model);
        }

        [Route("tiempo-libre/gestion-solicitudes/evaluar")]
        [HttpPost]
        public IActionResult Evaluate(ManageApplicationViewModel model) => this.Evaluation(model);
    }
}