using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUdes.Dtos;

public class UserroleDto
{
    public int IdUserRol { get; set; }
    public int FkIdUser { get; set; }
    public int FkIdRol { get; set; }
}