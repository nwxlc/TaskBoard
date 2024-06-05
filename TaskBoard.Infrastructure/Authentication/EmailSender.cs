using MimeKit;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace TaskBoard.Infrastructure.Authentication;

public class EmailSender
{
    public async Task SendEmailAsync(string email, string subject, string message)
    {
        using var emailMessage = new MimeMessage();
 
        emailMessage.From.Add(new MailboxAddress("Администрация сайта", "login@yandex.ru"));
        emailMessage.To.Add(new MailboxAddress("", email));
        emailMessage.Subject = subject;
        emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
        {
            Text = "Токен подтверждения: " + message
        };
             
        using (var client = new SmtpClient())
        {
            await client.ConnectAsync("smtp.yandex.ru", 25, false);
            await client.AuthenticateAsync("login@yandex.ru", "password");
            await client.SendAsync(emailMessage);
 
            await client.DisconnectAsync(true);
        }
    }
}