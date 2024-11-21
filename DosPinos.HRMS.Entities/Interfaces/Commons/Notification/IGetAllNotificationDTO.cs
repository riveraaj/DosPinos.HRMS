namespace DosPinos.HRMS.Entities.Interfaces.Commons.Notification
{
    public interface IGetAllNotificationDTO : IEntityDTO
    {
        int NotificationId { get; set; }
        string Message { get; set; }
    }
}