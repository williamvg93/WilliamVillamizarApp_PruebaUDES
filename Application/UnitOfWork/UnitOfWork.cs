using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repository;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApiUdesContext _context;
    private IUser _users;
    private IRole _roles;
    private IUserrole _userroles;


    public UnitOfWork(ApiUdesContext context)
    {
        _context = context;
    }

    public IUser Users
    {
        get
        {
            if (_users == null)
            {
                _users = new UserRepo(_context);
            }
            return _users;
        }
    }
    public IRole Roles
    {
        get
        {
            if (_roles == null)
            {
                _roles = new RoleRepo(_context);
            }
            return _roles;
        }
    }
    public IUserrole Userroles
    {
        get
        {
            if (_userroles == null)
            {
                _userroles = new UserroleRepo(_context);
            }
            return _userroles;
        }
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }

}