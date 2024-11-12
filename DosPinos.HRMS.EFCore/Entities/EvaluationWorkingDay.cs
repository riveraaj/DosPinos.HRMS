namespace DosPinos.HRMS.EFCore.Entities;

public partial class EvaluationWorkingDay
{
    public int EvaluationWorkingDayId { get; set; }

    public string Comment { get; set; }

    public DateOnly EvaluationWorkingDayDate { get; set; }

    public string ApprovalStatus { get; set; }

    public bool NotifiedRrhh { get; set; }

    public int EmployeeId { get; set; }

    public int WorkingDayId { get; set; }

    public virtual Employee Employee { get; set; }

    public virtual WorkingDay WorkingDay { get; set; }
}
