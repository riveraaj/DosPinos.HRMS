using DosPinos.HRMS.Controllers.Commons.Notifications;
using DosPinos.HRMS.Controllers.Employees.Catalogs.IncomeTaxes;
using DosPinos.HRMS.Controllers.Employees.Catalogs.SalaryCategories;
using DosPinos.HRMS.Entities.Interfaces.Commons.Base;
using DosPinos.HRMS.Entities.Interfaces.Employees.Catalogs;
using DosPinos.HRMS.Entities.ValueObjects;
using DosPinos.HRMS.WebApp.Controllers.Base;
using DosPinos.HRMS.WebApp.Models.Maintenances.SalaryCategories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DosPinos.HRMS.WebApp.Controllers.Maintenances.SalaryCategories
{
    [Authorize(Roles = "3, 6")]
    public class SalaryCategoryController(GetAllNotificationController getAllNotification,
                                     UpdateNotificationController updateNotification,
                                     HRMS.Controllers.SalaryCategories.SalaryCategoryController controller,
                                     GetAllIncomeTaxController getAll,
                                     GetAllSalaryCategoryController getAllSG) : BaseController(getAllNotification, updateNotification)
    {
        private readonly HRMS.Controllers.SalaryCategories.SalaryCategoryController _controller = controller;
        private readonly GetAllIncomeTaxController _getAll = getAll;
        private readonly GetAllSalaryCategoryController _getAllSG = getAllSG;

        [Route("mantenimiento/categoria-salarial")]
        public async Task<IActionResult> Index()
        {
            SalaryCategoryViewModel model = await PopulateSalaryCategoryViewModel();

            if (TempData["alert"] is not null)
            {
                var alert = JsonConvert.DeserializeObject<OperationResponseVO>((string)TempData["alert"]);
                model.Response = alert;
            }

            return View(model);
        }

        [HttpPost]
        [Route("mantenimiento/categoria-salarial/nueva-categoria")]
        public async Task<IActionResult> Create(SalaryCategoryViewModel model)
        {
            model.SalaryCategoryObj.UserId = ActualUser;

            IOperationResponseVO response = await _controller.CreateAsync(model.SalaryCategoryObj);

            TempData["alert"] = JsonConvert.SerializeObject(response);
            return RedirectToAction("Index");

        }

        [HttpPost]
        [Route("mantenimiento/categoria-salarial/eliminar")]
        public async Task<IActionResult> Delete(byte salaryCategoryId)
        {
            IOperationResponseVO response = await _controller.DeleteAsync(salaryCategoryId, Entity);
            TempData["alert"] = JsonConvert.SerializeObject(response);
            return RedirectToAction("Index");
        }

        private async Task<SalaryCategoryViewModel> PopulateSalaryCategoryViewModel()
        {
            SalaryCategoryViewModel model = new();

            IOperationResponseVO response = await _getAll.GetAllAsync(Entity);
            model.IncomeTaxList = response.Content as List<IGetAllIncomeTaxDTO>;

            response = await _getAllSG.GetAllAsync(Entity);
            model.SalaryCategories = response.Content as List<IGetAllSalaryCategoryDTO>;

            model.Notifications = await this.GetAllNotificationAsync();

            return model;
        }
    }
}