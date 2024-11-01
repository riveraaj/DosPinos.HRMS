using System;
using System.Collections.Generic;

namespace DosPinos.HRMS.EFCore.Entities;

public partial class ActionCategory
{
    public byte ActionCategoryId { get; set; }

    public string ActionCategoryDescription { get; set; }

    public virtual ICollection<Log> Logs { get; set; } = new List<Log>();
}
