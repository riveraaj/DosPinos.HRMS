namespace DosPinos.HRMS.Entities.DTOs.Employees.Catalogs;

/// <summary>
/// DTO for getting all hiring types.
/// </summary>
public class GetAllHiringTypeDTO(int id, string description) : EntityDTO, IGetAllHiringTypeDTO
{
    public int Id => id;
    public string Description => description;
}