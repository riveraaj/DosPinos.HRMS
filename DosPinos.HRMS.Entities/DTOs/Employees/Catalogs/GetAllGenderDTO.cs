namespace DosPinos.HRMS.Entities.DTOs.Employees.Catalogs;

/// <summary>
/// DTO for retriving all genders.
/// </summary>
public class GetAllGenderDTO(int id, string description) : EntityDTO, IGetAllGenderDTO
{
    public int Id => id;
    public string Description => description;
}