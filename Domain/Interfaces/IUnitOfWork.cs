using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces;

public interface IUnitOfWork
{
    IUser Users { get; }
    IRole Roles { get; }
    IUserrole Userroles { get; }
    Task<int> SaveAsync();
}