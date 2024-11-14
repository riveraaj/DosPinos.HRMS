namespace DosPinos.HRMS.Entities.DTOs.Liquidation
{
    public class CreateLiquidationDTO : EntityDTO, IEntityDTO
    {
        public int EmployeeId { get; set; }
        public int Identification { get; set; }
        public DateOnly TerminationDate { get; set; }
        public bool PreNotice { get; set; }
        public bool ApplySeverance { get; set; }
    }
}