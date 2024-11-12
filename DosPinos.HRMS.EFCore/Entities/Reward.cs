namespace DosPinos.HRMS.EFCore.Entities;

public partial class Reward
{
    public int RewardId { get; set; }

    public DateOnly RewardDate { get; set; }

    public string Reason { get; set; }

    public decimal Amount { get; set; }

    public int EmployeeId { get; set; }

    public virtual Employee Employee { get; set; }
}
