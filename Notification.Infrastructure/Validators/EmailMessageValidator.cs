﻿using FluentValidation;
using Notification.Application.Common.Notifications.Models;
using Notification.Domain.Enums;

namespace Notification.Infrastructure.Validators;

public class EmailMessageValidator : AbstractValidator<EmailMessage>
{
    public EmailMessageValidator()
    {
        RuleSet(NotificationEvent.OnRendering.ToString(),
            () =>
            {
                RuleFor(history => history.Template).NotNull();
                RuleFor(history => history.Variables).NotNull();
                RuleFor(history => history.Template.Content).NotNull().NotEmpty();
            });

        RuleSet(NotificationEvent.OnSending.ToString(),
            () =>
            {
                RuleFor(history => history.SendEmailAddress).NotNull().NotEmpty();
                RuleFor(history => history.ReceiverEmailAddress).NotNull().NotEmpty();
                RuleFor(history => history.Subject).NotNull().NotEmpty();
                RuleFor(history => history.Body).NotNull().NotEmpty();
            });
    }
}