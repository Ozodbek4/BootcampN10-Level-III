using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notification.Domain.Entities;

namespace Notification.Persistence.EntityConfigurations;

public class SmsHistoryConfiguration : IEntityTypeConfiguration<SmsHistory>
{
    public void Configure(EntityTypeBuilder<SmsHistory> builder)
    {
        builder
            .Property(history => history.RecieverPhoneNumber)
            .IsRequired()
            .HasMaxLength(32);
        builder
            .Property(history => history.SenderPhoneNumber)
            .IsRequired()
            .HasMaxLength(32);

    }
}