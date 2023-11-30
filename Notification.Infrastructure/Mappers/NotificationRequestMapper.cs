using AutoMapper;
using Notification.Application.Common.Notifications.Models;

namespace Notification.Infrastructure.Mappers;

public class NotificationRequestMapper : Profile
{
    public NotificationRequestMapper()
    {
        CreateMap<NotificationRequest, EmailNotificationRequest>();
        CreateMap<NotificationRequest, SmsNotificationRequest>();
    }
}