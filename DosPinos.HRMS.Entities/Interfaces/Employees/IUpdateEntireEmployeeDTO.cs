namespace DosPinos.HRMS.Entities.Interfaces.Employees;

/// <summary>
/// Interface for updating an entire employee.
/// </summary>
public interface IUpdateEntireEmployeeDTO : IEntityDTO
{
    public IUpdateEmployeeDTO EmployeeObj { get; }
    public IUpdatePhoneDTO PhoneObj { get; }
    public IUpdateAddressDTO AddressObj { get; }
    public IUpdateEmployeeDetailDTO DetailObj { get; }
    public IUpdateEmployeeCompensationDTO CompensationObj { get; }
    public ICreateEmployeeDeductionDTO DeductionObj { get; }
}