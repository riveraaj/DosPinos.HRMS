using System;
using System.Collections.Generic;

namespace DosPinos.HRMS.EFCore.Entities;

public partial class EvaluationVacation
{
    public int EvaluationVacationId { get; set; }

    public DateOnly EvaluationVacationDate { get; set; }

    public bool NotifiedRrhh { get; set; }

    public int EmployeeId { get; set; }

    public int VacationId { get; set; }

    public virtual Employee Employee { get; set; }

    public virtual Vacation Vacation { get; set; }
}
