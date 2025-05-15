namespace DosPinos.HRMS.Entities.Interfaces.Employees;

/// <summary>
/// Interface for creating an employee.
/// </summary>
public interface ICreateEmployeeDTO : IEntityDTO
{
    int Identification { get; }
    string Name { get; }
    string FirstLastName { get; }
    string SecondLastName { get; }
    int ManagerId { get; }
}