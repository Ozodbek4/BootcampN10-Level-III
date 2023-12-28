using Microsoft.AspNetCore.Mvc;
using Notification.Application.Common.Models.Querying;
using Notification.Application.Common.Notifications.Models;
using Notification.Application.Common.Notifications.Services;
using Notification.Domain.Entities;

namespace Notifications.Infrastructure.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationsController : ControllerBase
{
    private readonly INotificationAggregatorService _notificationAggregatorService;

    public NotificationsController(INotificationAggregatorService notificationAggregatorService)
    {
        _notificationAggregatorService = notificationAggregatorService;
    }

    [HttpPost]
    public async ValueTask<IActionResult> Send([FromBody] NotificationRequest request)
    {
        var result = await _notificationAggregatorService.SendAsync(request);
        return result.IsSuccess && (result?.Data ?? false) ? Ok() : BadRequest();
    }

    [HttpGet("templates")]
    public async ValueTask<IActionResult> GetTemplates(
        [FromQuery] NotificationTemplateFilter filter)
    {
        var result = await _notificationAggregatorService.GetTemplatesByFilterAsync(filter, HttpContext.RequestAborted);
        return result.Any() ? Ok(result) : BadRequest();
    }

    [HttpGet("templates/sms")]
    public async ValueTask<IActionResult> GetSmsTemplates(
        [FromQuery] FilterPagination filter,
        [FromServices] ISmsTemplateService smsTemplateService)
    {
        var result = await smsTemplateService.GetByFilterAsync(filter, cancellationToken: HttpContext.RequestAborted);
        return result.Any() ? Ok(result) : BadRequest();
    }

    [HttpGet("templates/email")]
    public async ValueTask<IActionResult> GetEmailTemplates(
        [FromQuery] FilterPagination filter,
        [FromServices] IEmailTemplateService emailTemplateService)
    {
        var result = await emailTemplateService.GetByFilterAsync(filter, cancellationToken: HttpContext.RequestAborted);
        return result.Any() ? Ok(result) : BadRequest();
    }

    [HttpPost("templates/sms")]
    public async ValueTask<IActionResult> CreateSmsTemplate(
        [FromBody] SmsTemplate template,
        [FromServices] ISmsTemplateService smsTemplateService)
    {
        var result = await smsTemplateService.CreateAsync(template, cancellationToken: HttpContext.RequestAborted);
        return Ok(result);
    }

    [HttpPost("templates/email")]
    public async ValueTask<IActionResult> CreateEmailTemplate(
        [FromBody] EmailTemplate template,
        [FromServices] IEmailTemplateService emailTemplateService)
    {
        var result = await emailTemplateService.CreateAsync(template, cancellationToken: HttpContext.RequestAborted);
        return Ok(result);
    }
}