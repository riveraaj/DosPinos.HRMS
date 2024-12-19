namespace DosPinos.HRMS.Entities.DTOs.Payroll
{
    public class GetAllPayrollByEmployeeDTO
    {
        public int Identification { get; set; }
        public string JobTitle { get; set; }
        public string FullName { get; set; }
        public DateOnly StartPeriod { get; set; }
        public DateOnly EndPeriod { get; set; }
        public decimal GrossSalary { get; set; }
        public decimal Overtime { get; set; }
        public decimal AmoutOvertime { get; set; }
        public decimal Bonus { get; set; }
        public decimal Deductions { get; set; }
        public decimal NetSalary { get; set; }
        public bool IsConfirmed { get; set; }
        public decimal Salary { get; set; }
    }
}