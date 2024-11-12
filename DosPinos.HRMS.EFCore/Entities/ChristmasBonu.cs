namespace DosPinos.HRMS.EFCore.Entities;

public partial class ChristmasBonu
{
    public int ChristmasBonusId { get; set; }

    public DateOnly DateCalculate { get; set; }

    public decimal Amount { get; set; }

    public bool IsConfirmated { get; set; }

    public int EmployeeId { get; set; }

    public virtual Employee Employee { get; set; }
}
