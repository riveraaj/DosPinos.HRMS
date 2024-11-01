namespace DosPinos.HRMS.Controllers.Employees.Catalogs.HiringsType
{
    public class GetAllHiringTypeController(IGetAllHiringTypeInputPort inputPort,
                                        IOutputPort outputPort)
    {
        private readonly IGetAllHiringTypeInputPort _inputPort = inputPort;
        private readonly IOutputPort _outputPort = outputPort;

        public IOperationResponseVO GetAll(IEntityDTO userId)
        {
            _inputPort.GetAll(userId);
            return _outputPort.OperationResponse;
        }
    }
}