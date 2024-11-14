namespace DosPinos.HRMS.Entities.DTOs.Liquidation
{
    public class GetAllLiquidationDTO
    {
        public int LiquidationId { get; set; }
        public int EmployeeId { get; set; }
        public int Identification { get; set; }
        public string FullName { get; set; }
        public DateOnly LiquidatioDate { get; set; }
        public decimal Amount { get; set; }
        public bool isConfirmated { get; set; }
        public decimal Severance { get; set; }
        public decimal ChristmasBonus { get; set; }
        public decimal Vacation { get; set; }
        public decimal PreNotice { get; set; }
    }
}