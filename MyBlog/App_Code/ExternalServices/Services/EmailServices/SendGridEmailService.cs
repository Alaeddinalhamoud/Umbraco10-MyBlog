using Microsoft.Extensions.Options;
using MyBlog.ExternalServices.IServices.EmailServices;
using MyBlog.Models.AppSettings;
using MyBlog.Models.ExternalServiceModels.EmailServiceModels;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace MyBlog.ExternalServices.Services.EmailServices
{
    public class SendGridEmailService : IEmailService
    {
        private readonly IOptions<EmailSettings> options;
        private readonly ILogger<SendGridEmailService> logger;
        public SendGridEmailService(IOptions<EmailSettings> options, ILogger<SendGridEmailService> logger)
        {
            this.options = options;
            this.logger = logger;
        }
        public async Task<bool> SendEmail(EmailRequest emailRequest)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(options.Value.SendGridAPIKey)) return false;

                var client = new SendGridClient(options.Value.SendGridAPIKey);
                var from = new EmailAddress(emailRequest?.From);
                var subject = emailRequest?.Subject;
                var to = new EmailAddress(emailRequest?.To);
                var plainTextContent = emailRequest?.Body;
                var htmlContent = emailRequest?.Body;
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                await client.SendEmailAsync(msg);

                return true;
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex, $"Error while processing {nameof(SendGridEmailService)}");
                return false;
            }
        }
    }
}
