namespace DosPinos.HRMS.Entities.DTOs.IncomeTaxes
{
    public class GetAllIncomeTaxTableDTO
    {
        public byte IncomeTaxId { get; set; }
        public decimal Percentage { get; set; }
        public decimal min { get; set; }
        public decimal max { get; set; }
    }
}