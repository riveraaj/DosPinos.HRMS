namespace DosPinos.HRMS.Entities.DTOs.Employees.Deductions
{
    public class UpdateEmployeeDeductionDTO : EntityDTO, IEntityDTO
    {
        public int EmployeeId { get; set; }
        public int DeductionId { get; set; }
        public int DeductionPercentage { get; set; }
    }
}