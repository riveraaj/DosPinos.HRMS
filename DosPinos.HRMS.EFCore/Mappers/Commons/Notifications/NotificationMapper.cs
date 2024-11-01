namespace DosPinos.HRMS.EFCore.Mappers.Commons.Notifications
{
    internal static class NotificationMapper
    {
        public static INotificationDTO MapFrom(Notification notification)
            => new NotificationDTO()
            {
                NotificationId = notification.NotificationId,
                Message = notification.Message,
                IsRead = notification.Read,
                CreatedDate = notification.CreatedAt,
                UserId = notification.UserId,
            };

        public static Notification MapFrom(ICreateNotificationPOCO notificationPOCO)
            => new()
            {
                Message = notificationPOCO.Message,
                UserId = notificationPOCO.UserId,
                CreatedAt = DateTime.Now,
                Read = notificationPOCO.IsRead,
            };
    }
}