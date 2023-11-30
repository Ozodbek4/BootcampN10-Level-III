using FluentValidation;
using Notification.Application.Common.Identities.Services;
using Notification.Application.Common.Notifications.Models;
using Notification.Domain.Enums;

namespace Notification.Infrastructure.Validators;

public class NotificationRequestValidator : AbstractValidator<NotificationRequest>
{
    public NotificationRequestValidator(IUserService userService)
    {
        // TODO : to external
        var templatesRequireSender = new List<NotificationTemplateType>
        {
            NotificationTemplateType.ReferralNotification
        };

        RuleFor(request => request.SenderUserId)
            .NotEqual(Guid.Empty)
            .NotNull()
            .When(request => templatesRequireSender.Contains(request.TemplateType))
            .CustomAsync(async (senderUserId, context, cancellationToken) =>
            {
                var user = await userService.GetByIdAsync(senderUserId!.Value, true);

                if (user is null)
                    context.AddFailure("Sender user not found");
            });

        RuleFor(request => request.ReceiverUserId)
            .NotEqual(Guid.Empty)
            .CustomAsync(async (senderUserId, context, cancellationToken) =>
            {
                var user = await userService.GetByIdAsync(senderUserId, true);

                if (user is null)
                    context.AddFailure("Sender user not found");
            });
    }
}