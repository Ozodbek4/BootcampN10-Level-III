using Blog.Domain.Common;

namespace Blog.Domain.Entities;

public class Blogs : IEntity
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string? ImagePath { get; set; }

    public string? Description { get; set; }

    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
}