namespace DosPinos.HRMS.Entities.DTOs.Deductions
{
    public class UpdateDeductionDTO : EntityDTO, IEntityDTO
    {
        public byte DeductionId { get; set; }
        public decimal DeductionPercentage { get; set; }
    }
}