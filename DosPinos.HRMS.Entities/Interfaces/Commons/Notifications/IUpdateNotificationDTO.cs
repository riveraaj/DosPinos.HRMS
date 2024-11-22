namespace DosPinos.HRMS.Entities.Interfaces.Commons.Notifications
{
    public interface IUpdateNotificationDTO
    {
        int NotificationId { get; set; }
        bool IsRead { get; }
    }
}