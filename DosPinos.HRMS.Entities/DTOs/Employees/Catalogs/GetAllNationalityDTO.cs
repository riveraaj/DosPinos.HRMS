namespace DosPinos.HRMS.Entities.DTOs.Employees.Catalogs;

/// <summary>
/// DTO for retrieving all nationalities.
/// </summary>
public class GetAllNationalityDTO(int id, string description) : EntityDTO, IGetAllNationalityDTO
{
    public int Id => id;
    public string Description => description;
}