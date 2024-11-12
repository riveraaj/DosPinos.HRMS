namespace DosPinos.HRMS.EFCore.Entities;

public partial class SpecialPermissionType
{
    public byte SpecialPermissionTypeId { get; set; }

    public string SpecialPermissionTypeDescription { get; set; }

    public virtual ICollection<SpecialPermission> SpecialPermissions { get; set; } = new List<SpecialPermission>();
}
