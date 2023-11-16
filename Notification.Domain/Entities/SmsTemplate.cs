using Notification.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Domain.Entities;

public class SmsTemplate : NotificationTemplate
{
    public SmsTemplate() =>
        Type = NotificationType.Sms;
}