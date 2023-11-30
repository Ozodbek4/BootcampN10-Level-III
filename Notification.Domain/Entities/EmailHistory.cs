using Notification.Domain.Enums;

namespace Notification.Domain.Entities;

public class EmailHistory : NotificationHistory
{
    public EmailHistory() =>
        Type = NotificationType.Email;

    public string SenderEmailAddress { get; set; } = default!;

    public string RecieverEmailAddress { get; set; } = default!;

    public string Subject { get; set; } = default!;
}