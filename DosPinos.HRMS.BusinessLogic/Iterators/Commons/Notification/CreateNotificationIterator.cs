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
                Helpers.ValidationResult validationResult = notification.ValidateModel();
                if (!validationResult.IsValid) return this.CustomWarning(validationResult.ErrorMessages);

                //Create notification
                var result = _notificationRepository.Create(notification);
                if (!result) response = this.CustomWarning(Resources.Commons.Commons.WarningMessage);
            }
            catch (Exception exception)
            {
                response = this.HandlerLog(Module.Maintenance, ActionCategory.Create, exception, notification);
            }

            return response;
        }
    }
}