namespace DosPinos.HRMS.EFCore.Entities;

public partial class Gender
{
    public byte GenderId { get; set; }

    public string GenderDescription { get; set; }

    public virtual ICollection<EmployeeDetail> EmployeeDetails { get; set; } = new List<EmployeeDetail>();
}
