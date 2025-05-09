namespace DosPinos.HRMS.Entities.Interfaces.Employees.Phones;

/// <summary>
/// Interface for creating a phone number.
/// </summary>
public interface ICreatePhoneDTO : IEntityDTO
{
    string Number { get; }
    byte PhoneTypeId { get; }
}