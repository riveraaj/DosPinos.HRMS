namespace DosPinos.HRMS.Entities.Interfaces.Employees
{
    public interface ICreateEntireEmployeeDTO : IEntityDTO
    {
        ICreateEmployeeDTO Employee { get; set; }
        ICreateAddressDTO Address { get; set; }
        ICreateEmployeeCompensationDTO Compensation { get; set; }
        ICreateEmployeeDetailDTO Detail { get; set; }
        ICreatePhoneDTO Phone { get; set; }
    }
}