namespace DosPinos.HRMS.BusinessLogic.Iterators.Commons.Log
{
    internal class CreateLogIterator(ILogRepository logRepository) : ICreateLogIterator
    {
        private readonly ILogRepository _logRepository = logRepository;

        public void Create(ILogPOCO log) => _logRepository.Create(log);
    }
}