using AutoMapper;
using Interceptor.Api.Models;
using Interceptor.Domain.Entities;

namespace Interceptor.Api.Mappers;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<User,UserDto>().ReverseMap();
    }
}