namespace DosPinos.HRMS.EFCore.Entities;

public partial class EmployeeVacationBalance
{
    public int EmployeeVacationBalanceId { get; set; }

    public decimal RemainingDays { get; set; }

    public decimal UsedDays { get; set; }

    public DateOnly LastUpdateDate { get; set; }

    public int EmployeeId { get; set; }

    public virtual Employee Employee { get; set; }
}
