namespace DosPinos.HRMS.Entities.DTOs.Commons.Dashboards;

/// <summary>
/// DTO for dashboard to get all employees' licenses.
/// </summary>
public class GetAllEmployeesLicenseDTO(int total) : EntityDTO, IGetAllEmployeesLicenseDTO
{
    public int Total => total;
}