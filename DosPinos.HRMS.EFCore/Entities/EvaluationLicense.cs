using System;
using System.Collections.Generic;

namespace DosPinos.HRMS.EFCore.Entities;

public partial class EvaluationLicense
{
    public int EvaluationLicenseId { get; set; }

    public DateOnly EvaluationLicenseDate { get; set; }

    public bool NotifiedRrhh { get; set; }

    public string ApprovalStatus { get; set; }

    public int EmployeeId { get; set; }

    public int LicenseId { get; set; }

    public virtual Employee Employee { get; set; }

    public virtual License License { get; set; }
}
