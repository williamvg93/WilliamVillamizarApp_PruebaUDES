using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class User
{
    public int IdUser { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string DocType { get; set; } = null!;

    public int IdenNum { get; set; }

    public string Email { get; set; } = null!;

    public string User1 { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Userrole> Userroles { get; set; } = new List<Userrole>();
}
