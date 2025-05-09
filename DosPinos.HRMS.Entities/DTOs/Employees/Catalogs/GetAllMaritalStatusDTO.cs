namespace DosPinos.HRMS.Entities.DTOs.Employees.Catalogs;

/// <summary>
/// DTO for retrieving all marital status.
/// </summary>
public class GetAllMaritalStatusDTO(int id,
                                    string description) : EntityDTO, IGetAllMaritalStatusDTO
{
    public int Id => id;
    public string Description => description;
}