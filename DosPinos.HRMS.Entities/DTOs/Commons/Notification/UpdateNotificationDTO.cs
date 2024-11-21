namespace DosPinos.HRMS.Entities.DTOs.Commons.Notification
{
    public class UpdateNotificationDTO : IUpdateNotificationDTO
    {
        public int NotificationId { get; set; }
        public bool IsRead { get; }
    }
}