namespace DosPinos.HRMS.Entities.Interfaces.Commons.FreeTimes;

/// <summary>
/// Interface for get all pending application to resolve.
/// </summary>
public interface IGetAllPendingApplicationDTO : IEntityDTO
{
    int Id { get; }
    ApplicationCode Code { get; }
    string EmployeeName { get; }
    string JobTitle { get; }
    DateOnly StartDate { get; }
    DateOnly EndDate { get; }
    int Days { get; }
    string ApplicationType { get; }
    string DocumentPath { get; }
}