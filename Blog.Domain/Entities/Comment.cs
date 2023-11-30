using Blog.Domain.Common;

namespace Blog.Domain.Entities;

public class Comment : IEntity
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid ParentId { get; set; }

    public Guid BlogId { get; set; }

    public string? ImagePath { get; set; }

    public string? Content { get; set; }

    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
}