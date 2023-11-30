using Blog.Domain.Common;

namespace Blog.Domain.Entities;

public class User : IEntity
{
    public Guid Id { get; set; }

    public string UserName { get; set; } = default!;

    public string EmailAddress { get; set; } = default!;

    public ICollection<Blogs> Blogs { get; set; } = new List<Blogs>();
}