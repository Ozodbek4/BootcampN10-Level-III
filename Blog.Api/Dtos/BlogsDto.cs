namespace Blog.Api.Dtos;

public class BlogsDto
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string? ImagePath { get; set; }

    public string? Description { get; set; }
}