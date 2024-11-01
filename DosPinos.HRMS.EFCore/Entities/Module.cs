using System;
using System.Collections.Generic;

namespace DosPinos.HRMS.EFCore.Entities;

public partial class Module
{
    public byte ModuleId { get; set; }

    public string ModuleDescription { get; set; }

    public virtual ICollection<Log> Logs { get; set; } = new List<Log>();
}
