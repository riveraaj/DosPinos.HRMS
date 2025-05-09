namespace DosPinos.HRMS.Entities.DTOs.Employees.Catalogs;

/// <summary>
/// DTO for retrieving all cantons.
/// </summary>
public class GetAllCantonDTO(int id, string description,
                             int provinceId) : EntityDTO, IGetAllCantonDTO
{
    public int Id => id;
    public string Description => description;
    public int ProvinceId => provinceId;
}