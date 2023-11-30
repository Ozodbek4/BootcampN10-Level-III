using FluentValidation;
using Notification.Application.Common.Notifications.Brokers;
using Notification.Application.Common.Notifications.Models;
using Notification.Application.Common.Notifications.Services;
using Notification.Domain.Enums;
using Notification.Domain.Extensions;

namespace Notifications.Infrastructure.Infrastrucutre.Common.Notifications.Services;

public class SmsSenderService : ISmsSenderService
{
    private readonly IEnumerable<ISmsSenderBroker> _smsSenderBrokers;
    private readonly IValidator<SmsMessage> _smsMessageValidator;

    public SmsSenderService(
        IEnumerable<ISmsSenderBroker> smsSenderBrokers,
        IValidator<SmsMessage> smsMessageValidator
    )
    {
        _smsSenderBrokers = smsSenderBrokers;
        _smsMessageValidator = smsMessageValidator;
    }

    public async ValueTask<bool> SendAsync(SmsMessage smsMessage, CancellationToken cancellationToken = default)
    {
        var validationResult = _smsMessageValidator.Validate(smsMessage,
            options => options.IncludeRuleSets(NotificationEvent.OnRendering.ToString()));
        if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

        foreach (var smsSenderBroker in _smsSenderBrokers)
        {
            var sendNotificationTask = () => smsSenderBroker.SendSmsAsync(smsMessage, cancellationToken);
            var result = await sendNotificationTask.GetValueAsyc();

            smsMessage.IsSuccessful = result.IsSuccess;
            smsMessage.ErrorMessage = result.Exception?.Message;
            return result.IsSuccess;
        }

        return false;
    }
}