namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Deductions.POCOs
{
    public interface ICreateEmployeeDeductionPOCO
    {
        decimal DeductionAmount { get; set; }
        byte DeductionId { get; set; }
        int EmployeeId { get; set; }
    }
}