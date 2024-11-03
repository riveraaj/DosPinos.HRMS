namespace DosPinos.HRMS.Controllers.Employees.Catalogs.HiringsType
{
    public class GetAllHiringTypeController(IGetAllHiringTypeInputPort inputPort,
                                        IOutputPort outputPort)
    {
        private readonly IGetAllHiringTypeInputPort _inputPort = inputPort;
        private readonly IOutputPort _outputPort = outputPort;

        public async Task<IOperationResponseVO> GetAllAsync(IEntityDTO userId)
        {
            await _inputPort.GetAllAsync(userId);
            return _outputPort.OperationResponse;
        }
    }
}