namespace DosPinos.HRMS.Entities.Interfaces.Commons.Dashboards;

/// <summary>
/// Interface for dashboard to get all employees with excess overtime.
/// </summary>
public interface IGetAllEmployeesExcessOvertimeDTO : IEntityDTO
{
    string FullName { get; }
    decimal Overtime { get; }
}