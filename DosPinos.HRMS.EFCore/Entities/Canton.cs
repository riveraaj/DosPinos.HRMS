namespace DosPinos.HRMS.EFCore.Entities;

public partial class Canton
{
    public byte CantonId { get; set; }

    public string CantonDescription { get; set; }

    public byte ProvinceId { get; set; }

    public virtual ICollection<District> Districts { get; set; } = new List<District>();

    public virtual Province Province { get; set; }
}
