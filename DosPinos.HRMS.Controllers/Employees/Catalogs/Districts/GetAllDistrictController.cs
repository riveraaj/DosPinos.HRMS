namespace DosPinos.HRMS.Controllers.Employees.Catalogs.Districts
{
    public class GetAllDistrictController(IGetAllDistrictInputPort inputPort,
                                        IOutputPort outputPort)
    {
        private readonly IGetAllDistrictInputPort _inputPort = inputPort;
        private readonly IOutputPort _outputPort = outputPort;

        public async Task<IOperationResponseVO> GetAll(IEntityDTO userId)
        {
            await _inputPort.GetAllAsync(userId);
            return _outputPort.OperationResponse;
        }
    }
}