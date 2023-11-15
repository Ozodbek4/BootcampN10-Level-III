using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N70.Identity.Domain.Entities;

namespace N70.Identity.Persistence.EntityConfigurations;

public class AccessTokenConfiguration : IEntityTypeConfiguration<AccessToken>
{
    public void Configure(EntityTypeBuilder<AccessToken> builder)
    {
        builder.HasOne<User>().WithMany().HasForeignKey(token => token.UserId);
    }
}