using System;
using System.Collections.Generic;

namespace DosPinos.HRMS.EFCore.Entities;

public partial class Incapacity
{
    public int IncapacityId { get; set; }

    public DateOnly DateStart { get; set; }

    public DateOnly DateEnd { get; set; }

    public string DocumentationPath { get; set; }

    public string ApprovalStatus { get; set; }

    public byte IncapacityTypeId { get; set; }

    public int EmployeeId { get; set; }

    public virtual Employee Employee { get; set; }

    public virtual ICollection<EvaluationIncapacity> EvaluationIncapacities { get; set; } = new List<EvaluationIncapacity>();

    public virtual IncapacityType IncapacityType { get; set; }
}
