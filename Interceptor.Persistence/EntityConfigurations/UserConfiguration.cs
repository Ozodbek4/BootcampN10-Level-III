using Interceptor.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Interceptor.Persistence.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(user => user.FirstName).IsRequired().HasMaxLength(256);
        builder.Property(user => user.LastName).IsRequired().HasMaxLength(256);
        builder.Property(user => user.EmailAddress).IsRequired().HasMaxLength(256);
        builder.Property(user => user.Password).IsRequired().HasMaxLength(256);
        builder.Property(user => user.CreatedByUserId).IsRequired();

        builder.HasIndex(user => user.EmailAddress).IsUnique();

        builder.HasData(new User
        {
            Id = Guid.Parse("a4c86788-98c7-4dcf-9338-02e06e074bbd"),
            CreatedByUserId = Guid.Parse("a4c86788-98c7-4dcf-9338-02e06e074bbd"),
            FirstName = "System",
            LastName = "System",
            EmailAddress = "ozodbek@gmail.com",
            Password = "Password",
        });
    }
}