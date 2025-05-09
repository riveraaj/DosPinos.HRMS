namespace DosPinos.HRMS.Entities.Interfaces.Employees.Phones;

/// <summary>
/// DTO for updating a phone number.
/// </summary>
public interface IUpdatePhoneDTO : IEntityDTO
{
    public int EmployeeId { get; }
    public string Number { get; }
    public int PhoneTypeId { get; }
}