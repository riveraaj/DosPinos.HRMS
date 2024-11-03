namespace DosPinos.HRMS.Controllers.Employees.Catalogs.JobTitle
{
    public class GetAllJobTitleController(IGetAllJobTitleInputPort inputPort,
                                        IOutputPort outputPort)
    {
        private readonly IGetAllJobTitleInputPort _inputPort = inputPort;
        private readonly IOutputPort _outputPort = outputPort;

        public async Task<IOperationResponseVO> GetAllAsync(IEntityDTO userId)
        {
            await _inputPort.GetAllAsync(userId);
            return _outputPort.OperationResponse;
        }
    }
}