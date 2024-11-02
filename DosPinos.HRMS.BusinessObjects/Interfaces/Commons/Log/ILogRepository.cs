namespace DosPinos.HRMS.BusinessObjects.Interfaces.Commons.Log
{
    public interface ILogRepository
    {
        bool Create(ILogPOCO log);
    }
}