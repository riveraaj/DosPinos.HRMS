using DosPinos.HRMS.Entities.DTOs.Employees.Addresses;
using DosPinos.HRMS.Entities.DTOs.Employees.Compesations;
using DosPinos.HRMS.Entities.DTOs.Employees.Deductions;
using DosPinos.HRMS.Entities.DTOs.Employees.Details;
using DosPinos.HRMS.Entities.DTOs.Employees.Phones;

namespace DosPinos.HRMS.Entities.DTOs.Employees
{
    public class UpdateEntireEmployeeDTO : EntityDTO, IEntityDTO
    {
        public UpdateEmployeeDTO EmployeeObj { get; set; }
        public UpdatePhoneDTO PhoneObj { get; set; }
        public UpdateAddressDTO AddressObj { get; set; }
        public UpdateEmployeeDetailDTO DetailObj { get; set; }
        public UpdateEmployeeCompensationDTO CompensationObj { get; set; }
        public CreateEmployeeDeductionDTO DeductionObj { get; set; }
    }
}