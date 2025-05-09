namespace DosPinos.HRMS.Entities.Interfaces.Employees.Compensations;

/// <summary>
/// DTO for creating an employee compensation.
/// </summary>
public interface ICreateEmployeeCompensationDTO : IEntityDTO
{
    byte SalaryCategoryId { get; }
}