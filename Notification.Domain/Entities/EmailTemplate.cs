using Notification.Domain.Enums;

namespace Notification.Domain.Entities;

public class EmailTemplate : NotificationTemplate
{
    public EmailTemplate() =>
       Type = NotificationType.Emial;

    public string Subject { get; set; } = default!;
}