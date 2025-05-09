namespace DosPinos.HRMS.Entities.Interfaces.Employees.Compensations;

/// <summary>
/// DTO for updating employee compensation.
/// </summary>
public interface IUpdateEmployeeCompensationDTO : IEntityDTO
{
    int EmployeeId { get; }
    int SalaryCategoryId { get; }
}