namespace DosPinos.HRMS.BusinessLogic.Iterators.Employees.Catalogs.MaritalStatus
{
    internal class GetAllMaritalStatusIterator(IMaritalStatusRepository maritalStatusRepository,
                                               ICreateLogIterator createLogIterator,
                                               IOutputPort outputPort) : BaseIterator(createLogIterator), IGetAllMaritalStatusInputPort
    {
        private readonly IMaritalStatusRepository _maritalStatusRepository = maritalStatusRepository;
        private readonly IOutputPort _outputPort = outputPort;
        public void GetAll(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                //Get all maritalStatuss
                List<IGetAllMaritalStatusDTO> maritalStatusList = _maritalStatusRepository.GetAll().ToList();
                response.Content = maritalStatusList;
            }
            catch (Exception exception)
            {
                response = this.HandlerLog(Module.Notification, ActionCategory.Create, exception, entity);
            }

            _outputPort.Handle(response);
        }
    }
}