using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUdes.Dtos;

public class UserDto
{
    public int IdUser { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string DocType { get; set; }
    public int IdenNum { get; set; }
    public string Email { get; set; }
    public string User1 { get; set; }
    public string Password { get; set; }
}
