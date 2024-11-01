using System;
using System.Collections.Generic;

namespace DosPinos.HRMS.EFCore.Entities;

public partial class Liquidation
{
    public int LiquidationId { get; set; }

    public DateOnly LiquidationDate { get; set; }

    public decimal Amount { get; set; }

    public int EmployeeId { get; set; }

    public virtual Employee Employee { get; set; }
}
