namespace DosPinos.HRMS.BusinessLogic.Iterators.Commons.Log
{
    internal class CreateLogIterator(ILogRepository logRepository) : ICreateLogIterator
    {
        private readonly ILogRepository _logRepository = logRepository;

        public async Task CreateAsync(ILogPOCO log) => await _logRepository.CreateAsync(log);
    }
}