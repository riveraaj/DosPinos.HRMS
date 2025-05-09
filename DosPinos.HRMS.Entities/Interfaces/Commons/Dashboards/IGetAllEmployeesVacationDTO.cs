namespace DosPinos.HRMS.Entities.Interfaces.Commons.Dashboards;

/// <summary>
/// Interface for dashboard and 
/// get all employees in vacation.
/// </summary>
public interface IGetAllEmployeesVacationDTO : IEntityDTO
{
    string FullName { get; }
    int Days { get; }
}