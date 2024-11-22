using DosPinos.HRMS.Entities.Interfaces.Commons.Notifications;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Commons.Notifications
{
    public interface INotificationRepository
    {
        Task<IEnumerable<IGetAllNotificationDTO>> GetAllAsync(int userId);
        Task<bool> CreateAsync(ICreateNotificationPOCO notification);
        Task<bool> UpdateAsync(IUpdateNotificationDTO notification);
    }
}