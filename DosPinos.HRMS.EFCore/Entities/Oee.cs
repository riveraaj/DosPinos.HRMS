namespace DosPinos.HRMS.EFCore.Entities;

public partial class Oee
{
    public int OeeId { get; set; }

    public DateOnly OeeDate { get; set; }

    public decimal Availability { get; set; }

    public decimal Performance { get; set; }

    public decimal Cuality { get; set; }

    public decimal Total { get; set; }

    public byte MachineId { get; set; }

    public int EmployeeId { get; set; }

    public virtual Employee Employee { get; set; }

    public virtual Machine Machine { get; set; }
}
