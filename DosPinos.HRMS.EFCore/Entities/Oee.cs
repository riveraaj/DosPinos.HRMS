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

    public int EmployeeOne { get; set; }

    public int EmployeeTwo { get; set; }

    public int EmployeeThree { get; set; }

    public virtual Employee EmployeeOneNavigation { get; set; }

    public virtual Employee EmployeeThreeNavigation { get; set; }

    public virtual Employee EmployeeTwoNavigation { get; set; }

    public virtual Machine Machine { get; set; }
}
