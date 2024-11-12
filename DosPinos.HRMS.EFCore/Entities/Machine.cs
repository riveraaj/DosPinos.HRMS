namespace DosPinos.HRMS.EFCore.Entities;

public partial class Machine
{
    public byte MachineId { get; set; }

    public string MachineDescription { get; set; }

    public virtual ICollection<Oee> Oees { get; set; } = new List<Oee>();
}
