namespace DosPinos.HRMS.Entities.DTOs.Employees.Deductions
{
    public class GetAllEmployeeDeductionDTO
    {
        public int EmployeeDeductionId { get; set; }
        public decimal Percentage { get; set; }
        public string DeductionDescription { get; set; }
    }
}