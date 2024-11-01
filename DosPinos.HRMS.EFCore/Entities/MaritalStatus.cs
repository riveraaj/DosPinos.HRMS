using System;
using System.Collections.Generic;

namespace DosPinos.HRMS.EFCore.Entities;

public partial class MaritalStatus
{
    public byte MaritalStatusId { get; set; }

    public string MaritalStatusDescription { get; set; }

    public virtual ICollection<EmployeeDetail> EmployeeDetails { get; set; } = new List<EmployeeDetail>();
}
