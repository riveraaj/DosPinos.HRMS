namespace DosPinos.HRMS.Controllers.Employees.Catalogs.PhonesType
{
    public class GetAllPhoneTypeController(IGetAllPhoneTypeInputPort inputPort,
                                        IOutputPort outputPort)
    {
        private readonly IGetAllPhoneTypeInputPort _inputPort = inputPort;
        private readonly IOutputPort _outputPort = outputPort;

        public async Task<IOperationResponseVO> GetAllAsync(IEntityDTO userId)
        {
            await _inputPort.GetAllAsync(userId);
            return _outputPort.OperationResponse;
        }
    }
}