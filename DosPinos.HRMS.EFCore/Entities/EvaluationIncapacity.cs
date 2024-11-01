using System;
using System.Collections.Generic;

namespace DosPinos.HRMS.EFCore.Entities;

public partial class EvaluationIncapacity
{
    public int EvaluationIncapacityId { get; set; }

    public DateOnly EvaluationIncapacityDate { get; set; }

    public bool NotifiedRrhh { get; set; }

    public string ApprovalStatus { get; set; }

    public int EmployeeId { get; set; }

    public int IncapacityId { get; set; }

    public virtual Employee Employee { get; set; }

    public virtual Incapacity Incapacity { get; set; }
}
