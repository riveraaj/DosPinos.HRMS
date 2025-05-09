namespace DosPinos.HRMS.Entities.Interfaces.Deductions;

/// <summary>
/// Interface for creating a deduction.
/// </summary>
public interface ICreateDeductionDTO : IEntityDTO
{
    string Description { get; }
}