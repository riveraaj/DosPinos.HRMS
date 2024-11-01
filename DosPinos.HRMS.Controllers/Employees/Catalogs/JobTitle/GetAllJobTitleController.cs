namespace DosPinos.HRMS.Controllers.Employees.Catalogs.JobTitle
{
    public class GetAllJobTitleController(IGetAllJobTitleInputPort inputPort,
                                        IOutputPort outputPort)
    {
        private readonly IGetAllJobTitleInputPort _inputPort = inputPort;
        private readonly IOutputPort _outputPort = outputPort;

        public IOperationResponseVO GetAll(IEntityDTO userId)
        {
            _inputPort.GetAll(userId);
            return _outputPort.OperationResponse;
        }
    }
}