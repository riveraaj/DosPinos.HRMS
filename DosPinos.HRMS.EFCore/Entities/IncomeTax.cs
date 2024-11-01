using System;
using System.Collections.Generic;

namespace DosPinos.HRMS.EFCore.Entities;

public partial class IncomeTax
{
    public byte IncomeTaxId { get; set; }

    public decimal IncomeTaxPercentage { get; set; }

    public virtual ICollection<SalaryCategory> SalaryCategories { get; set; } = new List<SalaryCategory>();
}
