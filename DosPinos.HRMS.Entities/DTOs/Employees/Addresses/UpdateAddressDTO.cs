namespace DosPinos.HRMS.Entities.DTOs.Employees.Addresses;

/// <summary>
/// DTO to update an address.   
/// </summary>
public class UpdateAddressDTO(int employeeId,
                              string address,
                              int districtId) : EntityDTO, IUpdateAddressDTO
{
    public int EmployeeId => employeeId;
    public string Address => address;
    public int DistrictId => districtId;
}