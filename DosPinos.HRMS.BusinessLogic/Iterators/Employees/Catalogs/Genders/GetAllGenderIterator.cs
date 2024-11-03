namespace DosPinos.HRMS.BusinessLogic.Iterators.Employees.Catalogs.Genders
{
    internal class GetAllGenderIterator(IGenderRepository genderRepository,
                                        ICreateLogIterator createLogIterator,
                                        IOutputPort outputPort) : BaseIterator(createLogIterator), IGetAllGenderInputPort
    {
        private readonly IGenderRepository _genderRepository = genderRepository;
        private readonly IOutputPort _outputPort = outputPort;
        public async Task GetAllAsync(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                //Get all genders
                IEnumerable<IGetAllGenderDTO> genderList = await _genderRepository.GetAllAsync();
                response.Content = genderList;
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Maintenance, ActionCategory.GetAll, exception, entity);
            }

            _outputPort.Handle(response);
        }
    }
}