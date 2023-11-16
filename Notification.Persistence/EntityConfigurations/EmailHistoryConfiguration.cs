using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notification.Domain.Entities;

namespace Notification.Persistence.EntityConfigurations;

public class EmailHistoryConfiguration : IEntityTypeConfiguration<EmailHistory>
{
    public void Configure(EntityTypeBuilder<EmailHistory> builder)
    {
        builder
            .Property(history => history.SenderEmailAddress)
            .IsRequired()
            .HasMaxLength(256);
        builder
            .Property(history => history.RecieverEmailAddress)
            .IsRequired()
            .HasMaxLength(256);
        builder
            .Property(history => history.Subject)
            .IsRequired()
            .HasMaxLength(256);
    }
}