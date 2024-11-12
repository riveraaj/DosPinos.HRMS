namespace DosPinos.HRMS.EFCore.Entities;

public partial class Nationality
{
    public byte NationalityId { get; set; }

    public string NationalityDescription { get; set; }

    public virtual ICollection<EmployeeDetail> EmployeeDetails { get; set; } = new List<EmployeeDetail>();
}
