namespace DosPinos.HRMS.Entities.Interfaces.Commons.Dashboards;

/// <summary>
/// Interface for dashboard to get all person's close vacation.
/// </summary>
public interface IGetAllCloseVacationDTO : IEntityDTO
{
    string FullName { get; }
    int Days { get; }
}