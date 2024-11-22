using DosPinos.HRMS.Entities.Interfaces.Commons.Notifications;

namespace DosPinos.HRMS.Entities.DTOs.Commons.Notifications
{
    public class UpdateNotificationDTO : IUpdateNotificationDTO
    {
        public int NotificationId { get; set; }
        public bool IsRead { get; }
    }
}