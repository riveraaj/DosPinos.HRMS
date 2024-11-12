namespace DosPinos.HRMS.EFCore.Entities;

public partial class Payroll
{
    public int PayrollId { get; set; }

    public DateOnly StartPeriod { get; set; }

    public DateOnly EndPeriod { get; set; }

    public decimal GrossSalary { get; set; }

    public decimal Deductions { get; set; }

    public decimal NetSalary { get; set; }

    public decimal AmountOvertime { get; set; }

    public decimal Overtime { get; set; }

    public decimal Bonus { get; set; }

    public bool IsConfirmated { get; set; }

    public int EmployeeId { get; set; }

    public virtual Employee Employee { get; set; }
}
