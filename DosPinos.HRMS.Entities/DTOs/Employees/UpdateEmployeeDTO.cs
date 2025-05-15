namespace DosPinos.HRMS.Entities.DTOs.Employees;

/// <summary>
/// DTO for updating employee information.
/// </summary>
public class UpdateEmployeeDTO(int id, string fistName,
                               string lastName, string secondLastName,
                               decimal overtime, int managerId,
                               bool hasManager) : EntityDTO, IUpdateEmployeeDTO
{
    public int Id => id;
    public string FirstName => fistName;
    public string LastName => lastName;
    public string SecondLastName => secondLastName;
    public decimal Overtime => overtime;
    public int ManagerId => managerId;
    public bool HasManager => hasManager;
}