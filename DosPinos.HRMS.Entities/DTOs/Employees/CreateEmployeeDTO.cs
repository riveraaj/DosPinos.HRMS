namespace DosPinos.HRMS.Entities.DTOs.Employees;

/// <summary>
/// DTO for creating an employee.
/// </summary>
public class CreateEmployeeDTO(int identification,
                               string name,
                               string firstLastName,
                               string secondLastName,
                               int mangerId) : EntityDTO, ICreateEmployeeDTO
{
    public int Identification => identification;
    public string Name => name;
    public string FirstLastName => firstLastName;
    public string SecondLastName => secondLastName;
    public int ManagerId => mangerId;
}