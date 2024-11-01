using System;
using System.Collections.Generic;

namespace DosPinos.HRMS.EFCore.Entities;

public partial class SalaryCategory
{
    public byte SalaryCategoryId { get; set; }

    public string SalaryCategoryDescription { get; set; }

    public decimal SalaryCategoryRange { get; set; }

    public byte IncomeTaxId { get; set; }

    public virtual ICollection<EmployeeCompensation> EmployeeCompensations { get; set; } = new List<EmployeeCompensation>();

    public virtual IncomeTax IncomeTax { get; set; }
}
