namespace DosPinos.HRMS.Entities.DTOs.IncomeTaxes
{
    public class UpdateIncomeTaxDTO : EntityDTO, IEntityDTO
    {
        public byte IncomeTaxId { get; set; }
        public decimal Percentage { get; set; }
    }
}