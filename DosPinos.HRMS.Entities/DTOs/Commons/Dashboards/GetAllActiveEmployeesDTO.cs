namespace DosPinos.HRMS.Entities.DTOs.Commons.Dashboards;

/// <summary>
/// DTO for dashboard to get all active employees.
/// </summary>
public class GetAllActiveEmployeesDTO(int total) : EntityDTO, IGetAllActiveEmployeesDTO
{
    public int Total => total;
}