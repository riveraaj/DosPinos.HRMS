namespace DosPinos.HRMS.Controllers.Employees.Catalogs.Deductions
{
    public class GetAllDeductionController(IGetAllDeductionInputPort inputPort,
                                        IOutputPort outputPort)
    {
        private readonly IGetAllDeductionInputPort _inputPort = inputPort;
        private readonly IOutputPort _outputPort = outputPort;

        public async Task<IOperationResponseVO> GetAllAsync(IEntityDTO userId)
        {
            await _inputPort.GetAllAsync(userId);
            return _outputPort.OperationResponse;
        }
    }
}