namespace DosPinos.HRMS.Entities.Interfaces.Employees.Deductions;

/// <summary>
/// DTO for creating an employee deduction.
/// </summary>
public interface ICreateEmployeeDeductionDTO : IEntityDTO
{
    int EmployeeId { get; }
    byte Id { get; }
    decimal Percentage { get; }
}