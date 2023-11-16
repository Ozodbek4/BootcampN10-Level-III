using Notification.Domain.Common.Entities;
using Notification.Domain.Enums;

namespace Notification.Domain.Entities;

public class UserSettings : IEntity
{
    public Guid Id { get; set; }

    public NotificationType? PreferredNotificationType { get; set; }
}