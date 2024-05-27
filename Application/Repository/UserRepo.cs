using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class UserRepo : GenericRepository<User>, IUser
{
    private readonly ApiUdesContext _context;

    public UserRepo(ApiUdesContext context) : base(context)
    {
        _context = context;
    }

    /*    public async Task<IEnumerable<User>> GetUserByName()
       {
      /*      return await (
               from user in _context.Users
               where user.Name == 
           ) 
       } */
}