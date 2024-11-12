namespace DosPinos.HRMS.EFCore.Entities;

public partial class Liquidation
{
    public int LiquidationId { get; set; }

    public DateOnly LiquidationDate { get; set; }

    public decimal Amount { get; set; }

    public bool IsConfirmated { get; set; }

    public decimal Severance { get; set; }

    public decimal ChristmasBonus { get; set; }

    public decimal Vacation { get; set; }

    public decimal PreNotice { get; set; }

    public int EmployeeId { get; set; }

    public virtual Employee Employee { get; set; }
}
