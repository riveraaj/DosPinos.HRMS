using System;
using System.Collections.Generic;

namespace DosPinos.HRMS.EFCore.Entities;

public partial class EmployeeDeduction
{
    public int EmployeeDeductionId { get; set; }

    public decimal DeductionAmount { get; set; }

    public byte DeductionId { get; set; }

    public int EmployeeId { get; set; }

    public virtual Deduction Deduction { get; set; }

    public virtual Employee Employee { get; set; }
}
