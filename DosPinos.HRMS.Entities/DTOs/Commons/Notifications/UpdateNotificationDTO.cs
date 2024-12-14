namespace DosPinos.HRMS.Entities.DTOs.Commons.Notifications
{
    public class UpdateNotificationDTO : IUpdateNotificationDTO
    {
        public int NotificationId { get; set; }
        public bool IsRead { get; } = true;
        public string ControllerOrigin { get; set; }
        public string ActionOrigin { get; set; }
    }
}