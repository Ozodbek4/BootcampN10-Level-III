using AutoMapper;
using Blog.Api.Dtos;
using Blog.Domain.Entities;

namespace Blog.Api.Mapper;

public class BlogMapper : Profile
{
    public BlogMapper()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<Blogs, BlogsDto>().ReverseMap();
        CreateMap<Comment, CommentDto>().ReverseMap();
    }
}