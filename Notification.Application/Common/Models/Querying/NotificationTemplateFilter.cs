using Notification.Domain.Enums;

namespace Notification.Application.Common.Models.Querying;

public class NotificationTemplateFilter : FilterPagination
{
    public IList<NotificationType> TemplateType { get; set; }
}