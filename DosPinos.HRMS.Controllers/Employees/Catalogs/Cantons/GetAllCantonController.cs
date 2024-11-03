namespace DosPinos.HRMS.Controllers.Employees.Catalogs.Cantons
{
    public class GetAllCantonController(IGetAllCantonInputPort inputPort,
                                        IOutputPort outputPort)
    {
        private readonly IGetAllCantonInputPort _inputPort = inputPort;
        private readonly IOutputPort _outputPort = outputPort;

        public async Task<IOperationResponseVO> GetAllAsync(IEntityDTO userId)
        {
            await _inputPort.GetAllAsync(userId);
            return _outputPort.OperationResponse;
        }
    }
}