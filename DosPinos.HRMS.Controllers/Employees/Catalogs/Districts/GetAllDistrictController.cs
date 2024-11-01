namespace DosPinos.HRMS.Controllers.Employees.Catalogs.Districts
{
    public class GetAllDistrictController(IGetAllDistrictInputPort inputPort,
                                        IOutputPort outputPort)
    {
        private readonly IGetAllDistrictInputPort _inputPort = inputPort;
        private readonly IOutputPort _outputPort = outputPort;

        public IOperationResponseVO GetAll(IEntityDTO userId)
        {
            _inputPort.GetAll(userId);
            return _outputPort.OperationResponse;
        }
    }
}