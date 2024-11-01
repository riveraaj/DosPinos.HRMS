using System;
using System.Collections.Generic;

namespace DosPinos.HRMS.EFCore.Entities;

public partial class Vacation
{
    public int VacationId { get; set; }

    public DateOnly VacationDate { get; set; }

    public DateOnly DateStart { get; set; }

    public DateOnly DateEnd { get; set; }

    public string ApprovalStatus { get; set; }

    public int EmployeeId { get; set; }

    public virtual Employee Employee { get; set; }

    public virtual ICollection<EvaluationVacation> EvaluationVacations { get; set; } = new List<EvaluationVacation>();
}
