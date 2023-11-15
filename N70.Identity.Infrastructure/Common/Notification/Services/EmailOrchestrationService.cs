using Microsoft.Extensions.Options;
using N70.Identity.Application.Common.Notifications.Services;
using N70.Identity.Application.Common.Settings;
using System.Net;
using System.Net.Mail;

namespace N70.Identity.Infrastructure.Common.Notification.Services;

public class EmailOrchestrationService : IEmailOrchestrationService
{
    private readonly EmailSenderSettings _emailSenderSettings;

    public EmailOrchestrationService(IOptions<EmailSenderSettings> emailSenderSettings) =>
        _emailSenderSettings = emailSenderSettings.Value;

    public ValueTask<bool> SendMessageAsync(string emailAddress, string message)
    {
        var mail = new MailMessage(_emailSenderSettings.CredentialAddress, emailAddress);
        mail.Subject = "Siz muvofiqiyatli ro'yxatdan o'tdingiz";
        mail.Body = message;

        var smtpClient = new SmtpClient(_emailSenderSettings.Host, _emailSenderSettings.Port);
        smtpClient.Credentials = new NetworkCredential(_emailSenderSettings.CredentialAddress, _emailSenderSettings.Password);

        try
        {
            smtpClient.Send(mail);
            return new(true);
        }
        catch (Exception ex)
        {
            return new(false);
        }
    }
}