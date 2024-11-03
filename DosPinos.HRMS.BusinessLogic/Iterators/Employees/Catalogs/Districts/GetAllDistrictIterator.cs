namespace DosPinos.HRMS.BusinessLogic.Iterators.Employees.Catalogs.Districts
{
    internal class GetAllDistrictIterator(IDistrictRepository districtRepository,
                                          ICreateLogIterator createLogIterator,
                                          IOutputPort outputPort) : BaseIterator(createLogIterator), IGetAllDistrictInputPort
    {
        private readonly IDistrictRepository _districtRepository = districtRepository;
        private readonly IOutputPort _outputPort = outputPort;
        public async Task GetAllAsync(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                //Get all districts
                IEnumerable<IGetAllDistrictDTO> districtList = await _districtRepository.GetAllAsync();
                response.Content = districtList;
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Maintenance, ActionCategory.GetAll, exception, entity);
            }

            _outputPort.Handle(response);
        }
    }
}