namespace DosPinos.HRMS.Entities.DTOs.Employees.Catalogs;

/// <summary>
/// DTO for retrieving all income tax.
/// </summary>
public class GetAllIncomeTaxDTO(int id, decimal percentage) : EntityDTO, IGetAllIncomeTaxDTO
{
    public int Id => id;
    public decimal Percentage => percentage;
}