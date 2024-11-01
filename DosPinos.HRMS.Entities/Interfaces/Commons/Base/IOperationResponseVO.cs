using DosPinos.HRMS.Entities.Enums.Commons;

namespace DosPinos.HRMS.Entities.Interfaces.Commons.Base
{
    public interface IOperationResponseVO
    {
        ResponseStatus Status { get; set; }
        IEnumerable<string> Message { get; set; }
        object Content { get; set; }
    }
}