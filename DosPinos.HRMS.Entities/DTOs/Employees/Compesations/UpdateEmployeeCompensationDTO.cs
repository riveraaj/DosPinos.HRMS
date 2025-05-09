namespace DosPinos.HRMS.Entities.DTOs.Employees.Compesations;

/// <summary>
/// DTO for updating employee compensation.
/// </summary>
public class UpdateEmployeeCompensationDTO(int employeeId, int salaryCategoryId) : EntityDTO, IUpdateEmployeeCompensationDTO
{
    public int EmployeeId => employeeId;
    public int SalaryCategoryId => salaryCategoryId;
}