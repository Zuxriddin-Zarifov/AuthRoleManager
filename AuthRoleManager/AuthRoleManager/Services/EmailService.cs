using AuthRoleManager.Services.Interface;
using System.Net.Mail;

namespace AuthRoleManager.Services;

public class EmailService : IEmailService
{
    private readonly SmtpClient _smtpClient;
    

    public EmailService(SmtpClient smtpClient)
    {
        _smtpClient = smtpClient;
    }
    public async Task SendMassageAsync(string email, string subject, string body)
    {
       using(var mail = new MailMessage
       {
           From = new MailAddress(email),
           Subject = subject,
           Body = body,
           IsBodyHtml = true
       })
        {
            mail.To.Add(email);
            _smtpClient.Send(mail);
        }
    }
}
