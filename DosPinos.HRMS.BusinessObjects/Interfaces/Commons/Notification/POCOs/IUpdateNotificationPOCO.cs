namespace DosPinos.HRMS.BusinessObjects.Interfaces.Commons.Notification.POCOs
{
    public interface IUpdateNotificationPOCO : IEntityDTO
    {
        int NotificationId { get; set; }
        bool IsRead { get; }
    }
}