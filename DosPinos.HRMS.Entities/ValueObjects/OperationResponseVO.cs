using DosPinos.HRMS.Entities.Enums.Commons;
using DosPinos.HRMS.Entities.Resources.Commons;

namespace DosPinos.HRMS.Entities.ValueObjects
{
    public record OperationResponseVO : IOperationResponseVO
    {
        public OperationResponseVO()
        {
            Status = ResponseStatus.Success;
            Message = [Commons.SuccessMessage];
        }

        public ResponseStatus Status { get; set; }

        public IEnumerable<string> Message { get; set; }

        public object Content { get; set; }
    }
}