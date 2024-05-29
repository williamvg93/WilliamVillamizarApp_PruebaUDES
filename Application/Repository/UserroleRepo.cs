using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

public class UserroleRepo : GenericRepository<Userrole>, IUserrole
{
    private readonly ApiUdesContext _context;

    public UserroleRepo(ApiUdesContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ListUserRoles>> GetUserRolList()
    {
        return await (
            from user in _context.Users
            join userrol in _context.Userroles
            on user.IdUser equals userrol.FkIdUser
            join rol in _context.Roles
            on userrol.FkIdRol equals rol.IdRol
            select new ListUserRoles
            {
                IdUserRol = userrol.IdUserRol,
                IdUser = user.IdUser,
                UserName = user.Name,
                LastName = user.LastName,
                IdenNum = user.IdenNum,
                RolName = rol.Name
            }
        ).ToListAsync();
    }
}