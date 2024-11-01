namespace DosPinos.HRMS.BusinessLogic.Iterators.Employees.Catalogs.IncomeTaxes
{
    internal class GetAllIncomeTaxIterator(IIncomeTaxRepository incomeTaxRepository,
                                           ICreateLogIterator createLogIterator,
                                           IOutputPort outputPort) : BaseIterator(createLogIterator), IGetAllIncomeTaxInputPort
    {
        private readonly IIncomeTaxRepository _incomeTaxRepository = incomeTaxRepository;
        private readonly IOutputPort _outputPort = outputPort;
        public void GetAll(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                //Get all incomeTaxs
                List<IGetAllIncomeTaxDTO> incomeTaxList = _incomeTaxRepository.GetAll().ToList();
                response.Content = incomeTaxList;
            }
            catch (Exception exception)
            {
                response = this.HandlerLog(Module.Notification, ActionCategory.Create, exception, entity);
            }

            _outputPort.Handle(response);
        }
    }
}