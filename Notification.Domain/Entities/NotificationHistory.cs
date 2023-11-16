using Notification.Domain.Common.Entities;
using Notification.Domain.Enums;

namespace Notification.Domain.Entities;

public abstract class NotificationHistory : IEntity
{
    public Guid Id { get; set; }

    public Guid TemplateId { get; set; }

    public Guid SenderId { get; set; }

    public Guid RecieverId { get; set; }

    public string Content { get; set; } = default!;

    public NotificationType Type { get; set; }

    public NotificationTemplate Template { get; set; }
}