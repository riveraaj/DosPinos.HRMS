namespace DosPinos.HRMS.Controllers.Employees.Catalogs.SalaryCategories
{
    public class GetAllSalaryCategoryController(IGetAllSalaryCategoryInputPort inputPort,
                                        IOutputPort outputPort)
    {
        private readonly IGetAllSalaryCategoryInputPort _inputPort = inputPort;
        private readonly IOutputPort _outputPort = outputPort;

        public async Task<IOperationResponseVO> GetAllAsync(IEntityDTO userId)
        {
            await _inputPort.GetAllAsync(userId);
            return _outputPort.OperationResponse;
        }
    }
}