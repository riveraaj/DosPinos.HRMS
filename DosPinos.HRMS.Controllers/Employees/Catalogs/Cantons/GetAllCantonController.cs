namespace DosPinos.HRMS.Controllers.Employees.Catalogs.Cantons
{
    public class GetAllCantonController(IGetAllCantonInputPort inputPort,
                                        IOutputPort outputPort)
    {
        private readonly IGetAllCantonInputPort _inputPort = inputPort;
        private readonly IOutputPort _outputPort = outputPort;

        public IOperationResponseVO GetAll(IEntityDTO userId)
        {
            _inputPort.GetAll(userId);
            return _outputPort.OperationResponse;
        }
    }
}