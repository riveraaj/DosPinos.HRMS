namespace DosPinos.HRMS.Entities.Interfaces.Commons.Notification
{
    public interface IUpdateNotificationDTO
    {
        int NotificationId { get; set; }
        bool IsRead { get; }
    }
}