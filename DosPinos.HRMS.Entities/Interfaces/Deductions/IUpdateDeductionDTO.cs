namespace DosPinos.HRMS.Entities.Interfaces.Deductions;

/// <summary>
/// Interface for updating a deduction.
/// </summary>
public interface IUpdateDeductionDTO : IEntityDTO
{
    byte Id { get; }
    decimal Percentage { get; }
}