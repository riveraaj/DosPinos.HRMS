namespace DosPinos.HRMS.BusinessObjects.Interfaces.Commons.Log
{
    public interface ICreateLogIterator
    {
        Task CreateAsync(ILogPOCO log);
    }
}