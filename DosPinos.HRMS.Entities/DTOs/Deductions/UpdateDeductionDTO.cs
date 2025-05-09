namespace DosPinos.HRMS.Entities.DTOs.Deductions;

/// <summary>
/// DTO for updating a deduction.
/// </summary>
public class UpdateDeductionDTO(byte id, decimal percentage) : EntityDTO, IUpdateDeductionDTO
{
    public byte Id => id;
    public decimal Percentage => percentage;
}