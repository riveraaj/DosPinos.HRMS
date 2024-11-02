namespace DosPinos.HRMS.BusinessLogic.Iterators.Commons.Notification
{
    internal class UpdateNotificationIterator(INotificationRepository notificationRepository,
                                              ICreateLogIterator createLogIterator,
                                              IOutputPort outputPort) : BaseIterator(createLogIterator),
                                                                        IUpdateNotificationInputPort
    {
        private readonly INotificationRepository _notificationRepository = notificationRepository;
        private readonly IOutputPort _outputPort = outputPort;

        public void Update(INotificationDTO notificationDTO)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                //Map
                IUpdateNotificationPOCO notification = NotificationMapper.MapFrom(notificationDTO);

                // Validate DTO model
                Helpers.ValidationResult validationResult = notification.ValidateModel();
                if (!validationResult.IsValid)
                {
                    response = this.CustomWarning(validationResult.ErrorMessages);
                    _outputPort.Handle(response);
                    return;
                }

                //Update notification
                var result = _notificationRepository.Update(notification);
                if (!result) response = this.CustomWarning(BusinessObjects.Resources.Commons.Commons.WarningMessage);
            }
            catch (Exception exception)
            {
                response = this.HandlerLog(Module.Maintenance, ActionCategory.Update, exception, notificationDTO);
            }

            _outputPort.Handle(response);
        }
    }
}