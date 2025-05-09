namespace DosPinos.HRMS.Entities.Interfaces.Commons.FreeTimes;

/// <summary>
/// Interface for evaluate applications 
/// like: vacation, licenses & permissions.
/// </summary>
public interface IEvaluateApplicationDTO : IEntityDTO
{
    int Id { get; }
    int EmployeeId { get; }
    bool IsApproved { get; }
    ApplicationCode Code { get; }
}