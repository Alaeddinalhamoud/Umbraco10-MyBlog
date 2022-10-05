using Microsoft.Extensions.Options;
using MyBlog.ExternalServices.IServices.EmailServices;
using MyBlog.Models.AppSettings;
using MyBlog.Models.ExternalServiceModels.EmailServiceModels;
using System.Net.Mail;

namespace MyBlog.ExternalServices.Services.EmailServices
{
    public class LocalhostEmailService : IEmailService
    {
        private readonly ILogger<LocalhostEmailService> logger;
        public LocalhostEmailService(ILogger<LocalhostEmailService> logger) =>
            this.logger = logger;
        public async Task<bool> SendEmail(EmailRequest emailRequest)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient("127.0.0.1", 25)
                {
                    EnableSsl = false,
                    UseDefaultCredentials = true
                };

                MailMessage mailMessage = new MailMessage();

                mailMessage.To.Add(new MailAddress(emailRequest?.To));
                mailMessage.From = new MailAddress(emailRequest?.From);
                mailMessage.Subject = emailRequest?.Subject;
                mailMessage.Body = emailRequest?.Body;
                await smtpClient.SendMailAsync(mailMessage);

                return true;
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex, $"Error while processing {nameof(LocalhostEmailService)}");
                return false;
            }
        }
    }
}
