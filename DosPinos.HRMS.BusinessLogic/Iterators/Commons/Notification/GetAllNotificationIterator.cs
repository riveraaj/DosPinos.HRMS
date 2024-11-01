namespace DosPinos.HRMS.BusinessLogic.Iterators.Commons.Notification
{
    internal class GetAllNotificationIterator(INotificationRepository notificationRepository,
                                            ICreateLogIterator createLogIterator,
                                            IOutputPort outputPort) : BaseIterator(createLogIterator), IGetAllNotificationInputPort
    {
        private readonly INotificationRepository _notificationRepository = notificationRepository;
        private readonly IOutputPort _outputPort = outputPort;

        public void GetAll(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                //Get all notification where is not read
                List<INotificationDTO> notificationList = _notificationRepository.GetAll(entity.UserId).ToList();
                response.Content = notificationList;
            }
            catch (Exception exception)
            {
                response = this.HandlerLog(Module.Notification, ActionCategory.Create, exception, entity);
            }

            _outputPort.Handle(response);
        }
    }
}