using DosPinos.HRMS.Entities.Interfaces.Commons.Notifications;

namespace DosPinos.HRMS.Entities.DTOs.Commons.Notifications
{
    public class GetAllNotificationDTO : EntityDTO, IGetAllNotificationDTO
    {
        public int NotificationId { get; set; }
        public string Message { get; set; }
    }
}