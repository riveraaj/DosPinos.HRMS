namespace DosPinos.HRMS.Controllers.Incapacities.Catalogs
{
    public class GetAllIncapacityTypeController(IGetAllIncapacityTypeInputPort inputPort,
                                        IOutputPort outputPort)
    {
        private readonly IGetAllIncapacityTypeInputPort _inputPort = inputPort;
        private readonly IOutputPort _outputPort = outputPort;

        public async Task<IOperationResponseVO> GetAllAsync(IEntityDTO userId)
        {
            await _inputPort.GetAllAsync(userId);
            return _outputPort.OperationResponse;
        }
    }
}