namespace DosPinos.HRMS.BusinessObjects.Interfaces.Commons.Log
{
    public interface ILogPOCO : IEntityDTO
    {
        DateTime TimeStamp { get; }
        string Source { get; set; }
        string Message { get; set; }
        string Exeption { get; set; }
        ActionCategory Action { get; set; }
        Module Module { get; set; }
    }
}