using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Persistence.EntityConfigurations;

public class BlogConfiguration : IEntityTypeConfiguration<Blogs>
{
    public void Configure(EntityTypeBuilder<Blogs> builder)
    {
        builder
            .HasMany(blogs => blogs.Comments)
            .WithOne()
            .HasForeignKey(comment => comment.BlogId);
    }
}