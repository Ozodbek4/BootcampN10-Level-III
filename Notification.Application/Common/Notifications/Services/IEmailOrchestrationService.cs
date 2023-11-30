using Notification.Application.Common.Notifications.Models;
using Notification.Domain.Common.Extentions;

namespace Notification.Application.Common.Notifications.Services;

public interface IEmailOrchestrationService
{
    ValueTask<FuncResult<bool>> SendAsync(EmailNotificationRequest request, CancellationToken cancellationToken = default);
}