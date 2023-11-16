using Notification.Domain.Enums;

namespace Notification.Domain.Entities;

public class SmsHistory : NotificationHistory
{
    public SmsHistory() =>
        Type = NotificationType.Sms;

    public string SenderPhoneNumber { get; set; } = default!;

    public string RecieverPhoneNumber { get; set; } = default!;
}