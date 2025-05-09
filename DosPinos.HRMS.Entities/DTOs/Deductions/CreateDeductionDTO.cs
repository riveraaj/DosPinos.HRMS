namespace DosPinos.HRMS.Entities.DTOs.Deductions;

/// <summary>
/// DTO for creating a deduction.
/// </summary>
public class CreateDeductionDTO(string description) : EntityDTO, ICreateDeductionDTO
{
    public string Description => description;
}