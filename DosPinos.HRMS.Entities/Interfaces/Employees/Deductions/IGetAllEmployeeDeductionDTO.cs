namespace DosPinos.HRMS.Entities.Interfaces.Employees.Deductions;

/// <summary>
/// Interface for retrieving all employee deductions.
/// </summary>
public interface IGetAllEmployeeDeductionDTO : IEntityDTO
{
    public int Id { get; }
    public decimal Percentage { get; }
    public string Description { get; }
}