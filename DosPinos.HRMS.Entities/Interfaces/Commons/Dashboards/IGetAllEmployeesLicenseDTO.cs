namespace DosPinos.HRMS.Entities.Interfaces.Commons.Dashboards;

/// <summary>
/// Interface for dashboard to get all employees' licenses.
/// </summary>
public interface IGetAllEmployeesLicenseDTO : IEntityDTO
{
    int Total { get; }
}