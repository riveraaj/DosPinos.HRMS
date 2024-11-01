namespace DosPinos.HRMS.BusinessLogic.Iterators.Employees.Catalogs.Deductions
{
    internal class GetAllDeductionIterator(IDeductionRepository deductionRepository,
                                           ICreateLogIterator createLogIterator,
                                           IOutputPort outputPort) : BaseIterator(createLogIterator), IGetAllDeductionInputPort
    {
        private readonly IDeductionRepository _deductionRepository = deductionRepository;
        private readonly IOutputPort _outputPort = outputPort;
        public void GetAll(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                //Get all deductions
                List<IGetAllDeductionDTO> deductionList = _deductionRepository.GetAll().ToList();
                response.Content = deductionList;
            }
            catch (Exception exception)
            {
                response = this.HandlerLog(Module.Notification, ActionCategory.Create, exception, entity);
            }

            _outputPort.Handle(response);
        }
    }
}