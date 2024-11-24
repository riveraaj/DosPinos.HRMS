using DosPinos.HRMS.Entities.DTOs.Employees.Addresses;
using DosPinos.HRMS.Entities.DTOs.Employees.Compesations;
using DosPinos.HRMS.Entities.DTOs.Employees.Details;
using DosPinos.HRMS.Entities.DTOs.Employees.Phones;
using DosPinos.HRMS.Entities.Interfaces.Employees;

namespace DosPinos.HRMS.Entities.DTOs.Employees
{
    public class CreateEntireEmployeeDTO : EntityDTO, ICreateEntireEmployeeDTO
    {
        public CreateEntireEmployeeDTO()
        {
            Employee = new CreateEmployeeDTO();
            Address = new CreateAddressDTO();
            Compensation = new CreateEmployeeCompensationDTO();
            Detail = new CreateEmployeeDetailDTO();
            Phone = new CreatePhoneDTO();
        }

        public ICreateEmployeeDTO Employee { get; set; }
        public ICreateAddressDTO Address { get; set; }
        public ICreateEmployeeCompensationDTO Compensation { get; set; }
        public ICreateEmployeeDetailDTO Detail { get; set; }
        public ICreatePhoneDTO Phone { get; set; }
    }
}