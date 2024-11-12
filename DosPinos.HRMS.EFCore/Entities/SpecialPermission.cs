namespace DosPinos.HRMS.EFCore.Entities;

public partial class SpecialPermission
{
    public int SpecialPermissionId { get; set; }

    public DateOnly DateStart { get; set; }

    public DateOnly DateEnd { get; set; }

    public string DocumentationPath { get; set; }

    public string ApprovalStatus { get; set; }

    public byte SpecialPermissionTypeId { get; set; }

    public int EmployeeId { get; set; }

    public virtual Employee Employee { get; set; }

    public virtual ICollection<EvaluationSpecialPermission> EvaluationSpecialPermissions { get; set; } = new List<EvaluationSpecialPermission>();

    public virtual SpecialPermissionType SpecialPermissionType { get; set; }
}
