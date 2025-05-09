namespace DosPinos.HRMS.Entities.DTOs.Employees.Compesations;

/// <summary>
/// DTO for creating an employee compensation.
/// </summary>
public class CreateEmployeeCompensationDTO(byte salaryCategoryId) : EntityDTO, ICreateEmployeeCompensationDTO
{
    public byte SalaryCategoryId => salaryCategoryId;
}