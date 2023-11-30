using Notification.Application.Common.Notifications.Models;
using Notification.Domain.Common.Extentions;

namespace Notification.Application.Common.Notifications.Services;

public interface ISmsOrchestrationService
{
    ValueTask<FuncResult<bool>> SendAsync(SmsNotificationRequest request, CancellationToken cancellationToken = default);
}