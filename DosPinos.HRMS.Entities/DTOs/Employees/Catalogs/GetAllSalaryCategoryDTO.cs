namespace DosPinos.HRMS.Entities.DTOs.Employees.Catalogs;

/// <summary>
/// DTO for retrieving all salary categories.
/// </summary>
public class GetAllSalaryCategoryDTO(int id, string description,
                                     decimal range) : EntityDTO, IGetAllSalaryCategoryDTO
{
    public int Id => id;
    public string Description => description;
    public decimal Range => range;
}