namespace DosPinos.HRMS.EFCore.Entities;

public partial class OvertimeType
{
    public byte OvertimeTypeId { get; set; }

    public string OvertimeTypeDescription { get; set; }

    public decimal Multiplier { get; set; }

    public virtual ICollection<Overtime> Overtimes { get; set; } = new List<Overtime>();
}
