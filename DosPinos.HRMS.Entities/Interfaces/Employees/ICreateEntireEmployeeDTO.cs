namespace DosPinos.HRMS.Entities.Interfaces.Employees;

/// <summary>
/// Interface for creating an entire employee.
/// </summary>
public interface ICreateEntireEmployeeDTO : IEntityDTO
{
    ICreateEmployeeDTO Employee { get; }
    ICreateAddressDTO Address { get; }
    ICreateEmployeeCompensationDTO Compensation { get; }
    ICreateEmployeeDetailDTO Detail { get; }
    ICreatePhoneDTO Phone { get; }
}