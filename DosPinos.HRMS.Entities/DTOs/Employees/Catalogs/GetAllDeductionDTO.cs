namespace DosPinos.HRMS.Entities.DTOs.Employees.Catalogs;

/// <summary>
/// DTO for retrieving all deductions.
/// </summary>
public class GetAllDeductionDTO(int id, string description,
                                decimal percentage) : EntityDTO, IGetAllDeductionDTO
{
    public int Id => id;
    public string Description => description;
    public decimal Percentage => percentage;
}