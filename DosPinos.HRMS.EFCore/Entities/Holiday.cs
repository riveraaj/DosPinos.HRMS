using System;
using System.Collections.Generic;

namespace DosPinos.HRMS.EFCore.Entities;

public partial class Holiday
{
    public byte HolidayId { get; set; }

    public DateOnly HolidayDate { get; set; }

    public string HolidayDescription { get; set; }

    public bool MandatoryPayment { get; set; }

    public virtual ICollection<WorkingDay> WorkingDays { get; set; } = new List<WorkingDay>();
}
