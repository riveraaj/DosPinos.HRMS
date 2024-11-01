namespace DosPinos.HRMS.Controllers.Commons.Notification
{
    public class GetAllNotificationController(IGetAllNotificationInputPort inputPort,
                                              IOutputPort outputPort)
    {
        private readonly IGetAllNotificationInputPort _inputPort = inputPort;
        private readonly IOutputPort _outputPort = outputPort;

        public IOperationResponseVO GetAll(IEntityDTO userId)
        {
            _inputPort.GetAll(userId);
            return _outputPort.OperationResponse;
        }
    }
}