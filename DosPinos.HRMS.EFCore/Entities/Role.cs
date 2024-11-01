using System;
using System.Collections.Generic;

namespace DosPinos.HRMS.EFCore.Entities;

public partial class Role
{
    public byte RoleId { get; set; }

    public string RoleDescription { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
