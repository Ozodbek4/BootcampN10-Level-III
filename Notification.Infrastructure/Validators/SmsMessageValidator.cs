using FluentValidation;
using Notification.Application.Common.Notifications.Models;
using Notification.Domain.Enums;

namespace Notification.Infrastructure.Validators;

public class SmsMessageValidator : AbstractValidator<SmsMessage>
{
    public SmsMessageValidator()
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
                RuleFor(message => message.SenderPhoneNumber).NotNull().NotEmpty();
                RuleFor(history => history.ReceiverPhoneNumber).NotNull().NotEmpty();
                RuleFor(history => history.Message).NotNull().NotEmpty();
            });
    }
}