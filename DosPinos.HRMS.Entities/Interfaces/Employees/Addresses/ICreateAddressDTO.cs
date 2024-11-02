namespace DosPinos.HRMS.Entities.Interfaces.Employees.Addresses
{
    public interface ICreateAddressDTO
    {
        string Address { get; set; }
        byte DistrictId { get; set; }
    }
}