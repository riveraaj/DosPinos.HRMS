namespace DosPinos.HRMS.EFCore.Entities;

public partial class JobTitle
{
    public byte JobTitleId { get; set; }

    public string JobTitleDescription { get; set; }

    public virtual ICollection<EmployeeDetail> EmployeeDetails { get; set; } = new List<EmployeeDetail>();
}
