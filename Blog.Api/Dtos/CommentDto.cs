namespace Blog.Api.Dtos;

public class CommentDto
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid ParentId { get; set; }

    public Guid BlogId { get; set; }

    public string? ImagePath { get; set; }

    public string? Content { get; set; }
}