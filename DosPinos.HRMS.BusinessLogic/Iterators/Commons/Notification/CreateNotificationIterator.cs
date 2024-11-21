namespace DosPinos.HRMS.BusinessLogic.Iterators.Commons.Notification
{
    internal class CreateNotificationIterator(INotificationRepository notificationRepository) : ICreateNotificationInputPort
    {
        private readonly INotificationRepository _notificationRepository = notificationRepository;

        public async Task CreateAsync(ICreateNotificationPOCO notification)
            => await _notificationRepository.CreateAsync(notification);
    }
}