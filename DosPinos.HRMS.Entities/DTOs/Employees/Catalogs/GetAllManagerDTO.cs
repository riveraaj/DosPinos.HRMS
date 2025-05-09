namespace DosPinos.HRMS.Entities.DTOs.Employees.Catalogs;

/// <summary>
/// DTO for retrieving all managers.
/// </summary>
public class GetAllManagerDTO(int id, string fullName) : EntityDTO, IGetAllManagerDTO
{
    public int Id => id;
    public string FullName => fullName;
}