using System;
using System.Collections.Generic;

namespace DosPinos.HRMS.EFCore.Entities;

public partial class IncapacityType
{
    public byte IncapacityTypeId { get; set; }

    public string IncapacityTypeDescription { get; set; }

    public virtual ICollection<Incapacity> Incapacities { get; set; } = new List<Incapacity>();
}
