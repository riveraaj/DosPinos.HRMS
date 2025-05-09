namespace DosPinos.HRMS.Entities.DTOs.Commons.Dashboards;

/// <summary>
/// DTO for dashboard to get all employees with excess overtime.
/// </summary>
public class GetAllEmployeesExcessOvertimeDTO(string fullName,
                                              decimal overtime) : EntityDTO, IGetAllEmployeesExcessOvertimeDTO
{
    public string FullName => fullName;
    public decimal Overtime => overtime;
}