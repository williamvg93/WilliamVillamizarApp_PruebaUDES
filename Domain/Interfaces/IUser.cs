using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Domain.Interfaces;

public interface IUser : IGenericRepository<User>
{
    Task<Login> GetUserByName(Login user);
}