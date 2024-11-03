namespace DosPinos.HRMS.BusinessLogic.Iterators.Employees.Catalogs.SalaryCategories
{
    internal class GetAllSalaryCategoryIterator(ISalaryCategoryRepository salaryCategoryRepository,
                                                ICreateLogIterator createLogIterator,
                                                IOutputPort outputPort) : BaseIterator(createLogIterator), IGetAllSalaryCategoryInputPort
    {
        private readonly ISalaryCategoryRepository _salaryCategoryRepository = salaryCategoryRepository;
        private readonly IOutputPort _outputPort = outputPort;
        public async Task GetAllAsync(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                //Get all salaryCategorys
                IEnumerable<IGetAllSalaryCategoryDTO> salaryCategoryList = await _salaryCategoryRepository.GetAllAsync();
                response.Content = salaryCategoryList;
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Maintenance, ActionCategory.GetAll, exception, entity);
            }

            _outputPort.Handle(response);
        }
    }
}