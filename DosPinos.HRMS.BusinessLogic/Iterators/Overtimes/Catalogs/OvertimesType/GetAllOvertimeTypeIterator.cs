namespace DosPinos.HRMS.BusinessLogic.Iterators.Overtimes.Catalogs.OvertimesType
{
    internal class GetAllOvertimeTypeIterator(IOvertimeTypeRepository overtimeTypeRepository,
                                   ICreateLogIterator createLogIterator,
                                   IOutputPort outputPort) : BaseIterator(createLogIterator), IGetAllOvertimeTypeInputPort
    {
        private readonly IOvertimeTypeRepository _overtimeTypeRepository = overtimeTypeRepository;
        private readonly IOutputPort _outputPort = outputPort;
        public async Task GetAllAsync(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                //Get all overtime types
                IEnumerable<IGetAllOvertimeTypeDTO> overtimeTypeList = await _overtimeTypeRepository.GetAllAsync();
                response.Content = overtimeTypeList;
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Maintenance, ActionCategory.Create, exception, entity);
            }

            _outputPort.Handle(response);
        }
    }
}