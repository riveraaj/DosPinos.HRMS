namespace DosPinos.HRMS.Entities.DTOs.ChristmasBonus
{
    public class GetAllChristmasBonusDTO
    {
        public int EmployeeId { get; set; }
        public int Identification { get; set; }
        public string FullName { get; set; }
        public string Job { get; set; }
        public decimal Amount { get; set; }
        public DateOnly Date { get; set; }
        public bool IsConfirmated { get; set; }
    }
}