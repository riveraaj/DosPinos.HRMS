using System.Security.Claims;
using DosPinos.HRMS.Controllers.Commons.Notification;
using DosPinos.HRMS.Entities.DTOs.Commons.Base;
using DosPinos.HRMS.Entities.Interfaces.Commons.Base;
using DosPinos.HRMS.Entities.Interfaces.Commons.Notification;
using Microsoft.AspNetCore.Mvc;

namespace DosPinos.HRMS.WebApp.Controllers.Base
{
    public class BaseController(GetAllNotificationController getAllController,
                                UpdateNotificationController updateController) : Controller
    {
        private readonly GetAllNotificationController _getAllController = getAllController;
        private readonly UpdateNotificationController _updateController = updateController;
        public int ActualUser => int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

        public async Task<List<IGetAllNotificationDTO>> GetAllAsync()
        {
            IOperationResponseVO response = await _getAllController.GetAllAsync(new EntityDTO { UserId = ActualUser });
            return (List<IGetAllNotificationDTO>)response.Content;
        }

        public async Task UpdateAsync(IUpdateNotificationDTO notification) => await _updateController.UpdateAsync(notification);
    }
}