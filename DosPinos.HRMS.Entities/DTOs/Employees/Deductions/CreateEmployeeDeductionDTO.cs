using DosPinos.HRMS.Entities.Interfaces.Employees.Deductions;

namespace DosPinos.HRMS.Entities.DTOs.Employees.Deductions
{
    public class CreateEmployeeDeductionDTO : ICreateEmployeeDeductionDTO
    {
        public decimal DeductionAmount { get; set; }
        public byte DeductionId { get; set; }
        public int EmployeeId { get; set; }
    }
}