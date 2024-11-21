namespace DosPinos.HRMS.EFCore.Mappers.Commons.Notifications
{
    internal static class NotificationMapper
    {
        public static IGetAllNotificationDTO MapFrom(Notification notification)
            => new GetAllNotificationDTO()
            {
                NotificationId = notification.NotificationId,
                Message = notification.Message,
                UserId = notification.CreatedFor,
            };

        public static Notification MapFrom(ICreateNotificationPOCO notificationPOCO)
            => new()
            {
                CreatedAt = notificationPOCO.CreatedAt,
                CreatedFor = notificationPOCO.CreatedFor,
                CreatedTo = notificationPOCO.CreatedTo,
                Message = notificationPOCO.Message,
                Read = notificationPOCO.IsRead,
            };
    }
}