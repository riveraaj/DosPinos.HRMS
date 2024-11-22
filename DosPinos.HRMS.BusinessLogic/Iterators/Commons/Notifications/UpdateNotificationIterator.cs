namespace DosPinos.HRMS.BusinessLogic.Iterators.Commons.Notifications
{
    internal class UpdateNotificationIterator(INotificationRepository notificationRepository) : IUpdateNotificationInputPort
    {
        private readonly INotificationRepository _notificationRepository = notificationRepository;

        public async Task UpdateAsync(IUpdateNotificationDTO notification)
            => await _notificationRepository.UpdateAsync(notification);
    }
}