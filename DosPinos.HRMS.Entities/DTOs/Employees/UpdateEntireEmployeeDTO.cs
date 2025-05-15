namespace DosPinos.HRMS.Entities.DTOs.Employees;

/// <summary>
/// DTO for updating an entire employee.
/// </summary>
public class UpdateEntireEmployeeDTO(IUpdateEmployeeDTO employeeObj,
                                     IUpdatePhoneDTO phoneObj,
                                     IUpdateAddressDTO addressObj,
                                     IUpdateEmployeeDetailDTO detailObj,
                                     IUpdateEmployeeCompensationDTO compensationObj,
                                     ICreateEmployeeDeductionDTO deductionObj) : EntityDTO, IUpdateEntireEmployeeDTO
{
    public IUpdateEmployeeDTO EmployeeObj => employeeObj;
    public IUpdatePhoneDTO PhoneObj => phoneObj;
    public IUpdateAddressDTO AddressObj => addressObj;
    public IUpdateEmployeeDetailDTO DetailObj => detailObj;
    public IUpdateEmployeeCompensationDTO CompensationObj => compensationObj;
    public ICreateEmployeeDeductionDTO DeductionObj => deductionObj;
}