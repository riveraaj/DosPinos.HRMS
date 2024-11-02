namespace DosPinos.HRMS.BusinessLogic.Iterators.WorkingDays.Catalogs.Holidays
{
    internal class GetAllHolidayIterator(IHolidayRepository holidayRepository,
                                       ICreateLogIterator createLogIterator,
                                       IOutputPort outputPort) : BaseIterator(createLogIterator), IGetAllHolidayInputPort
    {
        private readonly IHolidayRepository _holidayRepository = holidayRepository;
        private readonly IOutputPort _outputPort = outputPort;
        public void GetAll(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                //Get all holidays
                List<IGetAllHolidayDTO> holidayList = _holidayRepository.GetAll().ToList();
                response.Content = holidayList;
            }
            catch (Exception exception)
            {
                response = this.HandlerLog(Module.Maintenance, ActionCategory.Create, exception, entity);
            }

            _outputPort.Handle(response);
        }
    }
}