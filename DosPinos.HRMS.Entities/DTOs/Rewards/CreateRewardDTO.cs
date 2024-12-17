namespace DosPinos.HRMS.Entities.DTOs.Rewards
{
    public class CreateRewardDTO : EntityDTO, IEntityDTO
    {
        public string Identification { get; set; }
        public int EmployeeId { get; set; }
        public DateOnly Date { get; set; }
        public string Reason { get; set; }
        public decimal Amount { get; set; }
    }
}