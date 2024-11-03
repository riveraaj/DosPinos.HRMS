namespace DosPinos.HRMS.Controllers.Securities.Catalogs
{
    public class GetAllRoleController(IGetAllRoleInputPort inputPort,
                                        IOutputPort outputPort)
    {
        private readonly IGetAllRoleInputPort _inputPort = inputPort;
        private readonly IOutputPort _outputPort = outputPort;

        public async Task<IOperationResponseVO> GetAllAsync(IEntityDTO userId)
        {
            await _inputPort.GetAllAsync(userId);
            return _outputPort.OperationResponse;
        }
    }
}