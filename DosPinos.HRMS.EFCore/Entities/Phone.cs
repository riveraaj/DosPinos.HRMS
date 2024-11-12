namespace DosPinos.HRMS.EFCore.Entities;

public partial class Phone
{
    public int PhoneId { get; set; }

    public string PhoneNumber { get; set; }

    public int EmployeeId { get; set; }

    public byte PhoneTypeId { get; set; }

    public virtual Employee Employee { get; set; }

    public virtual PhoneType PhoneType { get; set; }
}
