using System;
using System.Collections.Generic;

namespace DosPinos.HRMS.EFCore.Entities;

public partial class Log
{
    public int LogId { get; set; }

    public DateTime Timestamp { get; set; }

    public string Source { get; set; }

    public string Message { get; set; }

    public string Exception { get; set; }

    public int UserId { get; set; }

    public byte ActionCategoryId { get; set; }

    public byte ModuleId { get; set; }

    public virtual ActionCategory ActionCategory { get; set; }

    public virtual Module Module { get; set; }

    public virtual User User { get; set; }
}
