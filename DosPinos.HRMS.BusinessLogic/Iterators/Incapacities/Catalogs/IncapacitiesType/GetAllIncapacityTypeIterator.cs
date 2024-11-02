namespace DosPinos.HRMS.BusinessLogic.Iterators.Incapacities.Catalogs.IncapacitiesType
{
    internal class GetAllIncapacityTypeIterator(IIncapacityTypeRepository incapacityTypeRepository,
                                   ICreateLogIterator createLogIterator,
                                   IOutputPort outputPort) : BaseIterator(createLogIterator), IGetAllIncapacityTypeInputPort
    {
        private readonly IIncapacityTypeRepository _incapacityTypeRepository = incapacityTypeRepository;
        private readonly IOutputPort _outputPort = outputPort;
        public void GetAll(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                //Get all incapacity types
                List<IGetAllIncapacityTypeDTO> incapacityTypeList = _incapacityTypeRepository.GetAll().ToList();
                response.Content = incapacityTypeList;
            }
            catch (Exception exception)
            {
                response = this.HandlerLog(Module.Maintenance, ActionCategory.Create, exception, entity);
            }

            _outputPort.Handle(response);
        }
    }
}