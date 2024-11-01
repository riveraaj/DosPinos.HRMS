namespace DosPinos.HRMS.BusinessLogic.Mappers
{
    internal static class NotificationMapper
    {
        public static IUpdateNotificationPOCO MapFrom(INotificationDTO notification)
            => new UpdateNotificationPOCO()
            {
                NotificationId = notification.NotificationId,
                UserId = notification.UserId,
            };
    }
}