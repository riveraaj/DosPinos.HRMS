namespace DosPinos.HRMS.BusinessLogic.Iterators.Employees.Catalogs.PhonesType
{
    internal class GetAllPhoneTypeIterator(IPhoneTypeRepository phoneTypeRepository,
                                           ICreateLogIterator createLogIterator,
                                           IOutputPort outputPort) : BaseIterator(createLogIterator), IGetAllPhoneTypeInputPort
    {
        private readonly IPhoneTypeRepository _phoneTypeRepository = phoneTypeRepository;
        private readonly IOutputPort _outputPort = outputPort;
        public void GetAll(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                //Get all phoneTypes
                List<IGetAllPhoneTypeDTO> phoneTypeList = _phoneTypeRepository.GetAll().ToList();
                response.Content = phoneTypeList;
            }
            catch (Exception exception)
            {
                response = this.HandlerLog(Module.Maintenance, ActionCategory.GetAll, exception, entity);
            }

            _outputPort.Handle(response);
        }
    }
}