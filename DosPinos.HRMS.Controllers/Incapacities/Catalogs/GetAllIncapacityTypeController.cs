namespace DosPinos.HRMS.Controllers.Incapacities.Catalogs
{
    public class GetAllIncapacityTypeController(IGetAllIncapacityTypeInputPort inputPort,
                                        IOutputPort outputPort)
    {
        private readonly IGetAllIncapacityTypeInputPort _inputPort = inputPort;
        private readonly IOutputPort _outputPort = outputPort;

        public IOperationResponseVO GetAll(IEntityDTO userId)
        {
            _inputPort.GetAll(userId);
            return _outputPort.OperationResponse;
        }
    }
}