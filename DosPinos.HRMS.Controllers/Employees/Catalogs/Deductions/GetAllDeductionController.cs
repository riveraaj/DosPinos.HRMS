namespace DosPinos.HRMS.Controllers.Employees.Catalogs.Deductions
{
    public class GetAllDeductionController(IGetAllDeductionInputPort inputPort,
                                        IOutputPort outputPort)
    {
        private readonly IGetAllDeductionInputPort _inputPort = inputPort;
        private readonly IOutputPort _outputPort = outputPort;

        public IOperationResponseVO GetAll(IEntityDTO userId)
        {
            _inputPort.GetAll(userId);
            return _outputPort.OperationResponse;
        }
    }
}