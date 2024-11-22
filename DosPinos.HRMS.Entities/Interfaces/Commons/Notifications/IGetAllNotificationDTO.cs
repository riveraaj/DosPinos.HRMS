namespace DosPinos.HRMS.Entities.Interfaces.Commons.Notifications
{
    public interface IGetAllNotificationDTO : IEntityDTO
    {
        int NotificationId { get; set; }
        string Message { get; set; }
    }
}