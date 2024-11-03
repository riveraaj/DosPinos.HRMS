namespace DosPinos.HRMS.Controllers.Employees.Catalogs.Nationalities
{
    public class GetAllNationalityController(IGetAllNationalityInputPort inputPort,
                                        IOutputPort outputPort)
    {
        private readonly IGetAllNationalityInputPort _inputPort = inputPort;
        private readonly IOutputPort _outputPort = outputPort;

        public async Task<IOperationResponseVO> GetAllAsync(IEntityDTO userId)
        {
            await _inputPort.GetAllAsync(userId);
            return _outputPort.OperationResponse;
        }
    }
}