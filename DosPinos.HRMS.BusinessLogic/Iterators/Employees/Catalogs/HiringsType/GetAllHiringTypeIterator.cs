namespace DosPinos.HRMS.BusinessLogic.Iterators.Employees.Catalogs.HiringsType
{
    internal class GetAllHiringTypeIterator(IHiringTypeRepository hiringTypeRepository,
                                            ICreateLogIterator createLogIterator,
                                            IOutputPort outputPort) : BaseIterator(createLogIterator), IGetAllHiringTypeInputPort
    {
        private readonly IHiringTypeRepository _hiringTypeRepository = hiringTypeRepository;
        private readonly IOutputPort _outputPort = outputPort;
        public async Task GetAllAsync(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                //Get all hiringTypes
                IEnumerable<IGetAllHiringTypeDTO> hiringTypeList = await _hiringTypeRepository.GetAllAsync();
                response.Content = hiringTypeList;
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Maintenance, ActionCategory.GetAll, exception, entity);
            }

            _outputPort.Handle(response);
        }
    }
}