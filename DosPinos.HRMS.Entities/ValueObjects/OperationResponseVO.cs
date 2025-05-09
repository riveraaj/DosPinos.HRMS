namespace DosPinos.HRMS.Entities.ValueObjects;

/// <summary>
/// This record struct represents a response object for operations.
/// </summary>
public record struct OperationResponseVO(ResponseStatus Status,
                                         string[] Message,
                                         object Content) : IOperationResponseVO
{
    public OperationResponseVO() : this(ResponseStatus.Success, [Commons.SuccessMessage], null) { }
}