using DosPinos.HRMS.BusinessObjects.Interfaces.Commons.Notifications;
using DosPinos.HRMS.BusinessObjects.Interfaces.Commons.Notifications.POCOs;
using DosPinos.HRMS.Entities.Interfaces.Commons.Notifications;

namespace DosPinos.HRMS.EFCore.Repositories.Commons.Notifications
{
    internal class NotificationRepository(DospinosdbContext context) : INotificationRepository
    {
        private readonly DospinosdbContext _context = context;

        public async Task<IEnumerable<IGetAllNotificationDTO>> GetAllAsync(int userId)
        {
            List<Notification> notificationList = [.. await _context.Notifications.Where(x => x.CreatedFor == userId && x.Read == false).ToListAsync()];
            return notificationList.Select(NotificationMapper.MapFrom).ToList();
        }

        public async Task<bool> CreateAsync(ICreateNotificationPOCO notificationPOCO)
        {
            Notification notification = NotificationMapper.MapFrom(notificationPOCO);

            await _context.Notifications.AddAsync(notification);
            int result = await _context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> UpdateAsync(IUpdateNotificationDTO notificationPOCO)
        {
            Notification notification = _context.Notifications.FirstOrDefault(n => n.NotificationId == notificationPOCO.NotificationId);

            if (notification == null) return false;

            notification.Read = notificationPOCO.IsRead;
            int result = await _context.SaveChangesAsync();

            return result > 0;
        }
    }
}