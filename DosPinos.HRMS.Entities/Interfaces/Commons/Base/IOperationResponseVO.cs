namespace DosPinos.HRMS.Entities.Interfaces.Commons.Base;

/// <summary>
/// This interface represents a response object for operations.
/// </summary>
public interface IOperationResponseVO
{
    ResponseStatus Status { get; set; }
    string[] Message { get; set; }
    object Content { get; set; }
}