namespace DosPinos.HRMS.BusinessLogic.Iterators.Employees.Catalogs.Provinces
{
    internal class GetAllProvinceIterator(IProvinceRepository provinceRepository,
                                          ICreateLogIterator createLogIterator,
                                          IOutputPort outputPort) : BaseIterator(createLogIterator), IGetAllProvinceInputPort
    {
        private readonly IProvinceRepository _provinceRepository = provinceRepository;
        private readonly IOutputPort _outputPort = outputPort;
        public async Task GetAllAsync(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                //Get all provinces
                IEnumerable<IGetAllProvinceDTO> provinceList = await _provinceRepository.GetAllAsync();
                response.Content = provinceList;
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Maintenance, ActionCategory.GetAll, exception, entity);
            }

            _outputPort.Handle(response);
        }
    }
}