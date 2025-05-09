namespace DosPinos.HRMS.Entities.DTOs.Commons.Dashboards;

/// <summary>
/// DTO for dashboard and 
/// get all employees in vacation
/// </summary>
public class GetAllEmployeesVacationDTO(string fullName,
                                        int days) : EntityDTO, IGetAllEmployeesVacationDTO
{
    public string FullName => fullName;
    public int Days => days;
}