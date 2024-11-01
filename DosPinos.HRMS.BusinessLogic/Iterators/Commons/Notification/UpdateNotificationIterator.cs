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
                var validationResult = notification.ValidateModel();
                if (!validationResult.IsValid) this.CustomWarning(validationResult.ErrorMessages);

                //Update notification
                var result = _notificationRepository.Update(notification);
                if (!result) response = this.CustomWarning(Resources.Commons.Commons.WarningMessage);
            }
            catch (Exception exception)
            {
                response = this.HandlerLog(Module.Notification, ActionCategory.Create, exception, notificationDTO);
            }

            _outputPort.Handle(response);
        }
    }
}