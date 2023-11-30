using FluentValidation;
using Notification.Domain.Entities;
using Notification.Domain.Enums;

namespace Notification.Infrastructure.Validators;

public class SmsHistoryValidator : AbstractValidator<SmsHistory>
{
    public SmsHistoryValidator()
    {
        RuleSet(EntityEvent.OnCreate.ToString(),
            () =>
            {
                RuleFor(history => history.TemplateId).NotEqual(Guid.Empty);

                RuleFor(history => history.SenderId).NotEqual(Guid.Empty);

                RuleFor(history => history.SenderId).NotEqual(Guid.Empty);

                RuleFor(history => history.Content).NotEmpty().MaximumLength(129_536);

                RuleFor(history => history.SenderPhoneNumber).NotEmpty().MaximumLength(64);

                RuleFor(history => history.RecieverPhoneNumber).NotEmpty().MaximumLength(64);
            });
    }
}