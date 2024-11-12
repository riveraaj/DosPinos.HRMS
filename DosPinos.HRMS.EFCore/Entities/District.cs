namespace DosPinos.HRMS.EFCore.Entities;

public partial class District
{
    public short DistrictId { get; set; }

    public string DistrictDescription { get; set; }

    public byte CantonId { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual Canton Canton { get; set; }
}
