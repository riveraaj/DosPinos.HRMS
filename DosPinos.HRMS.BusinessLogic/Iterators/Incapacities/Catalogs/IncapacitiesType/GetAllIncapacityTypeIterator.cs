namespace DosPinos.HRMS.BusinessLogic.Iterators.Incapacities.Catalogs.IncapacitiesType
{
    internal class GetAllIncapacityTypeIterator(IIncapacityTypeRepository incapacityTypeRepository,
                                   ICreateLogIterator createLogIterator,
                                   IOutputPort outputPort) : BaseIterator(createLogIterator), IGetAllIncapacityTypeInputPort
    {
        private readonly IIncapacityTypeRepository _incapacityTypeRepository = incapacityTypeRepository;
        private readonly IOutputPort _outputPort = outputPort;
        public async Task GetAllAsync(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                //Get all incapacity types
                IEnumerable<IGetAllIncapacityTypeDTO> incapacityTypeList = await _incapacityTypeRepository.GetAllAsync();
                response.Content = incapacityTypeList;
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Maintenance, ActionCategory.Create, exception, entity);
            }

            _outputPort.Handle(response);
        }
    }
}