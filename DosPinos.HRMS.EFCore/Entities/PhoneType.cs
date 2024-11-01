using System;
using System.Collections.Generic;

namespace DosPinos.HRMS.EFCore.Entities;

public partial class PhoneType
{
    public byte PhoneTypeId { get; set; }

    public string PhoneTypeDescription { get; set; }

    public virtual ICollection<Phone> Phones { get; set; } = new List<Phone>();
}
