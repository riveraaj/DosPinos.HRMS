using DosPinos.HRMS.Controllers.Commons.Notifications;
using DosPinos.HRMS.Entities.DTOs.ChristmasBonus;
using DosPinos.HRMS.Entities.DTOs.Commons.Base;
using DosPinos.HRMS.Entities.Enums.Commons;
using DosPinos.HRMS.Entities.Interfaces.Commons.Base;
using DosPinos.HRMS.Entities.ValueObjects;
using DosPinos.HRMS.WebApp.Controllers.Base;
using DosPinos.HRMS.WebApp.Models.ChristmasBonus;
using DosPinos.HRMS.WebApp.Resources.ChristmasBonus;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DosPinos.HRMS.WebApp.Controllers.ChristmasBonus
{
    [Authorize]
    public class ChristmasBonusController(GetAllNotificationController getAllNotificationController,
                                        UpdateNotificationController updateNotificationController,
                                        HRMS.Controllers.ChristmasBonus.ChristmasBonusController christmas) : BaseController(getAllNotificationController,
                                                                                                                             updateNotificationController)
    {
        private readonly HRMS.Controllers.ChristmasBonus.ChristmasBonusController _christmas = christmas;

        [Route("aguinaldo")]
        public async Task<IActionResult> Index()
        {
            ChristmasBonusViewModel model = new();

            IOperationResponseVO response = await _christmas.GetAllAsync(new EntityDTO { UserId = ActualUser });

            if (TempData["alert"] is not null)
            {
                var alert = JsonConvert.DeserializeObject<OperationResponseVO>((string)TempData["alert"]);
                model.Response = alert;
            }

            model.ChristmasBonus = response.Content as List<GetAllChristmasBonusDTO>;
            model.Notifications = await this.GetAllAsync();

            return View(model);
        }

        [Route("aguinaldo/calcular")]
        [HttpPost]
        public async Task<IActionResult> Create()
        {
            var response = await _christmas.CreateAsync(new EntityDTO { UserId = ActualUser });

            if (response.Status == ResponseStatus.Success) response.Message = [ChristmasBonusLabel.SuccessMessage];

            TempData["alert"] = JsonConvert.SerializeObject(response);
            return RedirectToAction("Index");
        }
    }
}