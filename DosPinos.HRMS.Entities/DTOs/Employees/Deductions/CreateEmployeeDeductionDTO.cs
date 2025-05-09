namespace DosPinos.HRMS.Entities.DTOs.Employees.Deductions;

/// <summary>
/// DTO for creating an employee deduction.
/// </summary>
public class CreateEmployeeDeductionDTO(int employeeId,
                                        byte id,
                                        decimal percentage) : EntityDTO, ICreateEmployeeDeductionDTO
{
    public int EmployeeId => employeeId;
    public byte Id => id;
    public decimal Percentage => percentage;
}