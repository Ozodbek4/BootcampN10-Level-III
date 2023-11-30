using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Persistence.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasMany(user => user.Blogs)
            .WithOne()
            .HasForeignKey(blog => blog.UserId);

        builder
            .HasData(new User
            {
                Id = Guid.Parse("40191721-a6de-4766-9704-110f7d6f0f4c"),
                UserName = "Ozodbek",
                EmailAddress = "anvarjonovozodbek@gmail.com",
            });
    }
}