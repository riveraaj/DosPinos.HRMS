namespace DosPinos.HRMS.Entities.Interfaces.Employees.Addresses;

/// <summary>
/// Interface to update an address.   
/// </summary>
public interface IUpdateAddressDTO : IEntityDTO
{
    int EmployeeId { get; }
    string Address { get; }
    int DistrictId { get; }
}