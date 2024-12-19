using DosPinos.HRMS.Controllers.Commons.Notifications;
using DosPinos.HRMS.Entities.DTOs.Machines;
using DosPinos.HRMS.Entities.Enums.Commons;
using DosPinos.HRMS.Entities.Interfaces.Commons.Base;
using DosPinos.HRMS.Entities.ValueObjects;
using DosPinos.HRMS.WebApp.Controllers.Base;
using DosPinos.HRMS.WebApp.Models.Maintenances.Machines;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DosPinos.HRMS.WebApp.Controllers.Maintenances.Machines
{
    [Authorize(Roles = "3, 6")]
    public class MachineController(GetAllNotificationController getAllNotification,
                                   UpdateNotificationController updateNotification,
                                   HRMS.Controllers.Machines.MachineController controller) : BaseController(getAllNotification,
                                                                                                            updateNotification)
    {
        private readonly HRMS.Controllers.Machines.MachineController _controller = controller;

        [Route("mantenimiento/maquinas")]
        public async Task<IActionResult> Index()
        {
            MachineViewModel model = await PopulateMachineViewModel();

            if (TempData["alert"] is not null)
            {
                var alert = JsonConvert.DeserializeObject<OperationResponseVO>((string)TempData["alert"]);
                model.Response = alert;
            }

            return View(model);
        }

        [HttpPost]
        [Route("mantenimiento/maquinas/nueva-maquina")]
        public async Task<IActionResult> Create(MachineViewModel model)
        {
            model.MachineObj.UserId = ActualUser;

            IOperationResponseVO response = await _controller.CreateAsync(model.MachineObj);

            TempData["alert"] = JsonConvert.SerializeObject(response);
            return RedirectToAction("Index");

        }

        [HttpPost]
        [Route("mantenimiento/maquinas/actualizar")]
        public async Task<IActionResult> Edit(MachineViewModel model)
        {
            model.UpdateMachineObj.UserId = ActualUser;

            IOperationResponseVO response = await _controller.UpdateAsync(model.UpdateMachineObj);

            return Json(new
            {
                success = response.Status == ResponseStatus.Success,
                message = response.Message.FirstOrDefault(),
                status = response.Status.ToString()
            });
        }

        [HttpPost]
        [Route("mantenimiento/maquinas/eliminar")]
        public async Task<IActionResult> Delete(byte machineId)
        {
            IOperationResponseVO response = await _controller.DeleteAsync(machineId, Entity);
            TempData["alert"] = JsonConvert.SerializeObject(response);
            return RedirectToAction("Index");
        }

        private async Task<MachineViewModel> PopulateMachineViewModel()
        {
            MachineViewModel model = new();

            IOperationResponseVO response = await _controller.GetAllTableAsync(Entity);
            model.Machines = response.Content as List<GetAllMachineTableDTO>;

            model.Notifications = await GetAllNotificationAsync();

            return model;
        }
    }
}
