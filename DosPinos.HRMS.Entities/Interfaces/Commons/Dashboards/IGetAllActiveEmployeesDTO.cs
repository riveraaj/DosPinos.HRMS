namespace DosPinos.HRMS.Entities.Interfaces.Commons.Dashboards;

/// <summary>
/// Interface for dashboard to get all active employees.
/// </summary>
public interface IGetAllActiveEmployeesDTO : IEntityDTO
{
    int Total { get; }
}