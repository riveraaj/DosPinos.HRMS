namespace DosPinos.HRMS.Entities.DTOs.Employees.Addresses;

/// <summary>
/// DTO for create an address
/// </summary>
public class CreateAddressDTO(string address,
                              short districtId) : EntityDTO, ICreateAddressDTO
{
    public string Address => address;
    public short DistrictId => districtId;
}