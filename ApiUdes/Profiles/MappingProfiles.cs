using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiUdes.Dtos;
using AutoMapper;
using Domain.Entities;

namespace ApiUdes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<User, UserDto>()
        .ReverseMap();

        CreateMap<Role, RoleDto>()
        .ReverseMap();

        CreateMap<Userrole, UserroleDto>()
        .ReverseMap();
    }
}
