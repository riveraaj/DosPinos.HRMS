using DosPinos.HRMS.Entities.Interfaces.Commons.Notification;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Commons.Notification
{
    public interface INotificationRepository
    {
        Task<IEnumerable<IGetAllNotificationDTO>> GetAllAsync(int userId);
        Task<bool> CreateAsync(ICreateNotificationPOCO notification);
        Task<bool> UpdateAsync(IUpdateNotificationDTO notification);
    }
}