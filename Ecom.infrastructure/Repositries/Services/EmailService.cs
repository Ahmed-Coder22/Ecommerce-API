using Ecom.Core.DTO;
using Ecom.Core.Services;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace Ecom.infrastructure.Repositries.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration configuration;
        public EmailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task SendEmail(EmailDTO emailDTO)
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("My Ecom", configuration["EmailSetting:From"]));
            message.To.Add(new MailboxAddress(emailDTO.To, emailDTO.To));
            message.Subject = emailDTO.Subject;

            message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = emailDTO.Content
            };

            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            try
            {

                await smtp.ConnectAsync(
                                configuration["EmailSetting:Smtp"],
                                int.Parse(configuration["EmailSetting:Port"]),
                                MailKit.Security.SecureSocketOptions.StartTls);

                await smtp.AuthenticateAsync(
                    configuration["EmailSetting:Username"],
                    configuration["EmailSetting:Password"]);

                await smtp.SendAsync(message);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to send email: {ex.Message}");
            }
            finally
            {
                if (smtp.IsConnected)
                    await smtp.DisconnectAsync(true);
            }
        }
    }
}