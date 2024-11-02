namespace DosPinos.HRMS.Entities.DTOs.Employees.Deductions
{
    public class CreateEmployeeDeductionDTO : ICreateEmployeeDeductionDTO
    {
        public decimal DeductionAmount { get; set; } = 1;
        public byte DeductionId { get; set; }
        public int EmployeeId { get; set; }
    }
}