using FluentValidation;
using Notification.Application.Common.Notifications.Brokers;
using Notification.Application.Common.Notifications.Models;
using Notification.Application.Common.Notifications.Services;
using Notification.Domain.Enums;
using Notification.Domain.Extensions;

namespace Notifications.Infrastructure.Infrastrucutre.Common.Notifications.Services;

public class EmailSenderService : IEmailSenderService
{
    private readonly IEnumerable<IEmailSenderBroker> _emailSenderBrokers;
    private readonly IValidator<EmailMessage> _emailMessageValidator;

    public EmailSenderService(
        IEnumerable<IEmailSenderBroker> emailSenderBrokers,
        IValidator<EmailMessage> emailMessageValidator
    )
    {
        _emailSenderBrokers = emailSenderBrokers;
        _emailMessageValidator = emailMessageValidator;
    }

    public async ValueTask<bool> SendAsync(EmailMessage emailMessage, CancellationToken cancellationToken = default)
    {
        var validationResult = _emailMessageValidator.Validate(emailMessage,
            options => options.IncludeRuleSets(NotificationEvent.OnSending.ToString()));
        if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

        foreach (var smsSenderBroker in _emailSenderBrokers)
        {
            var sendNotificationTask = () => smsSenderBroker.SendEmailAsync(emailMessage, cancellationToken);
            var result = await sendNotificationTask.GetValueAsyc();

            emailMessage.IsSuccessful = result.IsSuccess;
            emailMessage.ErrorMessage = result.Exception?.Message;
            return result.IsSuccess;
        }

        return false;
    }
}