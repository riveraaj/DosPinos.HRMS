namespace DosPinos.HRMS.EFCore.Repositories.Commons.Notifications
{
    internal class NotificationRepository(DospinosdbContext context) : INotificationRepository
    {
        private readonly DospinosdbContext _context = context;

        public async Task<IEnumerable<INotificationDTO>> GetAllAsync(int userId)
        {
            List<Notification> notificationList = [.. await _context.Notifications.ToListAsync()];
            return notificationList.Select(NotificationMapper.MapFrom).ToList();
        }

        public async Task<bool> CreateAsync(ICreateNotificationPOCO notificationPOCO)
        {
            Notification notification = NotificationMapper.MapFrom(notificationPOCO);

            await _context.Notifications.AddAsync(notification);
            int result = await _context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> UpdateAsync(IUpdateNotificationPOCO notificationPOCO)
        {
            Notification notification = _context.Notifications.FirstOrDefault(n => n.NotificationId == notificationPOCO.NotificationId);

            if (notification == null) return false;

            notification.Read = notificationPOCO.IsRead;
            int result = await _context.SaveChangesAsync();

            return result > 0;
        }
    }
}