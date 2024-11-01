using System;
using System.Collections.Generic;

namespace DosPinos.HRMS.EFCore.Entities;

public partial class Overtime
{
    public int OvertimeId { get; set; }

    public decimal OvertimeHours { get; set; }

    public DateOnly OvertimeDate { get; set; }

    public int WorkingDayId { get; set; }

    public byte OvertimeTypeId { get; set; }

    public virtual OvertimeType OvertimeType { get; set; }

    public virtual WorkingDay WorkingDay { get; set; }
}
