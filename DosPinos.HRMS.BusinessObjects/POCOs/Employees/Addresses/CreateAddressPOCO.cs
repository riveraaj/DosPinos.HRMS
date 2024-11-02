using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Addresses.POCOs;
using DosPinos.HRMS.BusinessObjects.ValidationAttributes;

namespace DosPinos.HRMS.BusinessObjects.POCOs.Employees.Addresses
{
    public class CreateAddressPOCO(int employeeId) : ICreateAddressPOCO
    {
        [RequiredAndMaxLength(200)]
        public string Address { get; set; }

        [RequiredGreaterThanZero]
        public byte DistrictId { get; set; }

        [RequiredGreaterThanZero]
        public int EmployeeId { get; } = employeeId;
    }
}