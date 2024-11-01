using System;
using System.Collections.Generic;

namespace DosPinos.HRMS.EFCore.Entities;

public partial class License
{
    public int LicenseId { get; set; }

    public DateOnly DateStart { get; set; }

    public DateOnly DateEnd { get; set; }

    public string PathDocumentation { get; set; }

    public bool MandatoryPayment { get; set; }

    public string ApprovalStatus { get; set; }

    public int EmployeeId { get; set; }

    public byte LicenseTypeId { get; set; }

    public virtual Employee Employee { get; set; }

    public virtual ICollection<EvaluationLicense> EvaluationLicenses { get; set; } = new List<EvaluationLicense>();

    public virtual LicenseType LicenseType { get; set; }
}
