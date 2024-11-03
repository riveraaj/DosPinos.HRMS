namespace DosPinos.HRMS.BusinessLogic.Iterators.Commons.Notification
{
    internal class CreateNotificationIterator(INotificationRepository notificationRepository,
                                              ICreateLogIterator createLogIterator) : BaseIterator(createLogIterator),
                                                                                      ICreateNotificationInputPort
    {
        private readonly INotificationRepository _notificationRepository = notificationRepository;

        public async Task<IOperationResponseVO> CreateAsync(ICreateNotificationPOCO notification)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                // Validate DTO model
                Helpers.ValidationResult validationResult = notification.ValidateModel();
                if (!validationResult.IsValid) return this.CustomWarning(validationResult.ErrorMessages);

                //Create notification
                var result = await _notificationRepository.CreateAsync(notification);
                if (!result) response = this.CustomWarning(BusinessObjects.Resources.Commons.Commons.WarningMessage);
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Maintenance, ActionCategory.Create, exception, notification);
            }

            return response;
        }
    }
}