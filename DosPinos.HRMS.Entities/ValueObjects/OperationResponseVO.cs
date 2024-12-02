using DosPinos.HRMS.Entities.Enums.Commons;
using DosPinos.HRMS.Entities.Resources.Commons;

namespace DosPinos.HRMS.Entities.ValueObjects
{
    public record OperationResponseVO : IOperationResponseVO
    {
        private ResponseStatus _status;

        public OperationResponseVO()
        {
            Status = ResponseStatus.Success;
        }

        public ResponseStatus Status
        {
            get => _status;
            set
            {
                _status = value;
                Message = (_status == ResponseStatus.Success) ? [Commons.SuccessMessage] : [];
            }
        }

        public IEnumerable<string> Message { get; set; }
        public object Content { get; set; }
    }
}