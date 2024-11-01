namespace DosPinos.HRMS.Entities.Interfaces.Commons.Notification
{
    public interface INotificationDTO : IEntityDTO
    {
        int NotificationId { get; set; }
        string Message { get; set; }
        bool IsRead { get; set; }
        DateTime CreatedDate { get; set; }
    }
}