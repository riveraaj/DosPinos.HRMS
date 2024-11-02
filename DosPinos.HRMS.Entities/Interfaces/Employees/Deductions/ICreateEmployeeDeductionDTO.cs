namespace DosPinos.HRMS.Entities.Interfaces.Employees.Deductions
{
    public interface ICreateEmployeeDeductionDTO
    {
        decimal DeductionAmount { get; set; }
        byte DeductionId { get; set; }
        int EmployeeId { get; set; }
    }
}