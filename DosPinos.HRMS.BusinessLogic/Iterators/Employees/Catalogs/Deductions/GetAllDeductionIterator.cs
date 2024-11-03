namespace DosPinos.HRMS.BusinessLogic.Iterators.Employees.Catalogs.Deductions
{
    internal class GetAllDeductionIterator(IDeductionRepository deductionRepository,
                                           ICreateLogIterator createLogIterator,
                                           IOutputPort outputPort) : BaseIterator(createLogIterator), IGetAllDeductionInputPort
    {
        private readonly IDeductionRepository _deductionRepository = deductionRepository;
        private readonly IOutputPort _outputPort = outputPort;
        public async Task GetAllAsync(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                //Get all deductions
                IEnumerable<IGetAllDeductionDTO> deductionList = await _deductionRepository.GetAllAsync();
                response.Content = deductionList;
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Maintenance, ActionCategory.GetAll, exception, entity);
            }

            _outputPort.Handle(response);
        }
    }
}