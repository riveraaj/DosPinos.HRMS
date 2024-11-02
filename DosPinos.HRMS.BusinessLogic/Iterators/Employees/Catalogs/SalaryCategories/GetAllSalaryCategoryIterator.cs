namespace DosPinos.HRMS.BusinessLogic.Iterators.Employees.Catalogs.SalaryCategories
{
    internal class GetAllSalaryCategoryIterator(ISalaryCategoryRepository salaryCategoryRepository,
                                                ICreateLogIterator createLogIterator,
                                                IOutputPort outputPort) : BaseIterator(createLogIterator), IGetAllSalaryCategoryInputPort
    {
        private readonly ISalaryCategoryRepository _salaryCategoryRepository = salaryCategoryRepository;
        private readonly IOutputPort _outputPort = outputPort;
        public void GetAll(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                //Get all salaryCategorys
                List<IGetAllSalaryCategoryDTO> salaryCategoryList = _salaryCategoryRepository.GetAll().ToList();
                response.Content = salaryCategoryList;
            }
            catch (Exception exception)
            {
                response = this.HandlerLog(Module.Maintenance, ActionCategory.GetAll, exception, entity);
            }

            _outputPort.Handle(response);
        }
    }
}