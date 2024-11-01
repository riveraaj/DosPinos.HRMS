namespace DosPinos.HRMS.BusinessObjects.Interfaces.Commons.Notification.POCOs
{
    public interface ICreateNotificationPOCO : IEntityDTO
    {
        string Message { get; set; }
        bool IsRead { get; }
    }
}