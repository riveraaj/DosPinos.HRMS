namespace DosPinos.HRMS.Entities.DTOs.Employees.Addresses
{
    public class UpdateAddressDTO : EntityDTO, IEntityDTO
    {
        public int EmployeeId { get; set; }
        public string Address { get; set; }
        public int DistrictId { get; set; }
    }
}