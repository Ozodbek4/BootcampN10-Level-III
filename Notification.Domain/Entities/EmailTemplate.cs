using Notification.Domain.Enums;

namespace Notification.Domain.Entities;

public class EmailTemplate : NotificationTemplate
{
    public EmailTemplate() =>
       Type = NotificationType.Email;

    public string Subject { get; set; } = default!;
}