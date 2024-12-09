using System.Security.Claims;
using DosPinos.HRMS.Controllers.Commons.Notifications;
using DosPinos.HRMS.Entities.DTOs.Commons.Base;
using DosPinos.HRMS.Entities.Interfaces.Commons.Base;
using DosPinos.HRMS.Entities.Interfaces.Commons.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace DosPinos.HRMS.WebApp.Controllers.Base
{
    public class BaseController(GetAllNotificationController getAllController,
                                UpdateNotificationController updateController) : Controller
    {
        private readonly GetAllNotificationController _getAllController = getAllController;
        private readonly UpdateNotificationController _updateController = updateController;
        public int ActualUser => int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        public int ActualEmployeeIdentification => int.Parse(User.FindFirst("Identification").Value);
        public int ActualEmployee => int.Parse(User.FindFirst("Employee").Value);
        public int ActualEmployeeManager => int.Parse(User.FindFirst("Manager").Value);
        public int ActualUserRole => int.Parse(User.FindFirst(ClaimTypes.Role).Value);
        public IEntityDTO Entity => new EntityDTO { UserId = ActualUser };

        public async Task<List<IGetAllNotificationDTO>> GetAllNotificationAsync()
        {
            IOperationResponseVO response = await _getAllController.GetAllAsync(new EntityDTO { UserId = ActualUser });
            return (List<IGetAllNotificationDTO>)response.Content;
        }

        public async Task UpdateAsync(IUpdateNotificationDTO notification) => await _updateController.UpdateAsync(notification);
    }
}