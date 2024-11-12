namespace DosPinos.HRMS.EFCore.Entities;

public partial class WorkingDay
{
    public int WorkingDayId { get; set; }

    public DateOnly WorkingDayDate { get; set; }

    public TimeOnly EndTime { get; set; }

    public TimeOnly StartTime { get; set; }

    public decimal HoursWorked { get; set; }

    public string ApprovalStatus { get; set; }

    public int EmployeeId { get; set; }

    public byte? HolidayId { get; set; }

    public virtual Employee Employee { get; set; }

    public virtual ICollection<EvaluationWorkingDay> EvaluationWorkingDays { get; set; } = new List<EvaluationWorkingDay>();

    public virtual Holiday Holiday { get; set; }

    public virtual ICollection<Overtime> Overtimes { get; set; } = new List<Overtime>();
}
