namespace DosPinos.HRMS.Entities.DTOs.Employees.Catalogs;

/// <summary>
/// DTO for getting all job titles.
/// </summary>
public class GetAllJobTitleDTO(int id, string description) : EntityDTO, IGetAllJobTitleDTO
{
    public int Id => id;
    public string Description => description;
}