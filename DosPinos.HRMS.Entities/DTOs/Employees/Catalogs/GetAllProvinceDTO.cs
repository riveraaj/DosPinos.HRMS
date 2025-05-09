namespace DosPinos.HRMS.Entities.DTOs.Employees.Catalogs;

/// <summary>
/// DTO for retrieving all provinces.
/// </summary>
public class GetAllProvinceDTO(int id, string description) : EntityDTO, IGetAllProvinceDTO
{
    public int Id => id;
    public string Description => description;
}