namespace DosPinos.HRMS.Controllers.WorkingDays.Catalogs
{
    public class GetAllHolidayController(IGetAllHolidayInputPort inputPort,
                                        IOutputPort outputPort)
    {
        private readonly IGetAllHolidayInputPort _inputPort = inputPort;
        private readonly IOutputPort _outputPort = outputPort;

        public IOperationResponseVO GetAll(IEntityDTO userId)
        {
            _inputPort.GetAll(userId);
            return _outputPort.OperationResponse;
        }
    }
}