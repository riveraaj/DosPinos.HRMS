namespace DosPinos.HRMS.EFCore.Entities;

public partial class HiringType
{
    public byte HiringTypeId { get; set; }

    public string HiringTypeDescription { get; set; }

    public virtual ICollection<EmployeeDetail> EmployeeDetails { get; set; } = new List<EmployeeDetail>();
}
