namespace DosPinos.HRMS.EFCore.Entities;

public partial class Province
{
    public byte ProvinceId { get; set; }

    public string ProvinceDescription { get; set; }

    public virtual ICollection<Canton> Cantons { get; set; } = new List<Canton>();
}
