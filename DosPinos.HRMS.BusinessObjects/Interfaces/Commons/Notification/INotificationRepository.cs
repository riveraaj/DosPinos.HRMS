namespace DosPinos.HRMS.BusinessObjects.Interfaces.Commons.Notification
{
    public interface INotificationRepository
    {
        IEnumerable<INotificationDTO> GetAll(int userId);
        bool Create(ICreateNotificationPOCO notification);
        bool Update(IUpdateNotificationPOCO notification);
    }
}