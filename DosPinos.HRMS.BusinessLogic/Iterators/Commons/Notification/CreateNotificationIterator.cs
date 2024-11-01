namespace DosPinos.HRMS.BusinessLogic.Iterators.Commons.Notification
{
    internal class CreateNotificationIterator(INotificationRepository notificationRepository,
                                              ICreateLogIterator createLogIterator) : BaseIterator(createLogIterator),
                                                                                      ICreateNotificationInputPort
    {
        private readonly INotificationRepository _notificationRepository = notificationRepository;

        public IOperationResponseVO Create(ICreateNotificationPOCO notification)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                // Validate DTO model
                var validationResult = notification.ValidateModel();
                if (!validationResult.IsValid) this.CustomWarning(validationResult.ErrorMessages);

                //Create notification
                var result = _notificationRepository.Create(notification);
                if (!result) this.CustomWarning(Resources.Commons.Commons.WarningMessage);
            }
            catch (Exception exception)
            {
                response = this.HandlerLog(Module.Notification, ActionCategory.Create, exception, notification);
            }

            return response;
        }
    }
}