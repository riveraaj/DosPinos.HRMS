namespace DosPinos.HRMS.BusinessLogic.Iterators.Licenses.Catalogs.LicenseTypes
{
    internal class GetAllLicenseTypeIterator(ILicenseTypeRepository incapacityTypeRepository,
                                   ICreateLogIterator createLogIterator,
                                   IOutputPort outputPort) : BaseIterator(createLogIterator), IGetAllLicenseTypeInputPort
    {
        private readonly ILicenseTypeRepository _incapacityTypeRepository = incapacityTypeRepository;
        private readonly IOutputPort _outputPort = outputPort;
        public async Task GetAllAsync(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                //Get all license types
                IEnumerable<IGetAllLicenseTypeDTO> incapacityTypeList = await _incapacityTypeRepository.GetAllAsync();
                response.Content = incapacityTypeList;
            }
            catch (Exception exception)
            {
                response = await HandlerLog(Module.Maintenance, ActionCategory.Create, exception, entity);
            }

            _outputPort.Handle(response);
        }
    }
}