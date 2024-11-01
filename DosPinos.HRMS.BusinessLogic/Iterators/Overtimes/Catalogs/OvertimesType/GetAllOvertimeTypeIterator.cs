namespace DosPinos.HRMS.BusinessLogic.Iterators.Overtimes.Catalogs.OvertimesType
{
    internal class GetAllOvertimeTypeIterator(IOvertimeTypeRepository overtimeTypeRepository,
                                   ICreateLogIterator createLogIterator,
                                   IOutputPort outputPort) : BaseIterator(createLogIterator), IGetAllOvertimeTypeInputPort
    {
        private readonly IOvertimeTypeRepository _overtimeTypeRepository = overtimeTypeRepository;
        private readonly IOutputPort _outputPort = outputPort;
        public void GetAll(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                //Get all overtime types
                List<IGetAllOvertimeTypeDTO> overtimeTypeList = _overtimeTypeRepository.GetAll().ToList();
                response.Content = overtimeTypeList;
            }
            catch (Exception exception)
            {
                response = this.HandlerLog(Module.Notification, ActionCategory.Create, exception, entity);
            }

            _outputPort.Handle(response);
        }
    }
}