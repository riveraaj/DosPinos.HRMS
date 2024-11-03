namespace DosPinos.HRMS.Entities.DTOs.Employees.Addresses
{
    public class CreateAddressDTO : ICreateAddressDTO
    {
        public string Address { get; set; }
        public short DistrictId { get; set; }
    }
}