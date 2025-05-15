namespace DosPinos.HRMS.Entities.Interfaces.Employees;

/// <summary>
/// Interface for updating employee information.
/// </summary>
public interface IUpdateEmployeeDTO : IEntityDTO
{
    public int Id { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public string SecondLastName { get; }
    public decimal Overtime { get; }
    public int ManagerId { get; }
    public bool HasManager { get; }
}