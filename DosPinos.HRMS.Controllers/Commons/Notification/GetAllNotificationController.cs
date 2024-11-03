namespace DosPinos.HRMS.Controllers.Commons.Notification
{
    public class GetAllNotificationController(IGetAllNotificationInputPort inputPort,
                                              IOutputPort outputPort)
    {
        private readonly IGetAllNotificationInputPort _inputPort = inputPort;
        private readonly IOutputPort _outputPort = outputPort;

        public async Task<IOperationResponseVO> GetAllAsync(IEntityDTO userId)
        {
            await _inputPort.GetAllAsync(userId);
            return _outputPort.OperationResponse;
        }
    }
}