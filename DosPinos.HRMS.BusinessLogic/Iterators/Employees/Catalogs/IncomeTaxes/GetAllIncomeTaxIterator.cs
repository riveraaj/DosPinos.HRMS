namespace DosPinos.HRMS.BusinessLogic.Iterators.Employees.Catalogs.IncomeTaxes
{
    internal class GetAllIncomeTaxIterator(IIncomeTaxRepository incomeTaxRepository,
                                           ICreateLogIterator createLogIterator,
                                           IOutputPort outputPort) : BaseIterator(createLogIterator), IGetAllIncomeTaxInputPort
    {
        private readonly IIncomeTaxRepository _incomeTaxRepository = incomeTaxRepository;
        private readonly IOutputPort _outputPort = outputPort;
        public async Task GetAllAsync(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                //Get all incomeTaxs
                IEnumerable<IGetAllIncomeTaxDTO> incomeTaxList = await _incomeTaxRepository.GetAllAsync();
                response.Content = incomeTaxList;
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Maintenance, ActionCategory.GetAll, exception, entity);
            }

            _outputPort.Handle(response);
        }
    }
}