namespace DosPinos.HRMS.Entities.DTOs.Employees.Catalogs;

/// <summary>
/// DTO for retrieving all districts.
/// </summary>
public class GetAllDistrictDTO(int id, string description,
                               int cantonId) : EntityDTO, IGetAllDistrictDTO
{
    public int Id => id;
    public string Description => description;
    public int CantonId => cantonId;
}