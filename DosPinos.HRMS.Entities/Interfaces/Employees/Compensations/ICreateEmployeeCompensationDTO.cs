namespace DosPinos.HRMS.Entities.Interfaces.Employees.Compensations;

/// <summary>
/// Interface for creating an employee compensation.
/// </summary>
public interface ICreateEmployeeCompensationDTO : IEntityDTO
{
    byte SalaryCategoryId { get; }
}