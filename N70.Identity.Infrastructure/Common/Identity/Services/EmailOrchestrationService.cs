using N70.Identity.Application.Common.Notifications.Services;

namespace N70.Identity.Infrastructure.Common.Identity.Services;

public class EmailOrchestrationService : IEmailOrchestrationService
{
    public ValueTask<bool> SendMessageAsync(string emailAddress, string message)
    {
        throw new NotImplementedException();
    }
}