using Microsoft.AspNetCore.Mvc;
using Notification.Application.Common.Notifications.Models;
using Notification.Application.Common.Notifications.Services;

namespace Notifications.Infrastructure.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    private readonly ISmsSenderService _smsService;
    private readonly IEmailSenderService _emaiService;

    public ValuesController(IEmailSenderService emailSenderService, ISmsSenderService smsSenderService)
    {
        _smsService = smsSenderService;
        _emaiService = emailSenderService;
    }

    [HttpPost("email")]
    public async ValueTask<IActionResult> Send([FromBody] EmailMessage request)
    {
        var result = await _emaiService.SendAsync(request);
        return Ok(result);
    }

    [HttpPost("sms")]
    public async ValueTask<IActionResult> Send([FromBody] SmsMessage request)
    {
        var result = await _smsService.SendAsync(request);
        return Ok(result);
    }
}
