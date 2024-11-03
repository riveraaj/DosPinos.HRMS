namespace DosPinos.HRMS.BusinessLogic.Iterators.Employees.Catalogs.MaritalStatus
{
    internal class GetAllMaritalStatusIterator(IMaritalStatusRepository maritalStatusRepository,
                                               ICreateLogIterator createLogIterator,
                                               IOutputPort outputPort) : BaseIterator(createLogIterator), IGetAllMaritalStatusInputPort
    {
        private readonly IMaritalStatusRepository _maritalStatusRepository = maritalStatusRepository;
        private readonly IOutputPort _outputPort = outputPort;
        public async Task GetAllAsync(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                //Get all maritalStatuss
                IEnumerable<IGetAllMaritalStatusDTO> maritalStatusList = await _maritalStatusRepository.GetAllAsync();
                response.Content = maritalStatusList;
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Maintenance, ActionCategory.GetAll, exception, entity);
            }

            _outputPort.Handle(response);
        }
    }
}