using AutoMapper;
using Notification.Application.Common.Identities.Services;
using Notification.Application.Common.Notifications.Models;
using Notification.Application.Common.Notifications.Services;
using Notification.Domain.Common.Extentions;
using Notification.Domain.Entities;
using Notification.Domain.Enums;
using Notification.Domain.Extensions;
using Notification.Persistence.DataContexts;

namespace Notifications.Infrastructure.Infrastrucutre.Common.Notifications.Services;

public class SmsOrchestrationService : ISmsOrchestrationService
{
    private readonly IMapper _mapper;
    private readonly ISmsSenderService _smsSenderService;
    private readonly ISmsHistoryService _smsHistoryService;
    private readonly NotificationDbContext _dbContext;
    private readonly IUserService _userService;
    private readonly ISmsTemplateService _smsTemplateService;
    private readonly ISmsRenderingService _smsRenderingService;

    public SmsOrchestrationService(
        IMapper mapper,
        ISmsTemplateService smsTemplateService,
        ISmsRenderingService smsRenderingService,
        ISmsSenderService smsSenderService,
        ISmsHistoryService smsHistoryService,
        NotificationDbContext dbContext,
        IUserService userService
    )
    {
        _mapper = mapper;
        _smsTemplateService = smsTemplateService;
        _smsRenderingService = smsRenderingService;
        _smsSenderService = smsSenderService;
        _smsHistoryService = smsHistoryService;
        _dbContext = dbContext;
        _userService = userService;
    }

    public async ValueTask<FuncResult<bool>> SendAsync(
        SmsNotificationRequest request,
        CancellationToken cancellationToken = default
    )
    {
        var sendNotificationRequest = async () =>
        {
            var message = _mapper.Map<SmsMessage>(request);

            var senderUser =
                (await _userService.GetByIdAsync(request.SenderUserId!.Value))!;

            var receiverUser =
                (await _userService.GetByIdAsync(request.ReceiverUserId))!;

            message.SenderPhoneNumber = senderUser.PhoneNumber;
            message.ReceiverPhoneNumber = receiverUser.PhoneNumber;

            message.Template =
                await _smsTemplateService.GetByTypeAsync(request.TemplateType, true, cancellationToken) ??
                throw new InvalidOperationException(
                    $"Invalid template for sending {NotificationType.Sms} notification");

            await _smsRenderingService.RenderAsync(message, cancellationToken);

            await _smsSenderService.SendAsync(message, cancellationToken);

            var history = _mapper.Map<SmsHistory>(message);
            var test = _dbContext.Entry(history.Template).State;

            await _smsHistoryService.CreateAsync(history, cancellationToken: cancellationToken);

            return history.IsSuccessful;
        };

        return await sendNotificationRequest.GetValueAsyc();
    }
}