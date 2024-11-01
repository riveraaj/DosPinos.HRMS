namespace DosPinos.HRMS.Controllers.Employees.Catalogs.Provinces
{
    public class GetAllProvinceController(IGetAllProvinceInputPort inputPort,
                                        IOutputPort outputPort)
    {
        private readonly IGetAllProvinceInputPort _inputPort = inputPort;
        private readonly IOutputPort _outputPort = outputPort;

        public IOperationResponseVO GetAll(IEntityDTO userId)
        {
            _inputPort.GetAll(userId);
            return _outputPort.OperationResponse;
        }
    }
}