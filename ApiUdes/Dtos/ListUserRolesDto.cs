using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUdes.Dtos;

public class ListUserRolesDto
{
    public int IdUserRol { get; set; }
    public int IdUser { get; set; }
    public string UserName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public int IdenNum { get; set; }
    public string RolName { get; set; } = null!;
}
