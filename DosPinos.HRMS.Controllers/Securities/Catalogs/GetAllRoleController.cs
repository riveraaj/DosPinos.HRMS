namespace DosPinos.HRMS.Controllers.Securities.Catalogs
{
    public class GetAllRoleController(IGetAllRoleInputPort inputPort,
                                        IOutputPort outputPort)
    {
        private readonly IGetAllRoleInputPort _inputPort = inputPort;
        private readonly IOutputPort _outputPort = outputPort;

        public IOperationResponseVO GetAll(IEntityDTO userId)
        {
            _inputPort.GetAll(userId);
            return _outputPort.OperationResponse;
        }
    }
}