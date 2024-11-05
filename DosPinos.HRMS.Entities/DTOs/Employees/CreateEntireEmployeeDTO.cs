using DosPinos.HRMS.Entities.Interfaces.Employees;

namespace DosPinos.HRMS.Entities.DTOs.Employees
{
    public class CreateEntireEmployeeDTO : EntityDTO, ICreateEntireEmployeeDTO
    {
        public ICreateEmployeeDTO Employee { get; set; }
        public ICreateAddressDTO Address { get; set; }
        public ICreateEmployeeCompensationDTO Compensation { get; set; }
        public ICreateEmployeeDeductionDTO Deduction { get; set; }
        public ICreateEmployeeDetailDTO Detail { get; set; }
        public ICreatePhoneDTO Phone { get; set; }
    }
}