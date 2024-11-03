namespace DosPinos.HRMS.Entities.Interfaces.Employees
{
    public interface ICreateEntireEmployeeDTO
    {
        ICreateEmployeeDTO Employee { get; set; }
        ICreateAddressDTO Address { get; set; }
        ICreateEmployeeCompensationDTO Compensation { get; set; }
        ICreateEmployeeDeductionDTO Deduction { get; set; }
        ICreateEmployeeDetailDTO Detail { get; set; }
        ICreatePhoneDTO Phone { get; set; }
    }
}