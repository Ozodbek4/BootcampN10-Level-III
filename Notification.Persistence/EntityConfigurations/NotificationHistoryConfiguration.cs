using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notification.Domain.Entities;
using Notification.Domain.Enums;

namespace Notification.Persistence.EntityConfigurations;

public class NotificationHistoryConfiguration : IEntityTypeConfiguration<NotificationHistory>
{
    public void Configure(EntityTypeBuilder<NotificationHistory> builder)
    {
        builder.Property(template => template.Content).HasMaxLength(100_000);

        builder
            .ToTable("NotificationHistories")
            .HasDiscriminator(emailTemplate => emailTemplate.Type)
            .HasValue<SmsHistory>(NotificationType.Sms)
            .HasValue<EmailHistory>(NotificationType.Email);

        builder
            .HasOne<NotificationTemplate>()
            .WithMany(template => template.Histories)
            .HasForeignKey(history => history.TemplateId);
    }
}