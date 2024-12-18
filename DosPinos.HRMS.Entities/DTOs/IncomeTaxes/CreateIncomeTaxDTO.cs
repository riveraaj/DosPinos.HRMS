namespace DosPinos.HRMS.Entities.DTOs.IncomeTaxes
{
    public class CreateIncomeTaxDTO : EntityDTO, IEntityDTO
    {
        public decimal Percentage { get; set; }
        public decimal Min { get; set; }
        public decimal Max { get; set; }
    }
}