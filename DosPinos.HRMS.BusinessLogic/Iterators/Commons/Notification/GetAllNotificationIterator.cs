namespace DosPinos.HRMS.BusinessLogic.Iterators.Commons.Notification
{
    internal class GetAllNotificationIterator(INotificationRepository notificationRepository,
                                              ICreateLogIterator createLogIterator,
                                              IOutputPort outputPort) : BaseIterator(createLogIterator), IGetAllNotificationInputPort
    {
        private readonly INotificationRepository _notificationRepository = notificationRepository;
        private readonly IOutputPort _outputPort = outputPort;

        public async Task GetAllAsync(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                //Get all notification where is not read
                IEnumerable<IGetAllNotificationDTO> notificationList = await _notificationRepository.GetAllAsync(entity.UserId);
                response.Content = notificationList;
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Maintenance, ActionCategory.GetAll, exception, entity);
            }

            _outputPort.Handle(response);
        }
    }
}