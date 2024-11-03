namespace DosPinos.HRMS.Controllers.Overtimes.Catalogs
{
    public class GetAllOvertimeTypeController(IGetAllOvertimeTypeInputPort inputPort,
                                        IOutputPort outputPort)
    {
        private readonly IGetAllOvertimeTypeInputPort _inputPort = inputPort;
        private readonly IOutputPort _outputPort = outputPort;

        public async Task<IOperationResponseVO> GetAllAsync(IEntityDTO userId)
        {
            await _inputPort.GetAllAsync(userId);
            return _outputPort.OperationResponse;
        }
    }
}