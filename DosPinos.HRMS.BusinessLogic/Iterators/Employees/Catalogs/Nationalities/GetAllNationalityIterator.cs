namespace DosPinos.HRMS.BusinessLogic.Iterators.Employees.Catalogs.Nationalities
{
    internal class GetAllNationalityIterator(INationalityRepository nationalityRepository,
                                             ICreateLogIterator createLogIterator,
                                             IOutputPort outputPort) : BaseIterator(createLogIterator), IGetAllNationalityInputPort
    {
        private readonly INationalityRepository _nationalityRepository = nationalityRepository;
        private readonly IOutputPort _outputPort = outputPort;
        public void GetAll(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                //Get all nationalitys
                List<IGetAllNationalityDTO> nationalityList = _nationalityRepository.GetAll().ToList();
                response.Content = nationalityList;
            }
            catch (Exception exception)
            {
                response = this.HandlerLog(Module.Maintenance, ActionCategory.Create, exception, entity);
            }

            _outputPort.Handle(response);
        }
    }
}