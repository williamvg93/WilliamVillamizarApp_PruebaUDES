using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class UserroleRepo : GenericRepository<Userrole>, IUserrole
{
    private readonly ApiUdesContext _context;

    public UserroleRepo(ApiUdesContext context) : base(context)
    {
        _context = context;
    }
}