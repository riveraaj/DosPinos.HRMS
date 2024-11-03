namespace DosPinos.HRMS.Controllers.WorkingDays.Catalogs
{
    public class GetAllHolidayController(IGetAllHolidayInputPort inputPort,
                                        IOutputPort outputPort)
    {
        private readonly IGetAllHolidayInputPort _inputPort = inputPort;
        private readonly IOutputPort _outputPort = outputPort;

        public async Task<IOperationResponseVO> GetAllAsync(IEntityDTO userId)
        {
            await _inputPort.GetAllAsync(userId);
            return _outputPort.OperationResponse;
        }
    }
}