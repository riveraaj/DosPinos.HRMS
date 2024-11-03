namespace DosPinos.HRMS.BusinessObjects.Interfaces.Commons.Log
{
    public interface ILogRepository
    {
        Task<bool> CreateAsync(ILogPOCO log);
    }
}