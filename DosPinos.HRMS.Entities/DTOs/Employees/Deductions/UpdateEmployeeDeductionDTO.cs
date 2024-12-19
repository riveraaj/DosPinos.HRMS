namespace DosPinos.HRMS.Entities.DTOs.Employees.Deductions
{
    public class UpdateEmployeeDeductionDTO : EntityDTO, IEntityDTO
    {
        public int EmployeeId { get; set; }
        public byte DeductionId { get; set; }
        public decimal DeductionPercentage { get; set; }
    }
}