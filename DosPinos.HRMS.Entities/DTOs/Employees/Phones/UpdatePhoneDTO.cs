namespace DosPinos.HRMS.Entities.DTOs.Employees.Phones;

/// <summary>
/// DTO for updating a phone number.
/// </summary>
public class UpdatePhoneDTO(int employeeId,
                            string number,
                            int phoneTypeId) : EntityDTO, IUpdatePhoneDTO
{
    public int EmployeeId => employeeId;
    public string Number => number;
    public int PhoneTypeId => phoneTypeId;
}