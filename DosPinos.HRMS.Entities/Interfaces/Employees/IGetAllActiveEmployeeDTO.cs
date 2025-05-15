namespace DosPinos.HRMS.Entities.Interfaces.Employees;

/// <summary>
/// Interface for retrieve all active employees.
/// </summary>
public interface IGetAllActiveEmployeeDTO : IEntityDTO
{
    public int Id { get; }
    public string FullName { get; }
}