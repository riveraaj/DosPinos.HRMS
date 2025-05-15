namespace DosPinos.HRMS.Entities.DTOs.Employees;

/// <summary>
/// DTO for creating an entire employee.
/// </summary>
public class CreateEntireEmployeeDTO(ICreateEmployeeDTO employee,
                                     ICreateAddressDTO address,
                                     ICreateEmployeeCompensationDTO compensation,
                                     ICreateEmployeeDetailDTO detail,
                                     ICreatePhoneDTO phone) : EntityDTO, ICreateEntireEmployeeDTO
{
    public ICreateEmployeeDTO Employee => employee;
    public ICreateAddressDTO Address => address;
    public ICreateEmployeeCompensationDTO Compensation => compensation;
    public ICreateEmployeeDetailDTO Detail => detail;
    public ICreatePhoneDTO Phone => phone;
}