namespace DosPinos.HRMS.Entities.DTOs.Employees;

/// <summary>
/// DTO for retrieving all active employees.
/// </summary>
public class GetAllActiveEmployeeDTO(int id, string fullName) : EntityDTO, IGetAllActiveEmployeeDTO
{
    public int Id => id;
    public string FullName => fullName;
}