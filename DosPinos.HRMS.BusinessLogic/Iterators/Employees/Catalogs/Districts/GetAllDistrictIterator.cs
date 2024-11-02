namespace DosPinos.HRMS.BusinessLogic.Iterators.Employees.Catalogs.Districts
{
    internal class GetAllDistrictIterator(IDistrictRepository districtRepository,
                                          ICreateLogIterator createLogIterator,
                                          IOutputPort outputPort) : BaseIterator(createLogIterator), IGetAllDistrictInputPort
    {
        private readonly IDistrictRepository _districtRepository = districtRepository;
        private readonly IOutputPort _outputPort = outputPort;
        public void GetAll(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                //Get all districts
                List<IGetAllDistrictDTO> districtList = _districtRepository.GetAll().ToList();
                response.Content = districtList;
            }
            catch (Exception exception)
            {
                response = this.HandlerLog(Module.Maintenance, ActionCategory.GetAll, exception, entity);
            }

            _outputPort.Handle(response);
        }
    }
}