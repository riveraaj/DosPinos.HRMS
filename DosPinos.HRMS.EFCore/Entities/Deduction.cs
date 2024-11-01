using System;
using System.Collections.Generic;

namespace DosPinos.HRMS.EFCore.Entities;

public partial class Deduction
{
    public byte DeductionId { get; set; }

    public string DeductionDescription { get; set; }

    public decimal DeductionPercentage { get; set; }

    public virtual ICollection<EmployeeDeduction> EmployeeDeductions { get; set; } = new List<EmployeeDeduction>();
}
