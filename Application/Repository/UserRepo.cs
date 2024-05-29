using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

public class UserRepo : GenericRepository<User>, IUser
{
    private readonly ApiUdesContext _context;

    public UserRepo(ApiUdesContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Login> GetUserByName(Login user)
    {
        return await (
           from us in _context.Users
           where us.User1 == user.User1
           && us.Password == user.Password
           select new Login
           {
               User1 = us.User1,
               Password = us.Password
           }
       ).FirstOrDefaultAsync();
    }
}