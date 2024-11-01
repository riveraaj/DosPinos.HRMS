namespace DosPinos.HRMS.Controllers.Overtimes.Catalogs
{
    public class GetAllOvertimeTypeController(IGetAllOvertimeTypeInputPort inputPort,
                                        IOutputPort outputPort)
    {
        private readonly IGetAllOvertimeTypeInputPort _inputPort = inputPort;
        private readonly IOutputPort _outputPort = outputPort;

        public IOperationResponseVO GetAll(IEntityDTO userId)
        {
            _inputPort.GetAll(userId);
            return _outputPort.OperationResponse;
        }
    }
}