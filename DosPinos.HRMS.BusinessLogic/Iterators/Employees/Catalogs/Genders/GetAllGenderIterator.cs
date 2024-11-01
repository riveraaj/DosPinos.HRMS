namespace DosPinos.HRMS.BusinessLogic.Iterators.Employees.Catalogs.Genders
{
    internal class GetAllGenderIterator(IGenderRepository genderRepository,
                                        ICreateLogIterator createLogIterator,
                                        IOutputPort outputPort) : BaseIterator(createLogIterator), IGetAllGenderInputPort
    {
        private readonly IGenderRepository _genderRepository = genderRepository;
        private readonly IOutputPort _outputPort = outputPort;
        public void GetAll(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                //Get all genders
                List<IGetAllGenderDTO> genderList = _genderRepository.GetAll().ToList();
                response.Content = genderList;
            }
            catch (Exception exception)
            {
                response = this.HandlerLog(Module.Notification, ActionCategory.Create, exception, entity);
            }

            _outputPort.Handle(response);
        }
    }
}