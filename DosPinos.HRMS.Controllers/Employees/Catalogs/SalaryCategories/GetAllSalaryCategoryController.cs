namespace DosPinos.HRMS.Controllers.Employees.Catalogs.SalaryCategories
{
    public class GetAllSalaryCategoryController(IGetAllSalaryCategoryInputPort inputPort,
                                        IOutputPort outputPort)
    {
        private readonly IGetAllSalaryCategoryInputPort _inputPort = inputPort;
        private readonly IOutputPort _outputPort = outputPort;

        public IOperationResponseVO GetAll(IEntityDTO userId)
        {
            _inputPort.GetAll(userId);
            return _outputPort.OperationResponse;
        }
    }
}