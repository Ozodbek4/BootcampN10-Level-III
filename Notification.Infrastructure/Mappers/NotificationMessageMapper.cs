using AutoMapper;
using Notification.Application.Common.Notifications.Models;

namespace Notification.Infrastructure.Mappers;

public class NotificationMessageMapper : Profile
{
    public NotificationMessageMapper()
    {
        CreateMap<EmailNotificationRequest, EmailMessage>();
        CreateMap<SmsNotificationRequest, SmsMessage>();
    }
}