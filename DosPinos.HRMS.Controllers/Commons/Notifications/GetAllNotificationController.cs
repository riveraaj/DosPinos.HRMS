using DosPinos.HRMS.BusinessObjects.Interfaces.Commons.Notifications.InputPorts;

namespace DosPinos.HRMS.Controllers.Commons.Notifications
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