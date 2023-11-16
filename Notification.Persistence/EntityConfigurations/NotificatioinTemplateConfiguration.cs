using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notification.Domain.Entities;
using Notification.Domain.Enums;

namespace Notification.Persistence.EntityConfigurations;

public class NotificatioinTemplateConfiguration : IEntityTypeConfiguration<NotificationTemplate>
{
    public void Configure(EntityTypeBuilder<NotificationTemplate> builder)
    {
        builder.Property(template => template.Content)
            .HasMaxLength(100_000);

        builder
            .ToTable("NotificationTemplates")
            .HasDiscriminator(emailTemplate => emailTemplate.Type)
            .HasValue<SmsTemplate>(NotificationType.Sms)
            .HasValue<EmailTemplate>(NotificationType.Emial);
    }
}