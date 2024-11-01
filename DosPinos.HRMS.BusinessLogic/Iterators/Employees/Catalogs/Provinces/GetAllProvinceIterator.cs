namespace DosPinos.HRMS.BusinessLogic.Iterators.Employees.Catalogs.Provinces
{
    internal class GetAllProvinceIterator(IProvinceRepository provinceRepository,
                                          ICreateLogIterator createLogIterator,
                                          IOutputPort outputPort) : BaseIterator(createLogIterator), IGetAllProvinceInputPort
    {
        private readonly IProvinceRepository _provinceRepository = provinceRepository;
        private readonly IOutputPort _outputPort = outputPort;
        public void GetAll(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                //Get all provinces
                List<IGetAllProvinceDTO> provinceList = _provinceRepository.GetAll().ToList();
                response.Content = provinceList;
            }
            catch (Exception exception)
            {
                response = this.HandlerLog(Module.Notification, ActionCategory.Create, exception, entity);
            }

            _outputPort.Handle(response);
        }
    }
}