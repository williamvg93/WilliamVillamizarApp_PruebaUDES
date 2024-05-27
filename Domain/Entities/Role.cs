using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Role
{
    public int IdRol { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Userrole> Userroles { get; set; } = new List<Userrole>();
}
