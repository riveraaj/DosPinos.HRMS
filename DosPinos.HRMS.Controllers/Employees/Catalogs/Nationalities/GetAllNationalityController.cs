namespace DosPinos.HRMS.Controllers.Employees.Catalogs.Nationalities
{
    public class GetAllNationalityController(IGetAllNationalityInputPort inputPort,
                                        IOutputPort outputPort)
    {
        private readonly IGetAllNationalityInputPort _inputPort = inputPort;
        private readonly IOutputPort _outputPort = outputPort;

        public IOperationResponseVO GetAll(IEntityDTO userId)
        {
            _inputPort.GetAll(userId);
            return _outputPort.OperationResponse;
        }
    }
}