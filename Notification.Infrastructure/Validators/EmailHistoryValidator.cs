using FluentValidation;
using Notification.Domain.Entities;
using Notification.Domain.Enums;

namespace Notification.Infrastructure.Validators;

public class EmailHistoryValidator : AbstractValidator<EmailHistory>
{
    public EmailHistoryValidator()
    {
        RuleSet(EntityEvent.OnCreate.ToString(),
            () =>
            {
                RuleFor(history => history.TemplateId).NotEqual(Guid.Empty);

                RuleFor(history => history.SenderId).NotEqual(Guid.Empty);

                RuleFor(history => history.RecieverId).NotEqual(Guid.Empty);

                RuleFor(history => history.Content).NotEmpty().MaximumLength(129_536);

                RuleFor(history => history.SenderEmailAddress).NotEmpty().MaximumLength(64);

                RuleFor(history => history.RecieverEmailAddress).NotEmpty().MaximumLength(64);
            });
    }
}