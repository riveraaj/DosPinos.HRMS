using DosPinos.HRMS.Entities.Interfaces.Employees.Addresses;

namespace DosPinos.HRMS.Entities.DTOs.Employees.Addresses
{
    public class CreateAddressDTO : ICreateAddressDTO
    {
        public string Address { get; set; }
        public byte DistrictId { get; set; }
    }
}