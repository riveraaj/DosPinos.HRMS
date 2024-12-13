using DosPinos.HRMS.Controllers.Commons.Notifications;
using DosPinos.HRMS.Entities.DTOs.Commons.Base;
using DosPinos.HRMS.Entities.DTOs.Commons.FreeTimes;
using DosPinos.HRMS.Entities.Interfaces.Commons.Base;
using DosPinos.HRMS.WebApp.Controllers.Base;
using DosPinos.HRMS.WebApp.Models.FreeTimes;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DosPinos.HRMS.WebApp.Controllers.Vacations
{
    public class VacationController(GetAllNotificationController notificationController,
                                    UpdateNotificationController updateController,
                                    HRMS.Controllers.Vacation.VacationController controller) : BaseController(notificationController,
                                                                                                              updateController)
    {
        private readonly HRMS.Controllers.Vacation.VacationController _controller = controller;

        [HttpPost]
        [Route("tiempo-libre/mis-solicitudes/vacaciones")]
        public async Task<IActionResult> Create(FreeTimeViewModel model)
        {
            model.Vacation.VacationObj.EmployeeId = this.ActualEmployee;
            model.Vacation.VacationObj.ManagerId = this.ActualEmployeeManager;
            model.Vacation.VacationObj.UserId = this.ActualUser;

            model.Response = await _controller.CreateAsync(model.Vacation.VacationObj);

            TempData["alert"] = JsonConvert.SerializeObject(model.Response);

            return RedirectToAction("Index", "FreeTime");
        }

        [HttpPost]
        [Route("tiempo-libre/mis-solicitudes/eliminar-vacaciones")]
        public async Task<IActionResult> Delete(int vacationId)
        {
            IOperationResponseVO response = await _controller.DeleteAsync(vacationId, new EntityDTO { UserId = ActualUser });

            TempData["alert"] = JsonConvert.SerializeObject(response);

            return RedirectToAction("Index", "FreeTime");
        }

        public async Task<IActionResult> Evaluate()
        {
            if (TempData["Evaluation"] is not null)
            {
                var model = JsonConvert.DeserializeObject<EvaluateApplicationDTO>((string)TempData["Evaluation"]);
                IOperationResponseVO response = await _controller.EvaluateAsync(model);

                TempData["alert"] = JsonConvert.SerializeObject(response);
                return RedirectToAction("ManageApplication", "FreeTime");
            }

            return RedirectToAction("ManageApplication", "FreeTime");
        }
    }
}