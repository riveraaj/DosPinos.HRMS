using DosPinos.HRMS.Controllers.Commons.Notifications;
using DosPinos.HRMS.Controllers.Securities.Catalogs;
using DosPinos.HRMS.Entities.DTOs.Commons.Base;
using DosPinos.HRMS.Entities.DTOs.Securities;
using DosPinos.HRMS.Entities.Enums.Commons;
using DosPinos.HRMS.Entities.Interfaces.Commons.Base;
using DosPinos.HRMS.Entities.Interfaces.Securities.Catalogs;
using DosPinos.HRMS.Entities.ValueObjects;
using DosPinos.HRMS.WebApp.Controllers.Base;
using DosPinos.HRMS.WebApp.Models.Securities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DosPinos.HRMS.WebApp.Controllers.Securities
{
    [Authorize(Roles = "4, 6")]
    public class UserController(GetAllNotificationController getAllNotification,
                                 UpdateNotificationController updateNotification,
                                 HRMS.Controllers.Securities.UserController controller,
                                 GetAllRoleController getAllRole) : BaseController(getAllNotification,
                                                                                                         updateNotification)
    {
        private readonly HRMS.Controllers.Securities.UserController _controller = controller;
        private readonly GetAllRoleController _getAllRole = getAllRole;

        [Route("usuarios")]
        public async Task<IActionResult> Index()
        {
            UserViewModel model = await PopulateUserViewModel();

            if (TempData["alert"] is not null)
            {
                var alert = JsonConvert.DeserializeObject<OperationResponseVO>((string)TempData["alert"]);
                model.Response = alert;
            }

            return View(model);
        }

        [Route("usuarios/nuevo-usuario")]
        [HttpPost]
        public async Task<IActionResult> Create(UserViewModel model)
        {
            model.UserObj.UserId = ActualUser;

            IOperationResponseVO response = await _controller.CreateAsync(model.UserObj);

            if (response.Status == ResponseStatus.Success)
            {
                TempData["alert"] = JsonConvert.SerializeObject(response);
                return RedirectToAction("Index");
            }

            UserViewModel newModel = await PopulateUserViewModel();
            newModel.Response = response;
            newModel.UserObj = model.UserObj;

            return View("Index", newModel);
        }


        [Route("usuarios/editar")]
        [HttpPost]
        public async Task<IActionResult> Edit(UserViewModel model)
        {
            model.UpdateUserObj.UserId = ActualUser;

            TempData["alert"] = JsonConvert.SerializeObject(await _controller.UpdateAsync(model.UpdateUserObj));

            return RedirectToAction("Index");
        }

        [Route("usuarios/desactivar")]
        [HttpPost]
        public async Task<IActionResult> Delete(UserViewModel model)
        {
            model.DeleteUserObj.UserId = ActualUser;

            TempData["alert"] = JsonConvert.SerializeObject(await _controller.DeleteAsync(model.DeleteUserObj));

            return RedirectToAction("Index");
        }

        private async Task<UserViewModel> PopulateUserViewModel()
        {
            UserViewModel model = new();

            IOperationResponseVO response = await _controller.GetAllActiveAsync(new EntityDTO() { UserId = ActualUser });
            model.Users = response.Content as List<GetAllUserDTO>;

            response = await _getAllRole.GetAllAsync(new EntityDTO() { UserId = ActualUser });
            model.RoleList = response.Content as List<IGetAllRoleDTO>;

            response = await _controller.GetAllAsync(new EntityDTO() { UserId = ActualUser });
            model.EmployeeList = response.Content as List<GetAllWithoutUserDTO>;

            model.Notifications = await this.GetAllNotificationAsync();

            return model;
        }
    }
}