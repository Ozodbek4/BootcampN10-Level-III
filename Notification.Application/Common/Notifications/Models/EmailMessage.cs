﻿using Notification.Domain.Entities;

namespace Notification.Application.Common.Notifications.Models;

public class EmailMessage : NotificationMessage
{
    public string SendEmailAddress { get; set; } = default!;

    public string ReceiverEmailAddress { get; set; } = default!;

    public EmailTemplate Template { get; set; } = default!;

    public string Subject { get; set; } = default!;

    public string Body { get; set; } = default!;
}