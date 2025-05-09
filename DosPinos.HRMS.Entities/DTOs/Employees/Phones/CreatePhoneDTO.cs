namespace DosPinos.HRMS.Entities.DTOs.Employees.Phones;

/// <summary>
/// DTO for creating a phone number.
/// </summary>
public class CreatePhoneDTO(string number,
                            byte phoneTypeId) : EntityDTO, ICreatePhoneDTO
{
    public string Number => number;
    public byte PhoneTypeId => phoneTypeId;
}