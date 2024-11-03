namespace DosPinos.HRMS.Controllers.Employees.Catalogs.Provinces
{
    public class GetAllProvinceController(IGetAllProvinceInputPort inputPort,
                                        IOutputPort outputPort)
    {
        private readonly IGetAllProvinceInputPort _inputPort = inputPort;
        private readonly IOutputPort _outputPort = outputPort;

        public async Task<IOperationResponseVO> GetAllAsync(IEntityDTO userId)
        {
            await _inputPort.GetAllAsync(userId);
            return _outputPort.OperationResponse;
        }
    }
}