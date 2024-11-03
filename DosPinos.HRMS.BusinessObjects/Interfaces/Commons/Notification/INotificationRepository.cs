namespace DosPinos.HRMS.BusinessObjects.Interfaces.Commons.Notification
{
    public interface INotificationRepository
    {
        Task<IEnumerable<INotificationDTO>> GetAllAsync(int userId);
        Task<bool> CreateAsync(ICreateNotificationPOCO notification);
        Task<bool> UpdateAsync(IUpdateNotificationPOCO notification);
    }
}