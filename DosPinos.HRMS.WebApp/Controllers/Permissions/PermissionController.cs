using DosPinos.HRMS.Controllers.Commons.Notifications;
using DosPinos.HRMS.Entities.DTOs.Commons.Base;
using DosPinos.HRMS.Entities.Interfaces.Commons.Base;
using DosPinos.HRMS.WebApp.Controllers.Base;
using DosPinos.HRMS.WebApp.Models.FreeTimes;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DosPinos.HRMS.WebApp.Controllers.Permissions
{
    public class PermissionController(GetAllNotificationController notificationController,
                                      UpdateNotificationController updateController,
                                      HRMS.Controllers.Permissions.PermissionController controller) : BaseController(notificationController,
                                                                                                                     updateController)
    {
        private readonly HRMS.Controllers.Permissions.PermissionController _controller = controller;

        [HttpPost]
        [Route("tiempo-libre/mis-solicitudes/permiso-especial")]
        public async Task<IActionResult> Create(FreeTimeViewModel model)
        {
            if (model.Permission.FormFile != null)
            {
                using (MemoryStream memoryStream = new())
                {
                    await model.Permission.FormFile.CopyToAsync(memoryStream);
                    model.Permission.PermissionObj.ImageObj.Data = memoryStream.ToArray();
                }

                model.Permission.PermissionObj.ImageObj.Name = model.Permission.FormFile.FileName;
            }

            model.Permission.PermissionObj.EmployeeId = this.ActualEmployee;
            model.Permission.PermissionObj.ManagerId = this.ActualEmployeeManager;
            model.Permission.PermissionObj.UserId = this.ActualUser;

            model.Response = await _controller.CreateAsync(model.Permission.PermissionObj);

            TempData["alert"] = JsonConvert.SerializeObject(model.Response);

            return RedirectToAction("Index", "FreeTime");
        }

        [HttpPost]
        [Route("tiempo-libre/mis-solicitudes/eliminar-permiso")]
        public async Task<IActionResult> Delete(int permissionId)
        {
            IOperationResponseVO response = await _controller.DeleteAsync(permissionId, new EntityDTO { UserId = ActualUser });

            TempData["alert"] = JsonConvert.SerializeObject(response);

            return RedirectToAction("Index", "FreeTime");
        }
    }
}