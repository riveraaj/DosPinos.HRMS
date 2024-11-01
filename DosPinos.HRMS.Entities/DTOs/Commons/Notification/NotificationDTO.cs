namespace DosPinos.HRMS.Entities.DTOs.Commons.Notification
{
    public class NotificationDTO : EntityDTO, INotificationDTO
    {
        public int NotificationId { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}