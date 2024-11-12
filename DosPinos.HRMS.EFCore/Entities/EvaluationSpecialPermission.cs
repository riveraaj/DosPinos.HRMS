namespace DosPinos.HRMS.EFCore.Entities;

public partial class EvaluationSpecialPermission
{
    public int EvaluationSpecialPermissionId { get; set; }

    public DateOnly EvaluationSpecialPermissionDate { get; set; }

    public bool NotifiedRrhh { get; set; }

    public string ApprovalStatus { get; set; }

    public int EmployeeId { get; set; }

    public int SpecialPermissionId { get; set; }

    public virtual Employee Employee { get; set; }

    public virtual SpecialPermission SpecialPermission { get; set; }
}
