namespace DosPinos.HRMS.Entities.Interfaces.Employees.Addresses;

/// <summary>
/// Interface for create an address
/// </summary>
public interface ICreateAddressDTO : IEntityDTO
{
    string Address { get; }
    short DistrictId { get; }
}