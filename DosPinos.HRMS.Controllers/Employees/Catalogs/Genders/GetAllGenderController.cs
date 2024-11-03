namespace DosPinos.HRMS.Controllers.Employees.Catalogs.Genders
{
    public class GetAllGenderController(IGetAllGenderInputPort inputPort,
                                        IOutputPort outputPort)
    {
        private readonly IGetAllGenderInputPort _inputPort = inputPort;
        private readonly IOutputPort _outputPort = outputPort;

        public async Task<IOperationResponseVO> GetAllAsync(IEntityDTO userId)
        {
            await _inputPort.GetAllAsync(userId);
            return _outputPort.OperationResponse;
        }
    }
}