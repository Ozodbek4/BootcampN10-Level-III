using Notification.Application.Common.Notifications.Models;

namespace Notification.Application.Common.Notifications.Brokers;

public interface IEmailSenderBroker
{
    ValueTask<bool> SendEmailAsync(EmailMessage emailMessage, CancellationToken cancellationToken = default);
}