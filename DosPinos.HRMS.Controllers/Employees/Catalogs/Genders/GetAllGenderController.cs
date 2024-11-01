namespace DosPinos.HRMS.Controllers.Employees.Catalogs.Genders
{
    public class GetAllGenderController(IGetAllGenderInputPort inputPort,
                                        IOutputPort outputPort)
    {
        private readonly IGetAllGenderInputPort _inputPort = inputPort;
        private readonly IOutputPort _outputPort = outputPort;

        public IOperationResponseVO GetAll(IEntityDTO userId)
        {
            _inputPort.GetAll(userId);
            return _outputPort.OperationResponse;
        }
    }
}