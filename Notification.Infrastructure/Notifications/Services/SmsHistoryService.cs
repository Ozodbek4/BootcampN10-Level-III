﻿using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Notification.Application.Common.Models.Querying;
using Notification.Application.Common.Notifications.Services;
using Notification.Application.Common.Querying.Extensions;
using Notification.Domain.Entities;
using Notification.Domain.Enums;
using Notification.Persistence.Repositories.Interfaces;

namespace Notifications.Infrastructure.Infrastrucutre.Common.Notifications.Services;

public class SmsHistoryService : ISmsHistoryService
{
    private readonly ISmsHistoryRepository _smsHistoryRepository;
    private readonly IValidator<SmsHistory> _smsHistoryValidator;

    public SmsHistoryService(ISmsHistoryRepository smsHistoryRepository, IValidator<SmsHistory> smsHistoryValidator)
    {
        _smsHistoryRepository = smsHistoryRepository;
        _smsHistoryValidator = smsHistoryValidator;
    }

    public async ValueTask<IList<SmsHistory>> GetByFilterAsync(
        FilterPagination paginationOptions,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    ) =>
        await _smsHistoryRepository.Get().ApplyPagination(paginationOptions).ToListAsync(cancellationToken);

    public async ValueTask<SmsHistory> CreateAsync(
        SmsHistory smsHistory,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    )
    {
        var validationResult = await _smsHistoryValidator.ValidateAsync(smsHistory,
            options => options.IncludeRuleSets(EntityEvent.OnCreate.ToString()),
            cancellationToken);
        if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

        return await _smsHistoryRepository.CreateAsync(smsHistory, saveChanges, cancellationToken);
    }
}