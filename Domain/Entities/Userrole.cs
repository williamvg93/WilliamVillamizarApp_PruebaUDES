using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Userrole
{
    public int IdUserRol { get; set; }

    public int FkIdUser { get; set; }

    public int FkIdRol { get; set; }

    public virtual Role FkIdRolNavigation { get; set; } = null!;

    public virtual User FkIdUserNavigation { get; set; } = null!;
}
