using Microsoft.Extensions.Options;
using Notification.Application.Common.Notifications.Brokers;
using Notification.Application.Common.Notifications.Models;
using Notification.Infrastructure.Settings;
using System.Net;
using System.Net.Mail;

namespace Notification.Infrastructure.Notifications.Brokers;

public class SmtpEmailSenderBroker : IEmailSenderBroker
{
    private readonly SmtpEmailSenderSettings _smtpEmailSenderSettings;

    public SmtpEmailSenderBroker(IOptions<SmtpEmailSenderSettings> smtpEmailSenderSettings)
    {
        _smtpEmailSenderSettings = smtpEmailSenderSettings.Value;
    }

    public ValueTask<bool> SendEmailAsync(EmailMessage emailMessage, CancellationToken cancellationToken = default)
    {
        emailMessage.SendEmailAddress ??= _smtpEmailSenderSettings.CredentialAddress;

        var mail = new MailMessage(emailMessage.SendEmailAddress, emailMessage.ReceiverEmailAddress);
        mail.Subject = emailMessage.Subject;
        mail.Body = emailMessage.Body;
        mail.IsBodyHtml = true;

        var smtpClient = new SmtpClient(_smtpEmailSenderSettings.Host, _smtpEmailSenderSettings.Port);
        smtpClient.Credentials =
            new NetworkCredential(_smtpEmailSenderSettings.CredentialAddress, _smtpEmailSenderSettings.Password);
        smtpClient.EnableSsl = true;

        smtpClient.Send(mail);

        return new ValueTask<bool>(true);
    }
}