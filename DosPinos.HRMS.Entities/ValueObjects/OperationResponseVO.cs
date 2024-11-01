using DosPinos.HRMS.Entities.Enums.Commons;

namespace DosPinos.HRMS.Entities.ValueObjects
{
    public record OperationResponseVO : IOperationResponseVO
    {
        public ResponseStatus Status { get; set; } = ResponseStatus.Success;

        public IEnumerable<string> Message { get; set; }

        public object Content { get; set; }
    }
}