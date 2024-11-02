namespace DosPinos.HRMS.BusinessLogic.Iterators.Employees.Catalogs.JobsTitle
{
    internal class GetAllJobTitleIterator(IJobTitleRepository jobTitleRepository,
                                          ICreateLogIterator createLogIterator,
                                          IOutputPort outputPort) : BaseIterator(createLogIterator), IGetAllJobTitleInputPort
    {
        private readonly IJobTitleRepository _jobTitleRepository = jobTitleRepository;
        private readonly IOutputPort _outputPort = outputPort;
        public void GetAll(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                //Get all jobTitles
                List<IGetAllJobTitleDTO> jobTitleList = _jobTitleRepository.GetAll().ToList();
                response.Content = jobTitleList;
            }
            catch (Exception exception)
            {
                response = this.HandlerLog(Module.Maintenance, ActionCategory.GetAll, exception, entity);
            }

            _outputPort.Handle(response);
        }
    }
}