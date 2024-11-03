namespace DosPinos.HRMS.Controllers.Employees.Catalogs.MaritalStatus
{
    public class GetAllMaritalStatusController(IGetAllMaritalStatusInputPort inputPort,
                                        IOutputPort outputPort)
    {
        private readonly IGetAllMaritalStatusInputPort _inputPort = inputPort;
        private readonly IOutputPort _outputPort = outputPort;

        public async Task<IOperationResponseVO> GetAllAsync(IEntityDTO userId)
        {
            await _inputPort.GetAllAsync(userId);
            return _outputPort.OperationResponse;
        }
    }
}