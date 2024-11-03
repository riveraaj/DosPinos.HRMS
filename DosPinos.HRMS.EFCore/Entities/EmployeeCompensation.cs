using System;
using System.Collections.Generic;

namespace DosPinos.HRMS.EFCore.Entities;

public partial class EmployeeCompensation
{
    public int EmployeeCompensationId { get; set; }

    public byte SalaryCategoryId { get; set; }

    public int EmployeeId { get; set; }

    public virtual Employee Employee { get; set; }

    public virtual SalaryCategory SalaryCategory { get; set; }
}
