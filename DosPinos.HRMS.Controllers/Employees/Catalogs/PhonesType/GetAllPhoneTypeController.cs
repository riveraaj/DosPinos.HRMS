namespace DosPinos.HRMS.Controllers.Employees.Catalogs.PhonesType
{
    public class GetAllPhoneTypeController(IGetAllPhoneTypeInputPort inputPort,
                                        IOutputPort outputPort)
    {
        private readonly IGetAllPhoneTypeInputPort _inputPort = inputPort;
        private readonly IOutputPort _outputPort = outputPort;

        public IOperationResponseVO GetAll(IEntityDTO userId)
        {
            _inputPort.GetAll(userId);
            return _outputPort.OperationResponse;
        }
    }
}