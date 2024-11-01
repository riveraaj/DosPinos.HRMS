namespace DosPinos.HRMS.EFCore.Repositories.Commons.Notifications
{
    internal class NotificationRepository(DospinosdbContext context) : INotificationRepository
    {
        private readonly DospinosdbContext _context = context;

        public IEnumerable<INotificationDTO> GetAll(int userId)
        {
            List<INotificationDTO> result = [];

            List<Notification> notificationList = [.. _context.Notifications];

            foreach (var notification in notificationList)
                result.Add(NotificationMapper.MapFrom(notification));

            return result;
        }

        public bool Create(ICreateNotificationPOCO notificationPOCO)
        {
            Notification notification = NotificationMapper.MapFrom(notificationPOCO);

            _context.Notifications.Add(notification);
            int result = _context.SaveChanges();

            return result > 0;
        }

        public bool Update(IUpdateNotificationPOCO notificationPOCO)
        {
            Notification notification = _context.Notifications.FirstOrDefault(n => n.NotificationId == notificationPOCO.NotificationId);

            if (notification == null) return false;

            notification.Read = notificationPOCO.IsRead;
            int result = _context.SaveChanges();

            return result > 0;
        }
    }
}