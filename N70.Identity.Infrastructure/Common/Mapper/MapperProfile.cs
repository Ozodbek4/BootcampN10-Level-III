using AutoMapper;
using N70.Identity.Application.Common.Identity.Models;
using N70.Identity.Domain.Entities;

namespace N70.Identity.Infrastructure.Common.Mapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<User, RegisterDetails>().ReverseMap();
    }
}