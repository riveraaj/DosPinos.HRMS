using System;
using System.Collections.Generic;

namespace DosPinos.HRMS.EFCore.Entities;

public partial class LicenseType
{
    public byte LicenseTypeId { get; set; }

    public string LicenseTypeDescription { get; set; }

    public virtual ICollection<License> Licenses { get; set; } = new List<License>();
}
