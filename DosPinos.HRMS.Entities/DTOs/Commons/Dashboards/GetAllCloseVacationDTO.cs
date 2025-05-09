namespace DosPinos.HRMS.Entities.DTOs.Commons.Dashboards;

/// <summary>
/// DTO for dashboard to get all person's close vacation.
/// </summary>
public class GetAllCloseVacationDTO(string fullName,
                                    int days) : EntityDTO, IGetAllCloseVacationDTO
{
    public string FullName => fullName;
    public int Days => days;
}