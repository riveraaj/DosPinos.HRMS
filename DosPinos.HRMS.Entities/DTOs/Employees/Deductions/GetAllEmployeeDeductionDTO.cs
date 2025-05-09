namespace DosPinos.HRMS.Entities.DTOs.Employees.Deductions;

/// <summary>
/// DTO for retrieving all employee deductions.
/// </summary>
public class GetAllEmployeeDeductionDTO(int id,
                                         decimal percentage,
                                         string description) : EntityDTO, IGetAllEmployeeDeductionDTO
{
    public int Id => id;
    public decimal Percentage => percentage;
    public string Description => description;
}