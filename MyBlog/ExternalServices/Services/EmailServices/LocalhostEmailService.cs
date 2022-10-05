using MyBlog.ExternalServices.IServices.EmailServices;
using MyBlog.Models.ExternalServiceModels.EmailServiceModels;
using System.Net.Mail;

namespace MyBlog.ExternalServices.Services.EmailServices
{
    public class LocalhostEmailService : IEmailService
    {
        public async Task<bool> SendEmail(EmailRequest emailRequest)
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
    }
}
